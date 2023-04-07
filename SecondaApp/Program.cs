using System.IO;

namespace SecondaApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TrovaFile(".sql", "C:\\Users\\dsimo\\Documents\\");
            int tabellina = int.Parse(args[0]);
            int ripetizioni = int.Parse(args[1]);
            //for (int n=0; n < ripetizioni; n++)
            //{
                Moltiplica(tabellina, ripetizioni, 0);
            //}
        }

        static void Moltiplica(int tabellina, int ripetizioni, int n)
        {
            string risultato = $"{tabellina} X {n} = {tabellina * n}\n";
            File.AppendAllText($"tabellina_{tabellina}.txt", risultato);
            if (n < ripetizioni)
                Moltiplica(tabellina, ripetizioni, n + 1);
        }

        public static void TrovaFile(string estensione, string path = "c:/")
        { 
            IEnumerable<string> files;
            IEnumerable<string> sottoDirectory;

            try
            {
                files = Directory.EnumerateFiles(path);
            } catch (Exception)
            {
                files = new List<string>();
                Console.WriteLine($"{path} : Accesso negato");
            }

            try
            {
                sottoDirectory = Directory.EnumerateDirectories(path);
            } catch (Exception)
            {
                sottoDirectory = new List<string>();
            }


            
            
            foreach(string singolo in files)
            {
                if(singolo.EndsWith(estensione))
                    Console.WriteLine(singolo);
            }
            foreach(string sottoCartella in sottoDirectory)
            {
                TrovaFile(estensione, sottoCartella);
            }
        }
    }

}