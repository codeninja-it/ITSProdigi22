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
            int baseTabellina = chiediNumero("Che tabellina vuoi");
            // decidiamo quante volte deve essere eseguita la moltiplicazione
            int volte = chiediNumero("Fino a che numero") + 1;

            for (int numero = 0; numero < volte; numero++)
            {
                int risultato = numero * baseTabellina;
                Console.WriteLine($"{numero}\t*\t{baseTabellina}\t=\t{risultato}");
                //Console.WriteLine(numero.ToString() + " * " + baseTabellina.ToString() + " = " + risultato.ToString());
            }

            string risposta = chiedi("Vuoi un'altra tabellina? (s/n)");
            richiestaTabellina = risposta == "s";
        }
        Console.WriteLine("Buona giornata!");
    }

    /// <summary>
    /// funzione per porre una domanda all'utente tramite la console
    /// </summary>
    /// <param name="domanda">la domanda da porre all'utente</param>
    /// <returns>quello che l'utete ha scritto in console</returns>
    private static string chiedi(string domanda)
    {
        // scrivo la domanda in console
        Console.Write(domanda + ": ");
        // recupero dal buffer la risposta
        string risposta = Console.ReadLine();
        // la restituisco a chimi ha chiamato
        return risposta;
    }

    private static int chiediNumero(string domanda)
    {
        Console.Write(domanda + ": ");
        string risposta = Console.ReadLine();
        return int.Parse(risposta);
    }

}