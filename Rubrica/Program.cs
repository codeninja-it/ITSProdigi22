using System.Text.Json;

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
                    case "nuovo": // Create
                        int nuovoId = contatti.Max(x => x.idContatto) + 1;
                        contatti.Add(
                                new Contatto(
                                        nuovoId,
                                        chiedi("Nome", false),
                                        chiedi("Cognome", false),
                                        chiedi("Telefono", false)
                                    )
                            ) ;
                        Console.WriteLine($"contatti presenti: {Contatto.quanti}");
                        break;

                    case "vedi": // Read
                        string chi = chiedi("Chi devo cercare", false);
                        List<Contatto> selezionati = contatti.Where(singolo => singolo.nome.Contains(chi)).ToList();
                        
                        Contatto nuovo;

                        foreach(Contatto singolo in selezionati)
                        {
                            Console.WriteLine(singolo);
                        }
                        break;

                    case "cancella": // delete
                        int idDaCancellare = int.Parse( chiedi("Quale id devo eliminare?") );

                        int cancellati = contatti.RemoveAll(x => x.idContatto == idDaCancellare);
                        Console.WriteLine($"{cancellati} record cancellati.");
                        break;

                    case "modifica": // update

                        break;
                    
                    case "salva":
                        File.WriteAllText( "rubrica.json", JsonSerializer.Serialize(contatti) );
                        Console.WriteLine("Rubrica salvata sul disco!");
                        break;

                    case "carica":
                        try
                        {
                            string buffer = File.ReadAllText("rubrica.json");
                            contatti = JsonSerializer.Deserialize<List<Contatto>>(buffer);
                            Console.WriteLine($"caricati {contatti.Count} contatti");
                        }
                        catch (Exception eccezione)
                        {
                            contatti = new();
                            Console.WriteLine("Errore di caricamento del file...");
                            Console.WriteLine(eccezione.Message);
                        }
                        break;

                    default:
                        Console.WriteLine("non ho capito, puoi ripetere?");
                        break;
                }

            } while(comando != "exit");
        }

        static private string chiedi(string domanda, bool corretto = true)
        {
            Console.Write($"{domanda} : ");
            if (corretto)
                return Console.ReadLine().ToLower().Trim();
            else
                return Console.ReadLine();
        }


    }
}

//l110:
//int iVecchio = 0;
//if(iVecchio < selezionati.Count)
//{
//    iVecchio++;
//    goto l110;
//}

//int i = 0;
//while(i < selezionati.Count)
//{
//    Contatto singolo = selezionati[i];
//    i++;
//}

//for(int n = 0; n < selezionati.Count; n++)
//{
//    Contatto singolo = selezionati[n];
//}