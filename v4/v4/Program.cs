using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace v4
{
    using System;

    namespace SalaryCalculatorSystem
    {
        internal class Program
        {
            // Методи асосӣ (Main), ки иҷрои барнома аз он оғоз меёбад
            static void Main(string[] args)
            {
                // Фаъол кардани Юникод (UTF-8) барои ҳарфҳои тоҷикӣ
                Console.OutputEncoding = System.Text.Encoding.UTF8;
                Console.InputEncoding = System.Text.Encoding.UTF8;

                Console.WriteLine("=== СИСТЕМАИ ҲИСОБКУНИИ МАОШ ===");
                Console.WriteLine();

                // 1. Қабули шумораи соатҳои корӣ бо санҷиши бехатарӣ
                double hoursWorked = ReadPositiveDouble("Шумораи соатҳои кории моҳонаро ворид кунед: ");

                // 2. Қабули нархи як соат бо санҷиши бехатарӣ
                double hourlyRate = ReadPositiveDouble("Нархи як соати корро ворид кунед (сомонӣ/доллар): ");

                // 3. Муайян кардани меъёри муқаррарӣ (масалан, 160 соат дар як моҳ)
                const double standardHours = 160.0;
                // Коэффисиенти маоши иловагӣ барои соатҳои зиёда аз меъёр (масалан, 1.5 баробар)
                const double overtimeMultiplier = 1.5;

                // 4. Ҳисобкунии маош тавассути методи алоҳида
                double totalSalary = CalculateTotalSalary(hoursWorked, hourlyRate, standardHours, overtimeMultiplier);
                double baseSalary = Math.Min(hoursWorked, standardHours) * hourlyRate;
                double overtimeSalary = totalSalary - baseSalary;

                // 5. Барориши натиҷаҳо ба экран
                Console.WriteLine();
                Console.WriteLine("==========================================");
                Console.WriteLine("           ҲИСОБОТИ МАОШИ КОРМАНД");
                Console.WriteLine("==========================================");
                Console.WriteLine("Соатҳои кории иҷрошуда:  {0} соат", hoursWorked);
                Console.WriteLine("Нархи муқаррарии 1 соат: {0}", hourlyRate);
                Console.WriteLine("Маоши асосӣ (меъёр):    {0:F2}", baseSalary);
                Console.WriteLine("Маоши иловагӣ (зиёд):   {0:F2}", overtimeSalary);
                Console.WriteLine("------------------------------------------");
                Console.WriteLine("МАОШИ УМУМӢ БА ГИРИФТАН:  {0:F2}", totalSalary);
                Console.WriteLine("==========================================");

                // Интизории пахши тугма пеш аз бастани консол
                Console.WriteLine("\nБарои баромадан дилхоҳ тугмаро пахш кунед...");
                Console.ReadKey();
            }

            // Методи ёрирасон барои бехатар хондани ададҳои мусбат
            static double ReadPositiveDouble(string prompt)
            {
                double value;
                while (true)
                {
                    Console.Write(prompt);
                    string input = Console.ReadLine();

                    if (double.TryParse(input, out value) && value >= 0)
                    {
                        break;
                    }
                    Console.WriteLine("Хатогӣ! Лутфан адади мусбати дуруст ворид кунед.");
                }
                return value;
            }

            // МЕТОДИ АЛОҲИДА БАРОИ ҲИСОБ КАРДАНИ МАОШИ УМУМӢ (бо дарназардошти соатҳои зиёда аз меъёр)
            static double CalculateTotalSalary(double hours, double rate, double standardLimit, double multiplier)
            {
                double normalHours;
                double overtimeHours = 0;

                // Тақсим кардани соатҳо ба меъёрӣ ва иловагӣ (зиёда аз меъёр)
                if (hours > standardLimit)
                {
                    normalHours = standardLimit;
                    overtimeHours = hours - standardLimit;
                }
                else
                {
                    normalHours = hours;
                }

                // Ҳисоби маоши асосӣ ва маоши иловагӣ бо ضand (multiplier)
                double normalPay = normalHours * rate;
                double overtimePay = overtimeHours * rate * multiplier;

                // Ҷамъи маоши умумӣ
                return normalPay + overtimePay;
            }
        }
    }
}
