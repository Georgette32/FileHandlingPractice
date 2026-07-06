using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;

namespace FileHandlingPractice
{
    class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Grade { get; set; }
        public Student(int id, string name, double grade)
        {
            this.Id = id;
            this.Name = name;
            this.Grade = grade;
        }





    }

    internal class Program
    {
        static void SaveStudents(List<Student> students)
        {
            List<string> lines = new List<string>();
            foreach (Student s in students)
            {
                string line = $"{s.Id}, {s.Name}, {s.Grade}";
                lines.Add(line);
            }
            File.WriteAllLines("students.txt", lines);
        }
        static List<Student> LoadStudents()
        {
            List<Student> students = new List<Student>();
            string[] lines = File.ReadAllLines("students.txt");
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                int id = int.Parse(parts[0].Trim());
                string name = parts[1].Trim();
                double grade = double.Parse(parts[2].Trim());
                Student s = new Student(id, name, grade);
                students.Add(s);
            }
            return students;
        }

        static void Main(string[] args)
        {

            List<Student> students = new List<Student>
            {
                new Student(1, "Alice", 85.5),
                new Student(2, "Bob", 92.0),
                new Student(3, "Charlie", 78.0),
                new Student(4, "David", 88.5),
                new Student(5, "Eve", 95.0)
            }; 
            SaveStudents(students);
            List<Student> loadedStudents = LoadStudents();
            foreach (Student student in loadedStudents)
            {
                Console.WriteLine($"Id: {student.Id}, Name: {student.Name}, Grade: {student.Grade}");
            }
           
            //  var names = students.Select(e=>e.Name).ToList();
            // File.WriteAllLines("students.txt", names);

            string[] naames = File.ReadAllLines("students.txt");
            foreach (string item in naames)
            {
                Console.WriteLine(item);
            }
            File.AppendAllText("students.txt", "\nFrank");
            if (File.Exists("students.txt"))
            {
                Console.WriteLine("File exists");
                string[] names2 = File.ReadAllLines("students.txt");
                foreach (string item in names2)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("File does not exist");
            }
            Directory.CreateDirectory("Data");
            string path = Path.Combine("Data", "StudentsData.txt");
            File.WriteAllText(path, "This is a test file.");
            Path.GetFileName(path);
            Path.GetExtension(path);
            Path.GetFileNameWithoutExtension(path);
            Console.WriteLine(Path.GetFileName(path));

            Console.WriteLine(Path.GetExtension(path));

            Console.WriteLine(Path.GetFileNameWithoutExtension(path));
            Console.WriteLine(Path.GetFullPath("students.txt"));


            // File.AppendAllText("students.txt", Environment.NewLine + "Georgette");
            // File.ReadAllLines("students.txt").ToList().ForEach(e=>Console.WriteLine(e));
        }
    }
}
