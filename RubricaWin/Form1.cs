using System.Text.Json;

namespace RubricaWin
{
    public partial class Form1 : Form
    {
        public Form1(string filePath)
        {
            InitializeComponent();
            this.Text = filePath;
            try
            {
                string buffer = File.ReadAllText(filePath);
                Contatto[] recuperati = JsonSerializer.Deserialize<Contatto[]>(buffer);
                lstContatti.Items.AddRange(recuperati);
            } catch { 
            
            }
        }

        private void btnInserisci_Click(object sender, EventArgs e)
        {
            Contatto nuovo = new Contatto(
                                            txtNome.Text, 
                                            txtCognome.Text, 
                                            txtTelefono.Text);
            lstContatti.Items.Add(nuovo);
        }

        private void Form1_HelpButtonClicked(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Help finestra = new Help();
            finestra.ShowDialog();
        }

        private void btnApri_Click(object sender, EventArgs e)
        {
            Form1 nuovaFinestra = new Form1("rubrica.json");
            //nuovaFinestra.Show();
            nuovaFinestra.FormBorderStyle = FormBorderStyle.None;
            nuovaFinestra.WindowState = FormWindowState.Maximized;
            nuovaFinestra.ShowDialog();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            string buffer = JsonSerializer.Serialize(lstContatti.Items);
            File.WriteAllText(this.Text, buffer);
        }
    }
}