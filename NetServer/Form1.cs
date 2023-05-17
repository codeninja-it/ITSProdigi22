using System.Diagnostics;
using System.Net.Sockets;
using System.Text;

namespace NetServer
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void btnCartella_Click(object sender, EventArgs e)
		{
			if (dlgCartella.ShowDialog() == DialogResult.OK)
			{
				txtPath.Text = dlgCartella.SelectedPath;
			}
		}

		private void btnAvvia_Click(object sender, EventArgs e)
		{
			btnCartella.Enabled = false;
			numPorta.Enabled = false;
			// costruisco il telefono
			TcpListener telefono = new TcpListener((int)numPorta.Value);
			// attacco il telefono alla presa telefonica
			telefono.Start();
			// ci mettiamo in ascolto fino a che qualcuno non si connette
			TcpClient linea = telefono.AcceptTcpClient();
			lstRichieste.Items.Add("richiesta in ingresso!");
			// prendiamo il ricevitore per poter parlare e ascoltare
			NetworkStream cornetta = linea.GetStream();
			// mi presento
			Parla(cornetta, "TXTServer V.1.0.0\n\rBenvenuto!\n\r");
			string risposta;
			do
			{
				// gli chiedo cosa vuole
				risposta = Chiedi(cornetta, "comando: ");
				// lo analizzo
				switch (risposta)
				{
					case "LIST":
						string[] files = Directory.EnumerateFiles(txtPath.Text).ToArray();
						string listaFiles = String.Join("\r\n", files) + "\r\n";
						Parla(cornetta, listaFiles);
						break;
					case "RETR":
						Invia(cornetta, Chiedi(cornetta, "quale file vuoi? "));
						break;
					case "EXEC":
						EseguiExe(cornetta);
						break;
					case "PHP":
						EseguiPHP(cornetta);
						break;
					case "orario":
						Parla(cornetta, $"Sono le {DateTime.Now}\r\n");
						break;
				}
				if (risposta != "QUIT")
				{
					// lo riporto a schermo
					lstRichieste.Items.Add(risposta);
				}
			} while (risposta != "QUIT");

			// chiudo la telefonata
			linea.Close();
			// stacco il telefono dal muro così non chiamano per offerte
			telefono.Stop();
			lstRichieste.Items.Add("richiesta terminata!");
		}

		private void Invia(NetworkStream cornetta, string nomeFile)
		{
			string percorso = txtPath.Text;
			string percorsoFile = Path.Combine(percorso, nomeFile);
			if (File.Exists(percorsoFile))
			{
				byte[] contenuto = File.ReadAllBytes(percorsoFile);
				cornetta.Write(contenuto);
			}
			else
			{
				Parla(cornetta, "Il file non esiste!");
			}
		}

		private string Chiedi(NetworkStream cornetta, string domanda)
		{
			Parla(cornetta, domanda);
			return Ascolta(cornetta);
		}

		private void Parla(NetworkStream cornetta, string frase)
		{
			byte[] messaggio = Encoding.ASCII.GetBytes(frase);
			cornetta.Write(messaggio);
		}

		private string Ascolta(NetworkStream cornetta)
		{
			List<byte> buffer = new List<byte>();
			int singolo;
			do
			{
				singolo = cornetta.ReadByte();
				if (singolo > -1 && singolo != 13)
					if (singolo == 8)
						buffer.RemoveAt(buffer.Count - 1);
					else
						buffer.Add((byte)singolo);
			} while (singolo > -1 && singolo != 13);
			string testo = Encoding.ASCII.GetString(buffer.ToArray());
			return testo.Trim();
		}

		private void EseguiExe(NetworkStream cornetta)
		{
			string programma = Chiedi(cornetta, "comando da eseguire? ");
			string parametri = Chiedi(cornetta, "con quali parametri? ");
			Process cmd = new Process();
			cmd.StartInfo.FileName = programma;
			cmd.StartInfo.Arguments = parametri;
			cmd.StartInfo.RedirectStandardOutput = true;
			cmd.Start();
			string risultato = cmd.StandardOutput.ReadToEnd();
			Parla(cornetta, risultato);
		}

		private void EseguiPHP(NetworkStream cornetta)
		{
			string pagina = Chiedi(cornetta, "quale pagina? ");
			string pathPagina = Path.Combine(txtPath.Text, pagina + ".txt");
			Process interprete = new Process();
			interprete.StartInfo.FileName = @"c:\xampp\php\php.exe";
			interprete.StartInfo.Arguments = pathPagina;
			interprete.StartInfo.RedirectStandardOutput = true;
			interprete.Start();
			string paginaDinamica = interprete.StandardOutput.ReadToEnd();
			Parla(cornetta, paginaDinamica);
		}

	}
}