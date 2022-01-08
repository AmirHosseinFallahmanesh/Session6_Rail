using System;
using System.Collections.Generic;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> students = new List<string>();

            while (true)
            {
                menu();
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        addStudent(ref students);
                        break;

                    case "2":
                        editStudent(ref students);
                        break;

                    case "3":
                        deleteStudent(ref students);
                        break;

                    case "4":
                        printStudents(students);

                        break;
                    case "5":
                        searchStudents(students);
                        break;

                    case "6":

                        return;

                    default:
                        Console.WriteLine("Input Invalid Try Again");
                        Console.ReadKey();
                        break;
                }


            }
        }

        static void searchStudents(List<string> students)
        {
            Console.Clear();
            Console.WriteLine("Search Student Page");
            Console.WriteLine("_________________________________");
            Console.WriteLine();
            Console.WriteLine("Enter Surname");
            string surname = Console.ReadLine();
            foreach (var item in students)
            {
                string[] data= item.Split(",");
                if (data[1].StartsWith(surname))
                {
                    if (studentExist(item))
                    {

                        Console.WriteLine($"Name : {data[0]}");
                        Console.WriteLine($"SurName : {data[1]}");
                        Console.WriteLine($"Age : {data[2]}");
                        Console.WriteLine("************************");
                    }
                }
            }
            Console.ReadKey();

        }

        static void menu()
        {
            Console.Clear();
            Console.WriteLine("1)Add Student");
            Console.WriteLine("2)Edit Student");
            Console.WriteLine("3)Delete Student");
            Console.WriteLine("4)Print Students");
            Console.WriteLine("5)Search Students");
            Console.WriteLine("6)Exit");
        }
            
        static void addStudent(ref List<string> students)
        {
            Console.Clear();
            Console.WriteLine("Add Student Page");
            Console.WriteLine("_________________________________");
            Console.WriteLine();
            Console.WriteLine("Enter Name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Surname");
            string surname = Console.ReadLine();
            Console.WriteLine("Enter Age");
            string age = Console.ReadLine();
            string format = studentFormatter(name, surname, age, true);
            students.Add(format);
            Console.WriteLine("Student Added Successfully");
            Console.ReadKey();

        }

        static void editStudent(ref List<string> students)
        {
            Console.Clear();
            Console.WriteLine("Edit Student Page");
            Console.WriteLine("_________________________________");
            Console.WriteLine();
            Console.WriteLine("Enter Surname");
            string search = Console.ReadLine();
            int index=findStudent(students, search);
            if (index>-1)
            {
                Console.WriteLine("Enter New Name");
                string name = Console.ReadLine();
                Console.WriteLine("Enter New Surname");
                string surname = Console.ReadLine();
                Console.WriteLine("Enter New Age");
                string age = Console.ReadLine();
                string format = studentFormatter(name, surname, age, true);
                students[index] = format;
                Console.WriteLine("Edit Student Successfully");
            }
            else
            {
                Console.WriteLine("Student Not Found");
                
            }
            Console.ReadKey();
        }


        static void deleteStudent(ref List<string> students)
        {
            Console.Clear();
            Console.WriteLine("Delete Student Page");
            Console.WriteLine("_________________________________");
            Console.WriteLine();
            Console.WriteLine("Enter Surname");
            string search = Console.ReadLine();
            int index = findStudent(students, search);
            if (index>-1)
            {
                string[] data = students[index].Split(",");
                string format = studentFormatter(data[0], data[1], data[2], false);
                students[index] = format;
                Console.WriteLine("Delete Student Successfully");
            }
            else
            {
                Console.WriteLine("Student Not Found");
            }
           
        Console.ReadKey();



        }

        static void printStudents(List<string> students)
        {
            Console.Clear();
            Console.WriteLine("Print Student Page");
            Console.WriteLine("_________________________________");
            Console.WriteLine();

            foreach (string item in students)
            {
                if (studentExist(item))
                {
                    string[] data = item.Split(",");
                    Console.WriteLine($"Name : {data[0]}");
                    Console.WriteLine($"SurName : {data[1]}");
                    Console.WriteLine($"Age : {data[2]}");
                    Console.WriteLine("************************");
                } 
            }
            Console.ReadKey();
        }

        static string studentFormatter(string name,string surname,string age,bool isAlive)
        {
            string format = name + "," + surname + "," + age;
            if (isAlive)
            {
                format += ",1";
            }
            else
            {
                format += ",0";
            }
            return format;
        }
       
        static int findStudent( List<string> students,string surname)
        {
            int index = -1;
            for (int i = 0; i < students.Count; i++)
            {
               string[] data= students[i].Split(",");
                if (data[3]=="1")
                {
                    if (data[1] == surname)
                    {
                        index = i;
                    }
                }
                
            }

            return index;
        }

        static bool studentExist(string studentFormat)
        {

          return  studentFormat.Split(",")[3] == "1";


        }
    }
}
