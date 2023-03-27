internal class Program
{
    private static void Main(string[] args)
    {
        Console.BackgroundColor = ConsoleColor.DarkBlue;
        Console.Clear();
        // impostiamo la base della nostra tabellina
        int baseTabellina = 2;
        // decidiamo quante volte deve essere eseguita la moltiplicazione
        int volte = 11;
        for(int numero = 0; numero < volte; numero++)
        {
            int risultato = numero * baseTabellina;
            Console.WriteLine($"{numero} * {baseTabellina} = {risultato}");
            //Console.WriteLine(numero.ToString() + " * " + baseTabellina.ToString() + " = " + risultato.ToString());
        }
    }
}