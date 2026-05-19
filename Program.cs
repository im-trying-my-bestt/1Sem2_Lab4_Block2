using System;
using System.Text;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace struct_lab_student
{
    partial class Program
    {
        static Student[] ReadData(string fileName)
        {
            string[] rows = File.ReadAllLines(fileName, Encoding.UTF8);
            
            Student[] students = new Student[rows.Length];
            
            for(int i = 0;i<rows.Length;i++)
                students[i] = new Student(rows[i]);
            
            return students;            
        }

        static void RunMenu(Student[] studs)
        {
            Var7(studs);
        }

        public static void Var7(Student[] studs)
        {
            Console.WriteLine("Виконуємо варіант 7:\nДля студентів, що мають хоча б одну незадовільну оцінку або неявку, замінити (у файл\r\ndata_new.txt) величину стипендії на нуль. Ніяких інших змін у дані не вносити.)");
            int count = 0;
            for (int i = 0; i < studs.Length; i++)
                if ((studs[i].mathematicsMark == '2' || studs[i].mathematicsMark == '-' || studs[i].physicsMark == '2' || studs[i].physicsMark == '-' || studs[i].informaticsMark == '2' || studs[i].informaticsMark == '-') && studs[i].scholarship != 0)
                {
                    studs[i].scholarship = 0;
                    count++;
                }
            
            using (var writer = new StreamWriter("data_new.txt", false, Encoding.UTF8))
            {
                foreach (Student s in studs)
                {
                    writer.WriteLine($"{s.surName} {s.firstName} {s.patronymic} {s.gender} {s.dateOfBirth} {s.mathematicsMark} {s.physicsMark} {s.informaticsMark} {s.scholarship}");
                }
            }
            Console.WriteLine($"Варіант виконано. Перегляньте результат у файлі data_new.txt.\n" + (count > 0 ? $"{count} студентів більше не отримують стипендію" : "Ніхто не перестав отримувати степендію."));
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            string fileName = "";
            Console.WriteLine("Лабораторна робота №4\nБлок 2.");
            do
            {
                Console.WriteLine("Введіть назву файлу з якого читатимемо перелік студентів.\nЯкщо хочете використати дані за замовчуванням (input.txt) - натисніть Enter");
                string input = Console.ReadLine();
                fileName = (input == "") ? "input.txt" : input;
            
                if (File.Exists(fileName))
                {
                    Student[] studs = ReadData(fileName);
                    Console.WriteLine($"Прочитано: {studs.Length} студентів.\n");
                    RunMenu(studs);
            
                }
                else
                {
                    Console.WriteLine($"Файл з назвою {fileName} не існує. Спробуйте знову.");
                }
            } while (!File.Exists(fileName));
        }
    }
}
