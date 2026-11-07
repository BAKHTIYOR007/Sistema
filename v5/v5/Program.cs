using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace v5
{
    using System;

    namespace ExamAnalysisSystem
    {
        internal class Program
        {
            static void Main(string[] args)
            {
                // Фаъол кардани Юникод (UTF-8) барои ҳарфҳои тоҷикӣ
                Console.OutputEncoding = System.Text.Encoding.UTF8;
                Console.InputEncoding = System.Text.Encoding.UTF8;

                Console.WriteLine("=== СИСТЕМАИ ТАҲЛИЛИ НАТИҶАҲОИ ИМТИҲОН ===");
                Console.WriteLine();

                // Эълони массив барои 20 донишҷӯ
                int totalStudents = 20;
                int[] scores = new int[totalStudents];

                Console.WriteLine("Баллҳои имтиҳони {0} донишҷӯро ворид кунед (аз 0 то 100):", totalStudents);

                // Қабули баллҳои донишҷӯён ба воситаи сикл бо санҷиши бехатарӣ
                for (int i = 0; i < totalStudents; i++)
                {
                    while (true)
                    {
                        Console.Write("Балли донишҷӯи {0}: ", i + 1);
                        string input = Console.ReadLine();
                        int tempScore;

                        if (int.TryParse(input, out tempScore) && tempScore >= 0 && tempScore <= 100)
                        {
                            scores[i] = tempScore;
                            break;
                        }
                        Console.WriteLine("Хатогӣ! Лутфан балли дурустро дар фосилаи аз 0 то 100 ворид кунед.");
                    }
                }

                // Тағйирёбандаҳо барои ҳисобкуниҳо
                int sum = 0;
                int maxScore = scores[0];
                int minScore = scores[0];
                int passedCount = 0; // Гузаштаҳо (масалан, балли >= 50)
                int failedCount = 0; // Нагузаштаҳо (балли < 50)
                int passingGrade = 50; // Меъёри гузариш

                // Коркарди массив бо сикли for
                for (int i = 0; i < totalStudents; i++)
                {
                    int current = scores[i];
                    sum += current;

                    // Ёфтани баландтарин балл
                    if (current > maxScore)
                    {
                        maxScore = current;
                    }

                    // Ёфтани пасттарин балл
                    if (current < minScore)
                    {
                        minScore = current;
                    }

                    // Шумораи гузаштагон ва нагузаштагон
                    if (current >= passingGrade)
                    {
                        passedCount++;
                    }
                    else
                    {
                        failedCount++;
                    }
                }

                // Ҳисоби баҳои миёна
                double averageScore = (double)sum / totalStudents;

                // Барориши натиҷаҳо ба экран
                Console.WriteLine();
                Console.WriteLine("==========================================");
                Console.WriteLine("         ҲИСОБОТИ ТАҲЛИЛИ ИМТИҲОН");
                Console.WriteLine("==========================================");
                Console.WriteLine("Балли миёнаи гурӯҳ:       {0:F2}", averageScore);
                Console.WriteLine("Баландтарин балл:         {0}", maxScore);
                Console.WriteLine("Пасттарин балл:           {0}", minScore);
                Console.WriteLine("Шумораи гузаштагон (>=50): {0}", passedCount);
                Console.WriteLine("Шумораи нагузаштагон (<50): {0}", failedCount);
                Console.WriteLine("==========================================");

                // Интизории пахши тугма
                Console.WriteLine("\nБарои баромадан дилхоҳ тугмаро пахш кунед...");
                Console.ReadKey();
            }
        }
    }
}