using System.Diagnostics;
using System.Net;
using System.Text;

namespace WebServer
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			for(int i=0; i < 10; i++)
			{
				Orologio orologio = new Orologio();
				orologio.Show();
			}
			/*
			 * 1) permettere all'utente di selezionare la cartella di root
			 * 2) attendere una chiamata
			 * 3) capire quale pagina è richiesta
			 * 4) se presente spedirla
			 * 5) rimettersi in attesa della prossima chiamata
			 * 6) opzionale: permettere l'uso di pagina php
			 */
		}

		private void btnAvvia_Click(object sender, EventArgs e)
		{
			HttpListener server = new HttpListener();
			server.Prefixes.Add(txtUrl.Text); // http://127.0.0.1:8080/
			server.Start();
			while (true)
			{
				HttpListenerContext richiesta = server.GetContext();
				string fileRichiesto = richiesta.Request.RawUrl.Substring(1);
				lstRichieste.Items.Add(richiesta.Request.UserHostAddress + "\t" + fileRichiesto);
				fileRichiesto = Path.Combine(txtRoot.Text, fileRichiesto);
				byte[] pacchetto;
				if (File.Exists(fileRichiesto))
				{
					if (fileRichiesto.EndsWith(".php"))
					{
						Process php = new Process();
						php.StartInfo.FileName = @"c:\xampp\php\php.exe";
						php.StartInfo.Arguments = fileRichiesto;
						php.StartInfo.CreateNoWindow = true;
						php.StartInfo.RedirectStandardOutput = true;
						php.Start();
						string interpretato = php.StandardOutput.ReadToEnd();
						pacchetto = Encoding.UTF8.GetBytes(interpretato);
					}
					else
					{
						pacchetto = File.ReadAllBytes(fileRichiesto);
					}
				}
				else
				{
					string messaggio = $"<html><body><b>Attenzione:</b> file non trovato: {richiesta.Request.RawUrl}</body></html>";
					pacchetto = Encoding.UTF8.GetBytes(messaggio);
				}
				Stream cornetta = richiesta.Response.OutputStream;
				cornetta.Write(pacchetto);
				cornetta.Close();
				Application.DoEvents();
			}
			server.Close();
		}

		private void btnScegli_Click(object sender, EventArgs e)
		{
			if (dlgCartella.ShowDialog() == DialogResult.OK)
				txtRoot.Text = dlgCartella.SelectedPath;
		}
	}
}