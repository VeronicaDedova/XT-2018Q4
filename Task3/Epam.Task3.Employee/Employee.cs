using System;

namespace Epam.Task3.Employee
{
    public class Employee : User.User
    {
        private int workExperience;
        private string position;

        public Employee() : base()
        {
            this.WorkExperience = 0;
            this.Position = "Not an employee";
        }

        public Employee(string surname, string firstname, string patronymic, DateTime birthday, string position, int workExperience) : base(surname, firstname, patronymic, birthday)
        {
            if (workExperience >= this.Age - 14)
            {
                throw new ArgumentException("Incorrect value of work experience.");
            }
            else
            {
                this.WorkExperience = workExperience;
            }
            
            this.Position = position;
        }

        public int WorkExperience
        {
            get => this.workExperience;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Value must be positive.");
                }
                else
                {
                    this.workExperience = value;
                }
            }
        }

        public string Position
        {
            get => this.position;
            set
            {
                if ((value.Length == 0) || (value.Trim() == string.Empty))
                {
                    throw new Exception("Incorrect patronymic.");
                }
                else
                {
                    this.position = value;
                }
            }
        }

        public new void Create()
        {
            do
            {
                try
                {
                    Console.Write($"{Environment.NewLine}Enter the surname of the employee: ");
                    string surname = Console.ReadLine();
                    Console.Write("firstname: ");
                    string firstname = Console.ReadLine();
                    Console.Write("patronomic: ");
                    string patronymic = Console.ReadLine();
                    Console.Write("Date of birth (dd.mm.yyyy): ");
                    DateTime birthday = DateTime.Parse(Console.ReadLine());
                    Console.Write("Enter the employee position: ");
                    string position = Console.ReadLine();
                    Console.Write("Enter the work experience: ");
                    string sworkExperience = Console.ReadLine();
                    if (int.TryParse(sworkExperience, out int workExperience))
                    {
                        var employee = new Employee(surname, firstname, patronymic, birthday, position, this.workExperience);
                        employee.Show();
                    }
                    else
                    {
                        Console.WriteLine("Incorect input");
                    }

                    Console.WriteLine("Enter another user? (y/n) ");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Enter another user? (y/n) ");
                }
            }
            while (Console.ReadKey().Key == ConsoleKey.Y);
        }

        public new void Show()
        {            
            Console.WriteLine("====================");
            Console.WriteLine($"Full name: {this.Surname} {this.Firstname} {this.Patronymic}");
            Console.WriteLine("Date of birth: {0:D}", this.Birthday);
            Console.WriteLine($"Age: {this.Age}");
            Console.WriteLine($"Employee position: {this.Position}");
            Console.WriteLine($"Work experience: {this.WorkExperience}");
            Console.WriteLine("====================");
        }
    }
}
