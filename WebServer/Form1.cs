using System.Net;
using System.Text;

namespace WebServer
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void btnAvvia_Click(object sender, EventArgs e)
		{
			HttpListener server = new HttpListener();
			server.Prefixes.Add("http://127.0.0.1:8080/"); // ...
			server.Start();
			HttpListenerContext richiesta = server.GetContext();
			//richiesta.Request.Url;
			string messaggio = $"sito in costruzione: {richiesta.Request.RawUrl}";
			byte[] pacchetto = Encoding.UTF8.GetBytes(messaggio);
			richiesta.Response.OutputStream.Write(pacchetto);
			richiesta.Response.OutputStream.Close();
			server.Close();
		}
	}
}