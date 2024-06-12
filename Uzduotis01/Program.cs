using System.Linq;
using System.Data;

namespace Uzduotis01
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<Student> students = new List<Student>
            {
            new Student { Name = "Jonas", Grade = 8, Age = 20 },
            new Student { Name = "Petras", Grade = 5, Age = 22 },
            new Student { Name = "Ona", Grade = 9, Age = 24 },
            new Student { Name = "Rasa", Grade = 7, Age = 26 },
            new Student { Name = "Andrius", Grade = 6, Age = 23 },
            new Student { Name = "Gabija", Grade = 7, Age = 27 }
            };

            Console.WriteLine("\nVisi studentai:");
            foreach (Student it in students)
            {
                Console.WriteLine(it.ToString());
            }

            // Atrinkti sąrašą studentų jaunesnių nei 25 metų, kuriu pazymiai yra 6 arba 9 ir sąrašą surikiuoti didėjimo tvarka pagal pažymius
            List<Student> students25plusGrade6or9 = students.Where(x => x.Age < 25 && (x.Grade == 6 || x.Grade == 9)).OrderBy(x => x.Grade).ToList();
            Console.WriteLine("\nStudentai, kuriu amzius mazesnis nei 25, ir pazymys 6 arba 9.");
            foreach (Student it in students25plusGrade6or9)
            {
                Console.WriteLine(it.ToString());
            }


            //Apskaičiuokite ir išveskite vidutinį visų studentų pažymį.
            double averageMark = Math.Round((from student in students
                                  select student.Grade).Average(), 2);
            Console.WriteLine($"\nVisu studentu pazymiu vidurkis: {averageMark}\n");


            //Raskite didžiausią pažymį
            int maxGrade = students.Max(x => x.Grade);
            Console.WriteLine($"\nDidziausias pazymys: {maxGrade}\n");


            //Raskite mažiausią pažymį
            int minGrade = students.Min(x => x.Grade);
            Console.WriteLine($"\nMaziausias pazymys: {minGrade}\n");


            //Raskite jauniausią ir vyriausią studentą bei išveskite jų vardus ir amžius.
            Student youngestStudent = students.Where(x => x.Age == students.Min(y => y.Age)).First();
            Console.WriteLine($"\nJauniausias studentas: {youngestStudent.Name} {youngestStudent.Age}\n");

            Student oldestStudent = students.Where(x => x.Age == students.Max(y => y.Age)).First();
            Console.WriteLine($"\nVyriausias studentas: {oldestStudent.Name} {oldestStudent.Age}\n");


            //Suskaičiuokite kiek studentų turi pažymį 7
            int studentsWhoHave7 = students.Count(x => x.Grade == 7);
            Console.WriteLine($"\nTiek studentu turi pazymi 7: {studentsWhoHave7}\n");


            // EXTRA: Naudodami LINQ, raskite tris studentus su aukščiausiais pažymiais ir išveskite jų vardus, pažymius ir amžių.
            List<Student> best3Students = students.OrderByDescending(x => x.Grade).Take(3).ToList();

            Console.WriteLine("\nTrys studentai su geriausiais pazymiais: ");
            foreach (Student it in best3Students)
            {
                Console.WriteLine(it.ToString());
            }
        }
    }
    
}