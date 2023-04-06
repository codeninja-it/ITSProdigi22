namespace SecondaApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
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
    }
}