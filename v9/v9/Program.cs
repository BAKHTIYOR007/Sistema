using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace v9
{
    using System;
    using System.Collections.Generic;

    namespace SimpleBankingSystem
    {
        // Синфи BankAccount ки принсипи инкапсулятсияро амалӣ мекунад
        public class BankAccount
        {
            // Инкапсулятсия: майдони баланс 'private' аст, то аз берун бевосита тағйир дода нашавад
            private double balance;

            public string AccountHolder { get; set; }
            public string AccountNumber { get; set; }

            // Конструктор барои кушодани ҳисоби бонкӣ
            public BankAccount(string accountHolder, string accountNumber, double initialBalance)
            {
                AccountHolder = accountHolder;
                AccountNumber = accountNumber;

                if (initialBalance >= 0)
                {
                    balance = initialBalance;
                }
                else
                {
                    balance = 0;
                    Console.WriteLine("Маблағи ибтидоӣ манфӣ буда наметавонад. Баланс 0 гузошта шуд.");
                }
            }

            // Методи гузоштани маблағ ба ҳисоб (Deposit)
            public void Deposit(double amount)
            {
                if (amount > 0)
                {
                    balance += amount;
                    Console.WriteLine("Ба ҳисоб {0} сомонӣ бомуваффақият илова шуд.", amount);
                }
                else
                {
                    Console.WriteLine("Хатогӣ! Маблағи гузоришшаванда бояд аз сифр зиёд бошад.");
                }
            }

            // Методи гирифтани маблағ аз ҳисоб (Withdraw) бо санҷиши маблағи кофӣ
            public bool Withdraw(double amount)
            {
                if (amount <= 0)
                {
                    Console.WriteLine("Хатогӣ! Маблағи гирифташаванда бояд аз сифр зиёд бошад.");
                    return false;
                }

                // Санҷиши маблағи кофӣ дар ҳисоб
                if (HasEnoughBalance(amount))
                {
                    balance -= amount;
                    Console.WriteLine("Аз ҳисоб {0} сомонӣ бомуваффақият гирифта шуд.", amount);
                    return true;
                }
                else
                {
                    Console.WriteLine("Хатогӣ! Маблағи дар ҳисоб буда кофӣ нест. Баланси ҷорӣ: {0} сомонӣ.", balance);
                    return false;
                }
            }

            // Методи санҷиши маблағи кофӣ
            public bool HasEnoughBalance(double amount)
            {
                return balance >= amount;
            }

            // Методи дидани баланс (Get Balance)
            public double GetBalance()
            {
                return balance;
            }

            // Методи баровардани маълумоти ҳисоб
            public void DisplayAccountInfo()
            {
                Console.WriteLine("Рақами ҳисоб: {0}", AccountNumber);
                Console.WriteLine("Соҳиби ҳисоб: {0}", AccountHolder);
                Console.WriteLine("Баланси ҷорӣ: {0:F2} сомонӣ", balance);
                Console.WriteLine("------------------------------------------");
            }
        }

        internal class Program
        {
            static void Main(string[] args)
            {
                // Фаъол кардани Юникод (UTF-8) барои ҳарфҳои тоҷикӣ
                Console.OutputEncoding = System.Text.Encoding.UTF8;
                Console.InputEncoding = System.Text.Encoding.UTF8;

                // Рӯйхати ҳисобҳои бонкӣ дар система
                List<BankAccount> accounts = new List<BankAccount>();

                bool running = true;

                while (running)
                {
                    Console.Clear();
                    Console.WriteLine("==========================================");
                    Console.WriteLine("         СИСТЕМАИ БОНКӢ (БАНКОМАТ)");
                    Console.WriteLine("==========================================");
                    Console.WriteLine("1. Кушодани ҳисоби нави бонкӣ");
                    Console.WriteLine("2. Дидани баланси ҳисоб");
                    Console.WriteLine("3. Гузоштани маблағ ба ҳисоб");
                    Console.WriteLine("4. Гирифтани маблағ аз ҳисоб");
                    Console.WriteLine("5. Нишон додани ҳамаи ҳисобҳо");
                    Console.WriteLine("6. Баромадан аз барнома");
                    Console.WriteLine("==========================================");
                    Console.Write("Амалиёти лозимиро интихоб кунед (1-6): ");

                    string choice = Console.ReadLine();
                    Console.WriteLine();

                    switch (choice)
                    {
                        case "1":
                            // Кушодани ҳисоби нав
                            Console.Write("Ному насаби соҳиби ҳисоб: ");
                            string holder = Console.ReadLine().Trim();

                            Console.Write("Рақами ҳисоб (масалан, ACC001): ");
                            string accNumber = Console.ReadLine().Trim();

                            double initBalance = 0;
                            while (true)
                            {
                                Console.Write("Маблағи ибтидоӣ ба ҳисоб: ");
                                string balanceInput = Console.ReadLine();
                                if (double.TryParse(balanceInput, out initBalance) && initBalance >= 0)
                                {
                                    break;
                                }
                                Console.WriteLine("Хатогӣ! Маблағи нодуруст ворид шуд.");
                            }

                            BankAccount newAcc = new BankAccount(holder, accNumber, initBalance);
                            accounts.Add(newAcc);
                            Console.WriteLine("Ҳисоби бонкӣ бомуваффақият кушода шуд!");
                            break;

                        case "2":
                        case "3":
                        case "4":
                            // Амалиётҳо бо ҳисоби мушаххас (Интихоби ҳисоб)
                            if (accounts.Count == 0)
                            {
                                Console.WriteLine("Дар система ягон ҳисоби бонкӣ мавҷуд нест. Аввал ҳисоб кушоед!");
                                break;
                            }

                            Console.WriteLine("Рӯйхати ҳисобҳо:");
                            for (int i = 0; i < accounts.Count; i++)
                            {
                                Console.WriteLine("{0}. Рақам: {1} | Соҳиб: {2} | Баланс: {3:F2}",
                                    i + 1, accounts[i].AccountNumber, accounts[i].AccountHolder, accounts[i].GetBalance());
                            }

                            Console.Write("Рақами тартибии ҳисобро интихоб кунед: ");
                            string indexInput = Console.ReadLine();
                            int accIndex;

                            if (int.TryParse(indexInput, out accIndex) && accIndex >= 1 && accIndex <= accounts.Count)
                            {
                                BankAccount selectedAcc = accounts[accIndex - 1];

                                if (choice == "2")
                                {
                                    // Дидани баланс
                                    selectedAcc.DisplayAccountInfo();
                                }
                                else if (choice == "3")
                                {
                                    // Гузоштани маблағ
                                    double depAmount = 0;
                                    while (true)
                                    {
                                        Console.Write("Маблағро барои гузоштан ворид кунед: ");
                                        string depInput = Console.ReadLine();
                                        if (double.TryParse(depInput, out depAmount) && depAmount > 0)
                                        {
                                            break;
                                        }
                                        Console.WriteLine("Хатогӣ! Маблағи мусбат ворид кунед.");
                                    }
                                    selectedAcc.Deposit(depAmount);
                                }
                                else if (choice == "4")
                                {
                                    // Гирифтани маблағ
                                    double withAmount = 0;
                                    while (true)
                                    {
                                        Console.Write("Маблағро барои гирифтан ворид кунед: ");
                                        string withInput = Console.ReadLine();
                                        if (double.TryParse(withInput, out withAmount) && withAmount > 0)
                                        {
                                            break;
                                        }
                                        Console.WriteLine("Хатогӣ! Маблағи мусбат ворид кунед.");
                                    }
                                    selectedAcc.Withdraw(withAmount);
                                }
                            }
                            else
                            {
                                Console.WriteLine("Хатогӣ! Рақами ҳисоб нодуруст интихоб шуд.");
                            }
                            break;

                        case "5":
                            // Нишон додани ҳамаи ҳисобҳо
                            Console.WriteLine("--- ҲАМАИ ҲИСОБҲОИ БОНКӢ ---");
                            if (accounts.Count == 0)
                            {
                                Console.WriteLine("Ҳисобҳо мавҷуд нестанд.");
                            }
                            else
                            {
                                for (int i = 0; i < accounts.Count; i++)
                                {
                                    accounts[i].DisplayAccountInfo();
                                }
                            }
                            break;

                        case "6":
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