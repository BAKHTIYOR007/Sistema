using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace v7
{
using System.Collections.Generic; // Барои истифодаи Dictionary зарур аст

namespace PhoneBookSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Фаъол кардани Юникод (UTF-8) барои ҳарфҳои тоҷикӣ
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            // Эълони луғат (Dictionary) барои нигоҳ доштани Ном (Kalit) ва Рақам (Qiymat)
            // Истифодаи StringComparer.OrdinalIgnoreCase имкон медиҳад, ки номҳо бе фарқияти ҳарфи калон/хурд кор кунанд
            Dictionary<string, string> phoneBook = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

            bool running = true;

            while (running)
            {
                Console.Clear();
                Console.WriteLine("==========================================");
                Console.WriteLine("           КИТОБИ ТЕЛЕФОНӢ");
                Console.WriteLine("==========================================");
                Console.WriteLine("1. Нишон додани ҳама тамосҳо");
                Console.WriteLine("2. Илова кардани тамоси нав");
                Console.WriteLine("3. Ҷустуҷӯи рақам аз рӯи ном");
                Console.WriteLine("4. Тағйир додани рақами телефон");
                Console.WriteLine("5. Нест кардани тамос");
                Console.WriteLine("6. Баромадан аз барнома");
                Console.WriteLine("==========================================");
                Console.Write("Амалиёти лозимиро интихоб кунед (1-6): ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        // Нишон додани ҳамаи тамосҳо
                        Console.WriteLine("--- РӮЙХАТИ ТАМОСҲО ---");
                        if (phoneBook.Count == 0)
                        {
                            Console.WriteLine("Китоби телефонӣ ҳанӯз холӣ аст.");
                        }
                        else
                        {
                            int index = 1;
                            foreach (KeyValuePair<string, string> pair in phoneBook)
                            {
                                Console.WriteLine("{0}. Ном: {1} | Рақам: {2}", index, pair.Key, pair.Value);
                                index++;
                            }
                        }
                        break;

                    case "2":
                        // Илова кардани тамоси нав
                        Console.Write("Номи шахсро ворид кунед: ");
                        string name = Console.ReadLine().Trim();

                        if (string.IsNullOrEmpty(name))
                        {
                            Console.WriteLine("Хатогӣ! Ном наметавонад холӣ бошад.");
                            break;
                        }

                        if (phoneBook.ContainsKey(name))
                        {
                            Console.WriteLine("Хатогӣ! Чунин ном аллакай дар китоби телефонӣ мавҷуд аст. Шумо метавонед онро тағйир диҳед (Банди 4).");
                        }
                        else
                        {
                            Console.Write("Рақами телефонро ворид кунед: ");
                            string phone = Console.ReadLine().Trim();

                            if (!string.IsNullOrEmpty(phone))
                            {
                                phoneBook.Add(name, phone);
                                Console.WriteLine("Тамос бомуваффақият илова карда шуд!");
                            }
                            else
                            {
                                Console.WriteLine("Хатогӣ! Рақами телефон холӣ буда наметавонад.");
                            }
                        }
                        break;
                          case "3":
                        // Ҷустуҷӯи рақам аз рӯи ном
                        Console.Write("Номи шахсеро, ки мехоҳед ҷустуҷӯ кунед, ворид кунед: ");
                        string searchName = Console.ReadLine().Trim();

                        if (phoneBook.ContainsKey(searchName))
                        {
                            Console.WriteLine("--- Натиҷаи ҷустуҷӯ ---");
                            Console.WriteLine("Ном: {0}", searchName);
                            Console.WriteLine("Рақами телефон: {0}", phoneBook[searchName]);
                        }
                        else
                        {
                            Console.WriteLine("Ягон тамос бо ин ном ёфт нашуд.");
                        }
                        break;

                    case "4":
                        // Тағйир додани рақами телефон
                        Console.Write("Номи тамосеро, ки мехоҳед рақамашро тағйир диҳед, ворид кунед: ");
                        string editName = Console.ReadLine().Trim();

                        if (phoneBook.ContainsKey(editName))
                        {
                            Console.WriteLine("Рақами кунунӣ: {0}", phoneBook[editName]);
                            Console.Write("Рақами нави телефонро ворид кунед: ");
                            string newPhone = Console.ReadLine().Trim();

                            if (!string.IsNullOrEmpty(newPhone))
                            {
                                phoneBook[editName] = newPhone; // Навсозии рақам
                                Console.WriteLine("Рақами телефон бомуваффақият тағйир дода шуд!");
                            }
                            else
                            {
                                Console.WriteLine("Хатогӣ! Рақами нави телефон холӣ буда наметавонад.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Хатогӣ! Чунин ном дар китоби телефонӣ ёфт нашуд.");
                        }
                        break;

                    case "5":
                        // Нест кардани тамос
                        Console.Write("Номи тамосеро, ки мехоҳед нест кунед, ворид кунед: ");
                        string removeName = Console.ReadLine().Trim();

                        if (phoneBook.ContainsKey(removeName))
                        {
                            phoneBook.Remove(removeName);
                            Console.WriteLine("Тамос бомуваффақият нест карда шуд!");
                        }
                        else
                        {
                            Console.WriteLine("Хатогӣ! Чунин ном дар китоби телефонӣ ёфт нашуд.");
                        }
                        break;

                    case "6":
                        // Баромадан аз барнома
                        running = false;
                        Console.WriteLine("Барнома ба анҷом расид. Хайр!");
                        break;

                    default:
                        Console.WriteLine("Хатогӣ! Лутфан рақами дурустро аз 1 то 6 интихоб кунед.");
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
