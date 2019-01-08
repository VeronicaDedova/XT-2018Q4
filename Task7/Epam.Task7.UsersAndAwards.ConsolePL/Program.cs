using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Task7.UsersAndAwards.BLL.Interface;
using Epam.Task7.UsersAndAwards.Common;
using Epam.Task7.UsersAndAwards.Entities;

namespace Epam.Task7.UsersAndAwards.ConsolePL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var userLogic = DependencyResolver.UserLogic;
            Console.WriteLine($"This application allows you to work with a list of users. What do you want to do? {Environment.NewLine}Enter the appropriate number + 'enter'");
            do
            {
                Console.WriteLine($"1.Add user.{Environment.NewLine}2.Delete user.{Environment.NewLine}3.View user by id.{Environment.NewLine}4.View all users{Environment.NewLine}Press any other key to quit");
                var key = Console.ReadKey().Key;
                if (key == ConsoleKey.D1)
                {
                    do
                    {
                        AddUser(userLogic);
                        Console.WriteLine("Add another user? (y/n)");
                    }
                    while (Console.ReadKey().Key == ConsoleKey.Y);
                }
                else if (key == ConsoleKey.D2)
                {
                    do
                    {
                        DeleteUser(userLogic);
                        Console.WriteLine("Delete another user? (y/n)");
                    }
                    while (Console.ReadKey().Key == ConsoleKey.Y);
                }
                else if (key == ConsoleKey.D3)
                {
                    do
                    {
                        ShowUserByID(userLogic);
                        Console.WriteLine("View another id? (y/n)");
                    }
                    while (Console.ReadKey().Key == ConsoleKey.Y);
                }
                else if (key == ConsoleKey.D4)
                {
                    ShowUsers(userLogic);
                }                

                Console.WriteLine("Do another action with users? (y/n)");
            }
            while (Console.ReadKey().Key == ConsoleKey.Y);
        }

        private static void AddUser(IRepositoryLogic<User> userLogic)
        {
            Console.WriteLine("Enter the information about user.");
            Console.Write("First name: ");
            string firstName = Console.ReadLine();
            Console.Write("Last name: ");
            string lastName = Console.ReadLine();
            Console.Write("Patronymic: ");
            string patronymic = Console.ReadLine();
            Console.Write("Date of birth: ");
            DateTime dateOfBirth = DateTime.Parse(Console.ReadLine());

            var user = new User(firstName, lastName, patronymic, dateOfBirth);

            userLogic.Add(user);
        }

        private static void DeleteUser(IRepositoryLogic<User> userLogic)
        {
            Console.WriteLine("Enter ID deleted user.");
            int id = int.Parse(Console.ReadLine());
            userLogic.Delete(id);
        }

        // private static void UpdateUser(IRepositoryLogic<User> userLogic)
        // {
        //     userLogic.Update(user);
        // }
        private static void ShowUserByID(IRepositoryLogic<User> userLogic)
        {
            Console.WriteLine("Enter user ID.");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine(userLogic.GetById(id));
        }

        private static void ShowUsers(IRepositoryLogic<User> userLogic)
        {
            // Console.WriteLine("Id FirstName LastName Patronymic DateOfBirth Age");
            foreach (var user in userLogic.GetAll())
            {
                Console.WriteLine(user);
            }
        }   
    }
}
