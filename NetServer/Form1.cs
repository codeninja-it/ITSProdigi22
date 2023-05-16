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
		}

	}
}