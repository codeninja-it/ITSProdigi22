namespace BloccoNote
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void mnuEsci_Click(object sender, EventArgs e)
        {
            DialogResult risultato = MessageBox.Show("Sei sicuro?", "Uscita dal programma", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(risultato == DialogResult.Yes)
                Application.Exit();
        }

        private void mnuApri_Click(object sender, EventArgs e)
        {
            DialogResult risultato = dlgApri.ShowDialog();
            if(risultato == DialogResult.OK)
            {
                string buffer = File.ReadAllText( dlgApri.FileName );
                txtCorpo.Text = buffer;
            }
        }

        private void mnuSalva_Click(object sender, EventArgs e)
        {
            DialogResult risultato = dlgSalva.ShowDialog();
            if(risultato == DialogResult.OK)
            {
                File.WriteAllText(
                        dlgSalva.FileName,
                        txtCorpo.Text
                    );
            }
        }
    }
}