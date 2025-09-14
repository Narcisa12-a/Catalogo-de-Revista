using System;
using System.Collections.Generic;
namespace CatalogoRevistas
{
    class Program
    {
        //Catálogo de revistas (lista)
        static List<string> catalogo = new List<string>
        {
            "National Geographic",
            "Vogue",
            "Avon",
            "Yanbal",
            "Oriflame",
            "Animage",
            "Cocina Gourmet",
            "Fitness Life",
            "Arte Moderno",
            "Viajes y Aventuras",
            "Jardinería Fácil",
            "Cine & Series"
        };
        static void Main(string[] args)
        {
            int opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("===== Catálogo de Revistas =====");
                Console.WriteLine("1. Mostrar catálogo");
                Console.WriteLine("2. Buscar revista (iterativa)");
                Console.WriteLine("3. Buscar revista (recursiva)");
                Console.WriteLine("0. Salir");
                Console.Write("Seleccione una opción: ");      
                if (!int.TryParse(Console.ReadLine(), out opcion))
                    opcion = -1;
                switch (opcion)
                {
                    case 1:
                        MostrarCatalogo();
                        break;
                    case 2:
                        BuscarIterativo();
                        break;
                    case 3:
                        BuscarRecursivo();
                        break;
                    case 0:
                        Console.WriteLine("Saliendo...");
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
                if (opcion != 0)
                {
                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadKey();
                }

            } while (opcion != 0);
        }
        //Mostrar el listado de revistas
        static void MostrarCatalogo()
        {
            Console.WriteLine("\nCatálogo de Revistas:");
            foreach (var revista in catalogo)
            {
                Console.WriteLine("- " + revista);
            }
        }
        //Búsqueda iterativa
        static void BuscarIterativo()
        {
            Console.Write("\nIngrese el título a buscar: ");
            string titulo = Console.ReadLine();
            bool encontrado = false;
            foreach (var revista in catalogo)
            {
                if (revista.Equals(titulo, StringComparison.OrdinalIgnoreCase))
                {
                    encontrado = true;
                    break;
                }
            }
            Console.WriteLine(encontrado ? "Encontrado" : "No encontrado");
        }
        //Búsqueda recursiva
        static void BuscarRecursivo()
        {
            Console.Write("\nIngrese el título a buscar: ");
            string titulo = Console.ReadLine();
            bool encontrado = BuscarRec(catalogo, titulo, 0);

            Console.WriteLine(encontrado ? "Encontrado" : "No encontrado");
        }
        //Función recursiva para buscar
        static bool BuscarRec(List<string> lista, string titulo, int indice)
        {
            if (indice >= lista.Count)
                return false;

            if (lista[indice].Equals(titulo, StringComparison.OrdinalIgnoreCase))
                return true;

            return BuscarRec(lista, titulo, indice + 1);
        }
    }
}
