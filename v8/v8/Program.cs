using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace v8
{
using System.Collections.Generic; // Барои истифодаи List зарур аст

namespace StudentOOPSystem
{
    // Синфи (Class) Student бо принсипҳои ООП
    public class Student
    {
        // Полеҳо ва Пропертиҳо (Properties)
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public List<int> Grades { get; set; }

        // Конструктор (Constructor) барои сохтани объекти донишҷӯ
        public Student(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Grades = new List<int>(); // Эҷоди рӯйхати холӣ барои баҳоҳо
        }

        // Методи илова кардани баҳо ба донишҷӯ
        public void AddGrade(int grade)
        {
            Grades.Add(grade);
        }

        // МЕТОД: Ҳисоб кардани баҳои миёнаи донишҷӯ
        public double GetAverageGrade()
        {
            if (Grades.Count == 0)
            {
                return 0.0; // Агар баҳо надошта бошад, миёна 0 аст
            }

            int sum = 0;
            foreach (int grade in Grades)
            {
                sum += grade;
            }

            return (double)sum / Grades.Count;
        }

        // Методи махсус барои бароваrдани маълумоти донишҷӯ
        public void DisplayStudentInfo()
        {
            Console.WriteLine("Ному насаб: {0} {1}", FirstName, LastName);
            Console.WriteLine("Синну сол: {0}", Age);
            Console.WriteLine("Баллҳо / Баҳоҳо: {0}", Grades.Count > 0 ? string.Join(", ", Grades) : "Баҳогузорӣ нашудааст");
            Console.WriteLine("Балли миёна: {0:F2}", GetAverageGrade());
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

            // Рӯйхати умумии донишҷӯён дар система
            List<Student> studentsList = new List<Student>();

            bool running = true;

            while (running)
            {
                Console.Clear();
                Console.WriteLine("==========================================");
                Console.WriteLine("    СИСТЕМАИ ИДОРАКУНИИ ДОНИШҶӮЁН (ООП)");
                Console.WriteLine("==========================================");
                Console.WriteLine("1. Нишон додани ҳамаи донишҷӯён");
                Console.WriteLine("2. Илова кардани донишҷӯи нав");
                Console.WriteLine("3. Илова кардани баҳо ба донишҷӯ");
                Console.WriteLine("4. Баромадан аз барнома");
                Console.WriteLine("==========================================");
                Console.Write("Амалиёти лозимиро интихоб кунед (1-4): ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        // Нишон додани ҳамаи донишҷӯён
                        Console.WriteLine("--- РӮЙХАТИ ДОНИШҶӮЁН ---");
                        if (studentsList.Count == 0)
                        {
                            Console.WriteLine("Дар система ягон донишҷӯ сабт нашудааст.");
                        }
                        else
                        {
                            for (int i = 0; i < studentsList.Count; i++)
                            {
                                Console.WriteLine("Донишҷӯ №{0}:", i + 1);
                                studentsList[i].DisplayStudentInfo();
                            }
                        }
                        break;
                          case "2":
                        // Илова кардани донишҷӯи нав бо Конструктор
                        Console.Write("Номи донишҷӯро ворид кунед: ");
                        string fName = Console.ReadLine().Trim();

                        Console.Write("Насаби донишҷӯро ворид кунед: ");
                        string lName = Console.ReadLine().Trim();

                        int studentAge = 0;
                        while (true)
                        {
                            Console.Write("Синну соли донишҷӯро ворид кунед: ");
                            string ageInput = Console.ReadLine();
                            if (int.TryParse(ageInput, out studentAge) && studentAge > 10 && studentAge < 100)
                            {
                                break;
                            }
                            Console.WriteLine("Хатогӣ! Синну соли нодуруст ворид шуд.");
                        }

                        // Истифодаи Конструктор барои сохтани объекти нав
                        Student newStudent = new Student(fName, lName, studentAge);
                        studentsList.Add(newStudent);

                        Console.WriteLine("Донишҷӯ бомуваффақият илова карда шуд!");
                        break;

                    case "3":
                        // Илова кардани баҳо ба донишҷӯи мушаххас
                        if (studentsList.Count == 0)
                        {
                            Console.WriteLine("Аввал бояд донишҷӯ илова кунед!");
                            break;
                        }

                        Console.WriteLine("Рӯйхати донишҷӯён:");
                        for (int i = 0; i < studentsList.Count; i++)
                        {
                            Console.WriteLine("{0}. {1} {2}", i + 1, studentsList[i].FirstName, studentsList[i].LastName);
                        }

                        Console.Write("Рақами донишҷӯро интихоб кунед: ");
                        string indexInput = Console.ReadLine();
                        int studentIndex;

                        if (int.TryParse(indexInput, out studentIndex) && studentIndex >= 1 && studentIndex <= studentsList.Count)
                        {
                            int grade;
                            while (true)
                            {
                                Console.Write("Балл/Баҳои навро ворид кунед (аз 0 то 100): ");
                                string gradeInput = Console.ReadLine();
                                if (int.TryParse(gradeInput, out grade) && grade >= 0 && grade <= 100)
                                {
                                    break;
                                }
                                Console.WriteLine("Хатогӣ! Баҳо бояд байни 0 ва 100 бошад.");
                            }

                            // Даъвати методи илова кардани баҳо
                            studentsList[studentIndex - 1].AddGrade(grade);
                            Console.WriteLine("Баҳо бомуваффақият илова карда шуд!");
                        }
                        else
                        {
                            Console.WriteLine("Хатогӣ! Рақами нодуруст интихоб шуд.");
                        }
                        break;

                    case "4":
                        running = false;
                        Console.WriteLine("Барнома ба анҷом расид. Хайр!");
                        break;

                    default:
                        Console.WriteLine("Хатогӣ! Лутфан рақами дурустро аз 1 то 4 интихоб кунед.");
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
