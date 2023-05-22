using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebServer
{
	public partial class Orologio : Form
	{
		public Orologio()
		{
			InitializeComponent();
		}

		private void tmrOra_Tick(object sender, EventArgs e)
		{
			lblOrario.Text = DateTime.Now.ToString();
		}
	}
}
