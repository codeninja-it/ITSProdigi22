using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace LabirintoWin
{
    public partial class Form1 : Form
    {
        private Point precedente = new Point(0,0);
        private int numCelle = 10;
        private bool[,] scacchiera;
        private Point inizio;
        private Point fine;
        public Form1()
        {
            InitializeComponent();
            Bitmap nuova = new Bitmap(1000, 1000);
            pctLabirinto.Image = nuova;
            Graphics pennello = Graphics.FromImage(pctLabirinto.Image);
            pennello.Clear(Color.White);
            scacchiera = new bool[numCelle, numCelle];
        }

        private void pctLabirinto_MouseMove(object sender, MouseEventArgs e)
        {
            Point attuale = new Point(e.X, e.Y);
            // comprendo le coordinate della casella
            int cellaWidth = pctLabirinto.Width / numCelle;
            int cellaHeight = pctLabirinto.Height / numCelle;
            int cellaX = e.X / cellaWidth;
            int cellaY = e.Y / cellaHeight;
            Rectangle area = new Rectangle(cellaX * cellaWidth, cellaY * cellaHeight, cellaWidth, cellaHeight);
            Graphics pennello = Graphics.FromImage(pctLabirinto.Image);
            SolidBrush tratto = new SolidBrush(Color.Black);
            if (e.Button == MouseButtons.Left && mnuMuro.Checked)
            {
                scacchiera[cellaX, cellaY] = true;
                pennello.FillRectangle(tratto, area);
            } else if(e.Button == MouseButtons.Right && mnuMuro.Checked)
            {
                scacchiera[cellaX, cellaY] = false;
                tratto = new SolidBrush(Color.White);
                pennello.FillRectangle(tratto, area);
            } else if (e.Button == MouseButtons.Left && !mnuMuro.Checked)
            {
                inizio = new Point(cellaX, cellaY);
                tratto = new SolidBrush(Color.Green);
                pennello.FillRectangle(tratto, area);
            } else if (e.Button == MouseButtons.Right && !mnuMuro.Checked)
            {
                fine = new Point(cellaX, cellaY);
                tratto = new SolidBrush(Color.Red);
                pennello.FillRectangle(tratto, area);
            }
            
            pctLabirinto.Invalidate();
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

        private void mnuMuro_Click(object sender, EventArgs e)
        {
            mnuMuro.Checked = true;
            mnuInizio.Checked = false;
        }

        private void mnuInizio_Click(object sender, EventArgs e)
        {
            mnuInizio.Checked = true;
            mnuMuro.Checked = false;
        }

        private void btnRisolvi_Click(object sender, EventArgs e)
        {
            lstSoluzioni.Items.Clear();
            scansiona(scacchiera, inizio, fine, new List<Point>());
        }

        private void scansiona(bool[,] labirinto, Point start, Point finish, List<Point> percorso = null)
        {
            if(start == finish)
            {
                lstSoluzioni.Items.Add(percorso);
            } else
            {
                percorso.Add(start);
                List<Point?> possibilità = new List<Point?>() {
                    start.Y - 1 >= 0 ? new Point(start.X, start.Y - 1) : null, // top
                    start.X - 1 >= 0 ? new Point(start.X - 1, start.Y) : null, // left
                    start.X + 1 < numCelle ? new Point(start.X + 1, start.Y) : null, // right
                    start.Y + 1 < numCelle ? new Point(start.X, start.Y + 1) : null // bottom
                };
                foreach (Point? p in possibilità)
                {
                    if (p.HasValue && !labirinto[p.Value.X, p.Value.Y] && !percorso.Contains(p.Value))
                    {
                        scansiona(labirinto, p.Value, finish, percorso);
                    }
                }
            }
        }
    }
}