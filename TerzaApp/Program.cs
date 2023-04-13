using System.Security.Cryptography.X509Certificates;

namespace TerzaApp
{
    internal class Program
    {
        private static List<Casella> Scacchiera;
        private static Casella inizio;
        private static Casella fine;
        private static List<string> soluzioni = new List<string>();

        static void Main(string[] args)
        {
            Scacchiera = new List<Casella>();
            string buffer = File.ReadAllText("labirinto.txt");
            string[] righe = buffer.Replace("\r", "").Split("\n");
            for(int y=0; y < righe.Length; y++)
            {
                string riga = righe[y];
                for(int x=0; x < riga.Length; x++)
                {
                    char cella = riga[x];
                    bool muro = cella == '1';
                    if(cella == 'S')
                    {
                        inizio = new(x, y, false);
                    } else if (cella == 'F')
                    {
                        fine = new(x, y, false);
                    }

                    Scacchiera.Add( new(x, y, muro) );
                }
            }
            Analizza2(Scacchiera, inizio, fine);
            string migliore = soluzioni.OrderBy(x => x.Length).FirstOrDefault();
            if(migliore != null)
            {
                Console.WriteLine($"Vince : {migliore}");
            }
        }

        private static void Analizza(List<Casella> scacchiera, Casella attuale, Casella arrivo, string percorso = "")
        {
            if(attuale.x == arrivo.x && attuale.y == arrivo.y)
            {
                soluzioni.Add(percorso);
                Console.WriteLine("Fatto:" + percorso);
            } else
            {
                // analizza su
                Casella? su = scacchiera
                    .Where(cella => cella.muro == false && cella.x == attuale.x && cella.y == attuale.y - 1)
                    .FirstOrDefault();
                if(su != null && !percorso.Contains($"[{su.x} {su.y}]"))
                {
                    Analizza(scacchiera, su, arrivo, percorso + $"[{attuale.x} {attuale.y}]");
                }
                // analizza dx
                Casella? dx = scacchiera.Where(cella => cella.muro == false && cella.x == attuale.x + 1 && cella.y == attuale.y).FirstOrDefault();
                if(dx != null && !percorso.Contains($"[{dx.x} {dx.y}]"))
                {
                    Analizza(scacchiera, dx, arrivo, percorso + $"[{attuale.x} {attuale.y}]");
                }
                // analizza giu
                Casella? giu = scacchiera.Where(cella => cella.muro == false && cella.x == attuale.x && cella.y == attuale.y + 1).FirstOrDefault();
                if (giu != null && !percorso.Contains($"[{giu.x} {giu.y}]"))
                {
                    Analizza(scacchiera, giu, arrivo, percorso + $"[{attuale.x} {attuale.y}]");
                }
                // analizza sx
                Casella? sx = scacchiera.Where(cella => cella.muro == false && cella.x == attuale.x - 1 && cella.y == attuale.y).FirstOrDefault();
                if (sx != null && !percorso.Contains($"[{sx.x} {sx.y}]"))
                {
                    Analizza(scacchiera, sx, arrivo, percorso + $"[{attuale.x} {attuale.y}]");
                }
            }
        }

        
        private static void Analizza2(List<Casella> Scacchiera, Casella Da, Casella A, String percorso = "")
        {
            // comportamento selettivo
            if(Da.y == A.y && Da.x == A.x)
            {
                soluzioni.Add(percorso);
                Console.WriteLine(percorso);
            }
            // navigazione
            List<Casella> possibili = Scacchiera.Where(
                                cella =>
                                cella.muro == false &&
                                (
                                    (cella.x == Da.x && cella.y == Da.y - 1) ||
                                    (cella.x == Da.x && cella.y == Da.y + 1) ||
                                    (cella.x == Da.x - 1 && cella.y == Da.y) ||
                                    (cella.x == Da.x + 1 && cella.y == Da.y)
                                )
                            ).ToList();
            foreach(Casella singola in possibili)
            {
                if(!percorso.Contains($"[{singola.x} {singola.y}]"))
                {
                    Analizza2(Scacchiera, singola, A, $"{percorso} [{Da.x} {Da.y}]");
                }
            }
        }

    }
}