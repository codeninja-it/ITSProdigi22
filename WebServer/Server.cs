using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WebServer
{
	internal class Server
	{
		private HttpListener server;
		public bool attivo = false;
		public EventHandler<HttpListenerContext> ricevutaChiamata;

		public Server(string endpoint)
		{
			server.Prefixes.Add(endpoint);
			server.Start();
		}

		public async void Start()
		{
			attivo = true;
			while (attivo)
			{
				HttpListenerContext chiamata = server.GetContext();
				ricevutaChiamata.Invoke(this, chiamata);
			}
		}
	}
}
