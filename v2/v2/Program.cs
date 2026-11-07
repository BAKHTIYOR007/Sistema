using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace v2
{
    namespace AdvancedCalculator
    {
        internal class Program
        {
            static void Main(string[] args)
            {
                // Фаъол кардани Юникод (UTF-8) барои дуруст баромадани аломатҳо ва матн
                Console.OutputEncoding = System.Text.Encoding.UTF8;
                Console.InputEncoding = System.Text.Encoding.UTF8;

                Console.WriteLine("=== КАЛКУЛЯТОРИ МУКАММАЛ ===");
                Console.WriteLine();

                // Қабули адади якум бо санҷиши дурустии воридот
                double num1;
                Console.Write("Адади якумро ворид кунед: ");
                while (!double.TryParse(Console.ReadLine(), out num1))
                {
                    Console.WriteLine("Хатогӣ! Лутфан адади дуруст ворид кунед.");
                    Console.Write("Адади якумро аз нав ворид кунед: ");
                }

                // Қабули амали арифметикӣ
                Console.Write("Амали арифметикиро ворид кунед (+, -, *, /, %): ");
                char operation = Console.ReadKey().KeyChar;
                Console.WriteLine(); // Барои гузаштан ба сатри нав пас аз пахши тугма

                // Қабули адади дуюм бо санҷиши дурустии воридот
                double num2;
                Console.Write("Адади дуюмро ворид кунед: ");
                while (!double.TryParse(Console.ReadLine(), out num2))
                {
                    Console.WriteLine("Хатогӣ! Лутфан адади дуруст ворид кунед.");
                    Console.Write("Адади дуюмро аз нав ворид кунед: ");
                }

                double result = 0;
                bool isValidOperation = true;

                // Иҷрои амали ҳисобкунӣ бо сохтори switch-case
                switch (operation)
                {
                    case '+':
                        result = num1 + num2;
                        break;
                    case '-':
                        result = num1 - num2;
                        break;
                    case '*':
                        result = num1 * num2;
                        break;
                    case '/':
                        // Санҷиши тақсим ба сифр
                        if (num2 == 0)
                        {
                            Console.WriteLine("Хатогӣ: Тақсим кардан ба сифр мумкин нест!");
                            isValidOperation = false;
                        }
                        else
                        {
                            result = num1 / num2;
                        }
                        break;
                    case '%':
                        // Санҷиши тақсими боқимонда ба сифр
                        if (num2 == 0)
                        {
                            Console.WriteLine("Хатогӣ: Ёфтани боқимонда бо сифр мумкин нест!");
                            isValidOperation = false;
                        }
                        else
                        {
                            result = num1 % num2;
                        }
                        break;
                    default:
                        Console.WriteLine("Хатогӣ: Амали нодуруст интихоб карда шуд!");
                        isValidOperation = false;
                        break;
                }

                // Агар амал дуруст иҷро шуда бошад, натиҷаро чоп мекунем
                if (isValidOperation)
                {
                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine("Натиҷа: {0} {1} {2} = {3}", num1, operation, num2, result);
                    Console.WriteLine("-----------------------------------");
                }

                // Интизории пахши тугма пеш аз бастани консол
                Console.WriteLine("\nБарои баромадан дилхоҳ тугмаро пахш кунед...");
                Console.ReadKey();
            }
        }
    }
}
