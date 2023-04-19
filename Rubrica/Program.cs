namespace Rubrica
{
    internal class Program
    {
        static private List<Contatto> contatti;
        static void Main(string[] args)
        {
            contatti = new List<Contatto>();
            string comando;
            do
            {
                comando = chiedi("cosa vuoi fare?");
                switch (comando)
                {
                    case "nuovo":
                        break;
                    case "cancella":
                        break;
                    case "modifica":
                        break;
                    case "vedi":
                        break;
                    case "salva":
                        break;
                    case "apri":
                        break;
                    default:
                        Console.WriteLine("non ho capito...");
                        break;
                }

            } while (comando != "exit");
        }

        static private string chiedi(string domanda)
        {
            Console.Write($"{domanda} : ");
            return Console.ReadLine().ToLower().Trim();
        }


    }
}