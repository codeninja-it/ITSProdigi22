using System.Reflection;

namespace QuartaApp
{
    internal class Program
    {
        static private List<Persona> persone = new List<Persona>();


        static void Main(string[] args)
        {
            // esempio di riferimento
            int prima = 1;
            int seconda = 2;
            somma(ref prima, seconda);
            Console.WriteLine(prima);

            // esempio di somma delle età
            persone.Add( new Persona("Jhon", "Doe", 18)   );
            persone.Add( new Persona("Federico", "Rossi", 20)   );

            Persona nuova = new Persona(persone[0].nome, persone[0].cognome, persone[0].età);
            nuova.età = 65;

            Compila(nuova);

            int totale = sommaEtà( persone[0], persone[1] );
            Console.WriteLine($"totale delle età è {totale}");
            Console.WriteLine($"Perchè Jhon ha {persone[0].età} mentre Federico ha {persone[1].età}");
        }

        static int sommaEtà(Persona prima, Persona seconda)
        {
            prima.età += seconda.età;
            return prima.età;
        }

        static void somma(ref int a, int b)
        {
            a = a + b;
            Console.WriteLine($"Sto stampando a: {a}");
        }

        //Clona(Persona persona);
        static void Compila(object oggetto)
        {
            Type tipo = oggetto.GetType();
            PropertyInfo[] props = tipo.GetProperties();
            foreach ( PropertyInfo pi in props.Where(x => x.CanWrite) )
            {
                Console.Write($"Dimmi {pi.Name} : ");
                var appoggio = Console.ReadLine();
                if(pi.PropertyType.Name == "Int32")
                {
                    pi.SetValue(oggetto, int.Parse(appoggio));
                } else
                {
                    pi.SetValue(oggetto, appoggio);
                }
            }
        }

    }
}