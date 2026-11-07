using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace v1
{
    using System;

    namespace StudentRegistrationSystem
    {
        internal class Program
        {
            static void Main(string[] args)
            {
                // Фаъол кардани Юникод (UTF-8) барои дуруст нишон додани ҳарфҳои тоҷикӣ
                Console.OutputEncoding = System.Text.Encoding.UTF8;
                Console.InputEncoding = System.Text.Encoding.UTF8;

                // 1. Эълони константа (собит)
                const string UNIVERSITY_NAME = "Донишгоҳи миллӣ";

                // 2. Қабули маълумот аз корбар
                Console.WriteLine("=== Системаи бақайдгирии донишҷӯён ({0}) ===", UNIVERSITY_NAME);
                Console.WriteLine();

                Console.Write("Номро ворид кунед: ");
                string firstName = Console.ReadLine();

                Console.Write("Насабро ворид кунед: ");
                string lastName = Console.ReadLine();

                // Бехатар хондани синну сол бо int.TryParse
                int age;
                Console.Write("Синну солро ворид кунед: ");

                while (!int.TryParse(Console.ReadLine(), out age) || age <= 0)
                {
                    Console.WriteLine("Хатогӣ! Танҳо адади бутуни мусбатро ворид кунед.");
                    Console.Write("Синну солро аз нав ворид кунед: ");
                }

                // Қабули номи ихтисос (метавонад чанд калима ва рақам дошта бошад)
                Console.Write("Ихтисосро ворид кунед (масалан: Системаҳои ахборӣ 1): ");
                string specialty = Console.ReadLine();

                // Тафтиш: агар корбар ҳеҷ чиз нанавишта Enter-ро пахш кунад, аз нав мепурсад
                while (string.IsNullOrWhiteSpace(specialty))
                {
                    Console.WriteLine("Хатогӣ! Номи ихтисос наметавонад холӣ бошад.");
                    Console.Write("Ихтисосро аз нав ворид кунед: ");
                    specialty = Console.ReadLine();
                }

                // 3. Барориши маълумот ба экран
                Console.WriteLine();
                Console.WriteLine("======================================");
                Console.WriteLine("    МАЪЛУМОТИ ДОНИШҶӮИ РАЙДШУДА");
                Console.WriteLine("======================================");
                Console.WriteLine("Донишгоҳ:   {0}", UNIVERSITY_NAME);
                Console.WriteLine("Ном ва насаб: {0} {1}", firstName, lastName);
                Console.WriteLine("Синну сол:    {0} сола", age);
                Console.WriteLine("Ихтисос:      {0}", specialty);
                Console.WriteLine("======================================");

                // Интизории пахши тугма
                Console.WriteLine("\nБарои баромадан дилхоҳ тугмаро пахш кунед...");
                Console.ReadKey();
            }
        }
    }
}