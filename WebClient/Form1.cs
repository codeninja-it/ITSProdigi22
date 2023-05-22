using System.Text.RegularExpressions;

namespace WebClient
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private async void btnVai_Click(object sender, EventArgs e)
		{
			string url = txtUrl.Text;
			lstParole.Items.Clear();
			HttpClient browser = new HttpClient();
			HttpResponseMessage risposta = await browser.GetAsync(url);
			if (risposta.IsSuccessStatusCode)
			{
				string testo = await risposta.Content.ReadAsStringAsync();
				testo = Regex.Replace(testo, @"<script[^>]*>[^<]*<\/script>", "", RegexOptions.Singleline);
				testo = Regex.Replace(testo, @"<[^>]+>", "");
				testo = testo.ToLower().Trim();
				// REGEX ???lst
				string[] parole = testo.Split(" ");// = ???;
				Dictionary<string,int> archivio = new();

				foreach(string parola in parole)
				{
					if (archivio.ContainsKey(parola))
					{
						archivio[parola]++;
					} else
					{
						archivio.Add(parola, 1);
					}
				}

				foreach(KeyValuePair<string, int> coppia in archivio.OrderByDescending(x => x.Value))
				{
					lstParole.Items.Add($"{coppia.Key}\t{coppia.Value}");
				}
			}

		}
	}
}