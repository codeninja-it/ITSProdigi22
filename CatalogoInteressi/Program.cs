namespace CatalogoInteressi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] semplice = { };
            List<int> complesso = new List<int>();
            IEnumerable<int> generico = complesso;
            generico = semplice;

        }
    }
}