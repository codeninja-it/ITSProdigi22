using PrimaApp;
using System.IO;
using System.Text;

internal class Program
{
    // primo parametro sarà la base della tabellina
    // secondo parametro sarà la quantità di volte
    private static void Main(string[] args)
    {
        Console.BackgroundColor = ConsoleColor.DarkBlue;
        Console.Clear();

        bool richiestaTabellina = true;
        while (richiestaTabellina)
        {
            int baseTabellina;
            int volte;
            if (args.Length == 2)
            {
                baseTabellina = int.Parse(args[0]);
                volte = int.Parse(args[1]) + 1;
            } else
            {
                // impostiamo la base della nostra tabellina
                baseTabellina = Utility.chiediNumero("Che tabellina vuoi");
                // decidiamo quante volte deve essere eseguita la moltiplicazione
                volte = Utility.chiediNumero("Fino a che numero") + 1;
            }

            // definisco il nome del file
            string nomeFile = $"tabellina_{baseTabellina}.txt";
            File.WriteAllText(nomeFile, $"TABELLINA DEL {baseTabellina}\n");            

            for (int numero = 0; numero < volte; numero++)
            {
                int risultato = numero * baseTabellina;
                string testo = $"{numero}\t*\t{baseTabellina}\t=\t{risultato}\n";
                //Console.Write(testo);
                File.AppendAllText(nomeFile, testo);
            }

            if(args.Length == 0)
            {
                string risposta = Utility.chiedi("Vuoi un'altra tabellina? (s/n)");
                richiestaTabellina = risposta == "s";
            } else
            {
                richiestaTabellina = false;
            }
            
        }

        if(args.Length == 0)
        {
            Console.WriteLine("Buona giornata!");
        }
        
    }

}