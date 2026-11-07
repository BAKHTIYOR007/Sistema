using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace v6
{

    using System;
    using System.Collections.Generic;

    namespace StudentSearchSystem
    {
        internal class Program
        {
            static void Main(string[] args)
            {
                // Фаъол кардани Юникод (UTF-8) барои ҳарфҳои тоҷикӣ
                Console.OutputEncoding = System.Text.Encoding.UTF8;
                Console.InputEncoding = System.Text.Encoding.UTF8;

                // БЕРУНИ СИКЛ: Рӯйхат ин ҷо сохта мешавад, то маълумот тоза нашавад
                List<string> students = new List<string>();

                bool running = true;

                while (running)
                {
                    Console.Clear();
                    Console.WriteLine("==========================================");
                    Console.WriteLine("      СИСТЕМАИ ҶУСТУҶӮИ ДОНИШҶӮЁН");
                    Console.WriteLine("==========================================");
                    Console.WriteLine("1. Нишон додани ҳамаи донишҷӯён");
                    Console.WriteLine("2. Илова кардани донишҷӯи нав");
                    Console.WriteLine("3. Ҷустуҷӯи донишҷӯ аз рӯи ном");
                    Console.WriteLine("4. Нест кардани донишҷӯ");
                    Console.WriteLine("5. Баромадан аз барнома");
                    Console.WriteLine("==========================================");
                    Console.Write("Амалиёти лозимиро интихоб кунед (1-5): ");

                    string choice = Console.ReadLine();
                    Console.WriteLine();

                    switch (choice)
                    {
                        case "1":
                            // Нишон додани ҳамаи донишҷӯён
                            Console.WriteLine("--- РӮЙХАТИ ДОНИШҶӮЁН ---");
                            if (students.Count == 0)
                            {
                                Console.WriteLine("Рӯйхат ҳанӯз холӣ аст.");
                            }
                            else
                            {
                                for (int i = 0; i < students.Count; i++)
                                {
                                    Console.WriteLine("{0}. {1}", i + 1, students[i]);
                                }
                            }
                            break;

                        case "2":
                            // Илова кардани донишҷӯ
                            Console.Write("Ному насаби донишҷӯро ворид кунед: ");
                            string newStudent = Console.ReadLine();

                            if (!string.IsNullOrWhiteSpace(newStudent))
                            {
                                students.Add(newStudent);
                                Console.WriteLine("Донишҷӯ бомуваффақият илова карда шуд!");
                            }
                            else
                            {
                                Console.WriteLine("Хатогӣ! Номи донишҷӯ наметавонад холӣ бошад.");
                            }
                            break;

                        case "3":
                            // Ҷустуҷӯи донишҷӯ аз рӯи ном
                            Console.Write("Номи ҷустуҷӯшавандаро ворид кунед: ");
                            string searchName = Console.ReadLine();

                            bool found = false;
                            Console.WriteLine("--- Натиҷаҳои ҷустуҷӯ ---");
                            foreach (string student in students)
                            {
                                if (student.IndexOf(searchName, StringComparison.OrdinalIgnoreCase) >= 0)
                                {
                                    Console.WriteLine("- {0}", student);
                                    found = true;
                                }
                            }

                            if (!found)
                            {
                                Console.WriteLine("Ягон донишҷӯ бо ин ном ёфт нашуд.");
                            }
                            break;

                        case "4":
                            // Нест кардани донишҷӯ
                            Console.Write("Номи донишҷӯеро, ки мехоҳед нест кунед, ворид кунед: ");
                            string removeName = Console.ReadLine();
                            string studentToRemove = students.Find(s => s.Equals(removeName, StringComparison.OrdinalIgnoreCase));

                            if (studentToRemove != null)
                            {
                                students.Remove(studentToRemove);
                                Console.WriteLine("Донишҷӯ бомуваффақият нест карда шуд!");
                            }
                            else
                            {
                                Console.WriteLine("Хатогӣ! Чунин донишҷӯ дар рӯйхат ёфт нашуд.");
                            }
                            break;

                        case "5":
                            // Баромадан аз барнома
                            running = false;
                            Console.WriteLine("Барнома ба анҷом расид. Хайр!");
                            break;

                        default:
                            Console.WriteLine("Хатогӣ! Лутфан рақами дурустро аз 1 то 5 интихоб кунед.");
                            break;
                    }

                    if (running)
                    {
                        Console.WriteLine("\nБарои идома додан дилхоҳ тугмаро пахш кунед...");
                        Console.ReadKey();
                    }
                }
            }
        }
    }
}