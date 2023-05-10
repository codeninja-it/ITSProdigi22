using System.Windows.Forms;

namespace LabirintoWin
{
    public partial class Form1 : Form
    {
        private Point precedente = new Point(0,0);
        public Form1()
        {
            InitializeComponent();
            Bitmap nuova = new Bitmap(1000, 1000);
            pctLabirinto.Image = nuova;
            Graphics pennello = Graphics.FromImage(pctLabirinto.Image);
            pennello.Clear(Color.White);
        }

        private void pctLabirinto_MouseMove(object sender, MouseEventArgs e)
        {
            Point attuale = new Point(e.X, e.Y);
            lstSoluzioni.Items.Clear();
            lstSoluzioni.Items.Add($"{e.Location}\t{e.Button}");
            // comprendo le coordinate della casella
            int numCelle = 20;
            int cellaWidth = pctLabirinto.Width / numCelle;
            int cellaHeight = pctLabirinto.Height / numCelle;
            int cellaX = e.X / cellaWidth;
            int cellaY = e.Y / cellaHeight;
            Rectangle area = new Rectangle(cellaX * cellaWidth, cellaY * cellaHeight, cellaWidth, cellaHeight);
            if (e.Button == MouseButtons.Left)
            {
                Graphics pennello = Graphics.FromImage(pctLabirinto.Image);
                SolidBrush tratto = new SolidBrush(Color.Black);
                pennello.FillRectangle(tratto, area);
                pctLabirinto.Invalidate();
            } else if(e.Button == MouseButtons.Right)
            {
                Graphics pennello = Graphics.FromImage(pctLabirinto.Image);
                SolidBrush tratto = new SolidBrush(Color.White);
                pennello.FillRectangle(tratto, area);
                pctLabirinto.Invalidate();
            }
            precedente = attuale;
        }

        private void mnuEsci_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mnuApri_Click(object sender, EventArgs e)
        {
            if(dlgApri.ShowDialog() == DialogResult.OK)
            {
                using (FileStream flusso = new FileStream(dlgApri.FileName, FileMode.Open))
                {
                    pctLabirinto.Image = Image.FromStream(flusso);
                    flusso.Close();
                }
            }
        }

        private void mnuSalva_Click(object sender, EventArgs e)
        {
            if(dlgSalva.ShowDialog() == DialogResult.OK)
            {
                Image daSalvare = pctLabirinto.Image;
                daSalvare.Save(dlgSalva.FileName);
            }
        }
    }
}