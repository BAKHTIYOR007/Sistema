using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace v3
{
    using System;

    namespace ExamResultSystem
    {
        internal class Program
        {
            static void Main(string[] args)
            {
                // Фаъол кардани Юникод (UTF-8) барои ҳарфҳои тоҷикӣ
                Console.OutputEncoding = System.Text.Encoding.UTF8;
                Console.InputEncoding = System.Text.Encoding.UTF8;

                Console.WriteLine("=== СИСТЕМАИ МУАЙЯНКУНИИ НАТИҶАИ ИМТИҲОН ===");
                Console.WriteLine();

                int score = -1;

                // Ворид кардани балл бо истифода аз int.Parse ва try-catch ё шарти сода
                while (true)
                {
                    Console.Write("Балли гирифтаи донишҷӯро ворид кунед (аз 0 то 100): ");
                    string input = Console.ReadLine();

                    int tempScore;
                    bool isNumber = int.TryParse(input, out tempScore);

                    if (isNumber && tempScore >= 0 && tempScore <= 100)
                    {
                        score = tempScore;
                        break; // Агар балл дуруст бошад, аз сикл мебароем
                    }
                    else
                    {
                        Console.WriteLine("Хатогӣ! Лутфан адади дурустро дар фосилаи аз 0 то 100 ворид кунед.");
                    }
                }

                string resultIfElse = "";
                string resultSwitch = "";

                // 1. Усули истифодаи if-else барои диапазонҳо
                if (score >= 95 && score <= 100)
                {
                    resultIfElse = "4 Аъло (A)";
                }
                else if(score >=90 && score <=94)
                {
                    resultIfElse = "3.67 Аъло (A-)";
                }
                else if (score >= 85 && score <= 89)
                {
                    resultIfElse = "3.33 Хуб (B+)";
                }
                else if (score >= 80 && score <= 84)
                {
                    resultIfElse = "3 Хуб (B)";
                }
                else if (score >= 75 && score <= 79)
                {
                    resultIfElse = "2.67 Хуб (B-)";
                }
                else if (score >= 70 && score <= 74)
                {
                    resultIfElse = "2.33 Қаноатбахш (C+)";
                }
                else if (score >= 65 && score <= 69)
                {
                    resultIfElse = "2 Қаноатбахш (C)";
                }
                else if (score >= 60 && score <= 64)
                {
                    resultIfElse = "1.67 Қаноатбахш (C)";
                }
                else if (score >= 55 && score <= 59)
                {
                    resultIfElse = "1.33 Қаноатбахш (D+)";
                }
                else if (score >= 50 && score <= 54)
                {
                    resultIfElse = "1 Қаноатбахш (D)";
                }
                else
                {
                    resultIfElse = resultIfElse = "0 Ғайри қаноатбахш (D-)";
                }

                // 2. Усули истифодаи switch
             // Делим балл на группы для работы в старых версиях C# (Visual Studio 2013)
                int gradeGroup = score / 5;

                switch (gradeGroup)
                {
                    // 90-100 (группы 20, 19, 18) -> Аъло (A, A-)
                    case 20:
                    case 19:
                    case 18:
                        resultSwitch = "Аъло (Баҳои ҳарфӣ: " + (score >= 95 ? "A,  Эквиваленташ 4" : "A-,  Эквиваленташ 3,67") + ")";
                        break;

                    // 75-89 (группы 17, 16, 15) -> Хуб (B+, B, B-)
                    case 17:
                    case 16:
                    case 15:
                        string bGrade = "B, Эквиваленташ 3 ";
                        if (score >= 85) bGrade = "B+, Эквиваленташ 3.33";
                        else if (score <= 79) bGrade = "B-, Эквиваленташ 2.67";
                        resultSwitch = "Хуб (Баҳои ҳарфӣ: " + bGrade + ")";
                        break;

                    // 61-74 (группы 14, 13, 12) -> Қаноатбахш (C+, C, C-)
                    case 14:
                    case 13:
                    case 12:
                        string cGrade = "C, Эквиваленташ 2";
                        if (score >= 70) cGrade = "C+, Эквиваленташ 2.33";
                        else if (score <= 64) cGrade = "C-, Эквиваленташ 1.67";
                        resultSwitch = "Қаноатбахш (Баҳои ҳарфӣ: " + cGrade + ")";
                        break;

                    // 0-60 -> Ғайриқаноатбахш (D+, D, D-)
                    default:
                        string dGrade = "D-,  Эквиваленташ 0";
                        if (score >= 55) dGrade = "D+, Эквиваленташ 1.33";
                        else if (score >= 50) dGrade = "D, Эквиваленташ 1";
                        resultSwitch = "Ғайриқаноатбахш (Баҳои ҳарфӣ: " + dGrade + ")";
                        break;
                }
                // Барориши натиҷаҳо ба экран
                Console.WriteLine();
                Console.WriteLine("==========================================");
                Console.WriteLine("         НАТИҶАҲОИ ҲИСОБКУНӢ");
                Console.WriteLine("==========================================");
                Console.WriteLine("");
                Console.WriteLine("Балли воридшуда: {0}", score);
                Console.WriteLine("");
                Console.WriteLine("Натиҷа бо усули if-else: Эквиваленташ {0}", resultIfElse);
                Console.WriteLine("");
                Console.WriteLine("Натиҷа бо усули switch:  {0}", resultSwitch);
                Console.WriteLine("");
                Console.WriteLine("==========================================");

                // Интизории пахши тугма
                Console.WriteLine("\nБарои баромадан дилхоҳ тугмаро пахш кунед...");
                Console.ReadKey();
            }
        }
    }
}
