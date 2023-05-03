namespace RubricaWin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void btnInserisci_Click(object sender, EventArgs e)
        {
            string testo = txtNome.Text;
            lstContatti.Items.Add(testo);
        }

        private void Form1_HelpButtonClicked(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Help finestra = new Help();
            finestra.ShowDialog();
        }
    }
}