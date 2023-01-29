using FiktivSkolaEF.Models;
using System.Linq;
using System.Runtime.ExceptionServices;

namespace FiktivSkolaEF
{
    internal class Program
    {
        static void Main(string[] args)
        {

            WelcomeMsg();
        }


        public static void WelcomeMsg()
        {
            Console.WriteLine("Hi and welcome to the school, what do you want to do?\n1. See all students\n2. See all students in specific class\n3. Add new staff");
            int Userchoice = int.Parse(Console.ReadLine());

            switch (Userchoice)
            {
                case 1:
                    Console.Clear();
                    GetAllStudents();
                    break;
                case 2:
                    Console.Clear();
                    GetStudentsFromSpecificClass();
                    break;
                case 3:
                    Console.Clear();
                    AddNewStaff();
                    break;

            }
        }

        public static void GetAllStudents()
        {
            FiktivSkolaDbContext context = new FiktivSkolaDbContext();
            Console.WriteLine("Would you like to order them by\n1.First name?\n2.Last name?");
            string OrderByChoice = Console.ReadLine().ToUpper();
            Console.Clear();

            Console.WriteLine("Do you want the list to be ordered by\n1.Ascending?\n2.Descending?");
            string OrderAscDesc = Console.ReadLine().ToUpper();
            Console.Clear();

            var StuFName = from student in context.Students
                          orderby student.Fname descending
                          select student;

            var StuFNameDesc = from student in context.Students
                           orderby student.Fname ascending
                           select student;

            var StuLNameAsc = from student in context.Students
                           orderby student.Lname descending
                           select student;

            var StuLNameDesc = from student in context.Students
                           orderby student.Lname ascending
                           select student;

            if (OrderByChoice == "1" && OrderAscDesc == "1")
            {
                foreach (Student item in StuFName)
                {
                    Console.WriteLine($"Name: {item.Fname} {item.Lname}");
                }
            }

            else if (OrderByChoice == "1" && OrderAscDesc == "2")
            {
                foreach (Student item in StuFNameDesc)
                {
                    Console.WriteLine($"Name: {item.Fname} {item.Lname}");
                }
            }

            else if (OrderByChoice == "2" && OrderAscDesc == "1")
            {
                foreach (Student item in StuLNameAsc)
                {
                    Console.WriteLine($"Name: {item.Fname} {item.Lname}");
                }
            }

            else if (OrderByChoice == "2" && OrderAscDesc == "2")
            {
                foreach (Student item in StuLNameDesc)
                {
                    Console.WriteLine($"Name: {item.Fname} {item.Lname}");
                }
            }
            Console.WriteLine("\nPress any key to return to menu.");
            Console.ReadKey();
            Console.Clear();
            WelcomeMsg();
        }

        public static void GetStudentsFromSpecificClass()
        {
            FiktivSkolaDbContext context = new FiktivSkolaDbContext();

            var Class = from student in context.Students
                        orderby student.Class
                        select student;

            Console.WriteLine("From which class would you like to see all students?");
            foreach (Student item in Class)
            {
                Console.WriteLine($"{item.Class}");
            }
            Console.WriteLine();

            string ChoiceOfClass = Console.ReadLine();

            var Claes = context.Students.Where(p => p.Class == ChoiceOfClass);

            foreach (Student item in Claes)
            {
                Console.WriteLine($"Name: {item.Fname} {item.Lname}");
            }
            Console.WriteLine("\nPress any key to return to menu.");
            Console.ReadKey();
            Console.Clear();
            WelcomeMsg();
        }

        public static void AddNewStaff()
        {
            FiktivSkolaDbContext context = new FiktivSkolaDbContext();

            var allstaff = from Staff in context.staff
                           orderby Staff.Fname
                           select Staff;

            Console.WriteLine("What's the new staff members name?");
            string FirstName = Console.ReadLine();

            Console.WriteLine("What's his/hers last name?");
            string LastName = Console.ReadLine();

            Console.WriteLine("What's his/her position?");
            var staffpos = from staffposition in context.StaffPositions
                           orderby staffposition.StaffPosition1
                           select staffposition;

            foreach (StaffPosition item in staffpos)
            {
                Console.WriteLine($"{item.StaffPosition1}");
            }
            Console.WriteLine();
            string Position = Console.ReadLine().ToUpper();
            int PositionInt = 0;
            

            if (Position == "TEACHER")
            {
                PositionInt = 1;
            }

            else if (Position == "JANITOR")
            {
                PositionInt = 2;
            }

            else if (Position == "HEADMASTER")
            {
                PositionInt = 3;
            }

            else if (Position == "OTHER")
            {
                PositionInt = 4;
            }
            else
            {
                Console.WriteLine("Position was not found, press any key to return to menu.");
                Console.ReadKey();
                Console.Clear();
                WelcomeMsg();
            }
            
            Console.WriteLine("Are you sure you would like to add a new staff member? Yes or No.");
            string Sure = Console.ReadLine().ToUpper();
            if (Sure == "YES")
            {
                staff NewStaff = new staff()
                {
                    
                    Fname = FirstName,
                    Lname = LastName,
                    PositionId = PositionInt
                };

                context.staff.Add(NewStaff);
                context.SaveChanges();

                Console.WriteLine("New staff has been added");
                Console.WriteLine("Here are all the staff active at the moment\n");
                foreach  (staff item in allstaff)
                {
                    Console.WriteLine($"Name: {item.Fname} {item.Lname}");
                }
                WelcomeMsg();
            }
            else if (Sure == "NO")
            {
                Console.WriteLine("Press any key to return to menu");
                Console.ReadKey();
                Console.Clear();
                WelcomeMsg();
            }
        }
    }
}