using PrimaApp;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.BackgroundColor = ConsoleColor.DarkBlue;
        Console.Clear();

        bool richiestaTabellina = true;
        while (richiestaTabellina)
        {
            // impostiamo la base della nostra tabellina
            int baseTabellina = Utility.chiediNumero("Che tabellina vuoi");
            // decidiamo quante volte deve essere eseguita la moltiplicazione
            int volte = Utility.chiediNumero("Fino a che numero") + 1;

            for (int numero = 0; numero < volte; numero++)
            {
                int risultato = numero * baseTabellina;
                Console.WriteLine($"{numero}\t*\t{baseTabellina}\t=\t{risultato}");
                //Console.WriteLine(numero.ToString() + " * " + baseTabellina.ToString() + " = " + risultato.ToString());
            }

            string risposta = Utility.chiedi("Vuoi un'altra tabellina? (s/n)");
            richiestaTabellina = risposta == "s";
        }
        Console.WriteLine("Buona giornata!");
    }

}