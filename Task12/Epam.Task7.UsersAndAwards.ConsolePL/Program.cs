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
            Console.Clear();
            do
            {
                Console.WriteLine($"{Environment.NewLine}Do you want to work with the list of users or with the list of awards? (1/2)" +
                    $"{Environment.NewLine}1.list of users" +
                    $"{Environment.NewLine}2.list of awards");

                var listOf = Console.ReadKey().Key;
                if (listOf == ConsoleKey.D1)
                {
                    WorkWithUsers();
                }
                else if (listOf == ConsoleKey.D2)
                {
                    WorkWithAwards();
                }

                Console.WriteLine($"{Environment.NewLine}Choose a different mode of operation? (y/n)");
            }
            while (Console.ReadKey().Key == ConsoleKey.Y);
        }

        private static void WorkWithAwards()
        {
            var awardLogic = DependencyResolver.AwardLogic;

            Console.Clear();

            Console.WriteLine($"{Environment.NewLine}This application allows you to work with a list of awards." +
                $"{Environment.NewLine}What do you want to do? " +
                $"{Environment.NewLine}Enter the appropriate number + 'enter'");
            do
            {
                Console.WriteLine($"{Environment.NewLine}1.Add award." +
                    $"{Environment.NewLine}2.Delete award." +
                    $"{Environment.NewLine}3.View award by id." +
                    $"{Environment.NewLine}4.View all awards" +
                    $"{Environment.NewLine}Press any other key to quit");

                var key = Console.ReadKey().Key;
                if (key == ConsoleKey.D1)
                {
                    do
                    {
                        AddAward(awardLogic);
                        Console.WriteLine("Add another award? (y/n)");
                    }
                    while (Console.ReadKey().Key == ConsoleKey.Y);
                }
                else if (key == ConsoleKey.D2)
                {
                    do
                    {
                        DeleteAward(awardLogic);
                        Console.WriteLine("Delete another award? (y/n)");
                    }
                    while (Console.ReadKey().Key == ConsoleKey.Y);
                }
                else if (key == ConsoleKey.D3)
                {
                    do
                    {
                        ShowAwardByID(awardLogic);
                        Console.WriteLine("View another id? (y/n)");
                    }
                    while (Console.ReadKey().Key == ConsoleKey.Y);
                }
                else if (key == ConsoleKey.D4)
                {
                    ShowAwards(awardLogic);
                }

                Console.WriteLine($"{Environment.NewLine}Do another action with users? (y/n)");
            }
            while (Console.ReadKey().Key == ConsoleKey.Y);
        }

        private static void WorkWithUsers()
        {
            var userLogic = DependencyResolver.UserLogic;
            var awardLogic = DependencyResolver.AwardLogic;
            var linkTableLogic = DependencyResolver.LinkTableLogic;

            Console.Clear();

            Console.WriteLine($"{Environment.NewLine}This application allows you to work with a list of users." +
                $"{Environment.NewLine}What do you want to do? " +
                $"{Environment.NewLine}Enter the appropriate number + 'enter'");
            do
            {
                Console.WriteLine($"{Environment.NewLine}1.Add user." +
                    $"{Environment.NewLine}2.Delete user." +
                    $"{Environment.NewLine}3.View user by id." +
                    $"{Environment.NewLine}4.View all users" +
                    $"{Environment.NewLine}5.Give a reward to the user" +
                    $"{Environment.NewLine}6.View all users and their awards" +
                    $"{Environment.NewLine}Press any other key to quit");

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
                else if (key == ConsoleKey.D5)
                {
                    GiveAwardToUser(linkTableLogic, userLogic, awardLogic);
                }
                else if (key == ConsoleKey.D6)
                {
                    ShowUsersAndAwards(linkTableLogic, userLogic, awardLogic);
                }

                Console.WriteLine($"{Environment.NewLine}Do another action with users? (y/n)");
            }
            while (Console.ReadKey().Key == ConsoleKey.Y);
        }

        private static void AddUser(IRepositoryLogic<User> userLogic)
        {
            Console.Clear();

            Console.WriteLine($"{Environment.NewLine}Enter the information about user.");
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
            Console.WriteLine($"{Environment.NewLine}Enter ID deleted user.");
            int id = int.Parse(Console.ReadLine());
            userLogic.Delete(id);
        }

        private static void ShowUserByID(IRepositoryLogic<User> userLogic)
        {
            Console.WriteLine($"{Environment.NewLine}Enter user ID.");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine(userLogic.GetById(id));
        }

        private static void ShowUsers(IRepositoryLogic<User> userLogic)
        {
            Console.WriteLine();
            foreach (var user in userLogic.GetAll())
            {
                Console.WriteLine(user);
            }
        }

        private static void GiveAwardToUser(IRepositoryLogic<LinkTable> linkTableLogic, IRepositoryLogic<User> userLogic, IRepositoryLogic<Award> awardLogic)
        {
            Console.Clear();

            var userAward = new LinkTable();

            ShowUsers(userLogic);

            do
            {
                Console.WriteLine($"{Environment.NewLine}Enter the ID of the user you want to reward:");
                if (int.TryParse(Console.ReadLine(), out int idUser))
                {
                    if (!userLogic.TryGetId(idUser))
                    {
                        Console.WriteLine("No user with this id! Try again?(y/n)");
                    }
                    else
                    {
                        userAward.IdUser = idUser;
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Id is number! Try again?(y/n)");
                }
            }
            while (Console.ReadKey().Key == ConsoleKey.Y);
            
            ShowAwards(awardLogic);

            do
            {
                Console.WriteLine($"{Environment.NewLine}Enter the ID of the award:");
                if (int.TryParse(Console.ReadLine(), out int idAward))
                {
                    if (!awardLogic.TryGetId(idAward))
                    {
                        Console.WriteLine("No award with this id! Try again?(y/n)");
                    }
                    else
                    {
                        userAward.IdAward = idAward;
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Id is number! Try again?(y/n)");
                }
            }
            while (Console.ReadKey().Key == ConsoleKey.Y);

            linkTableLogic.Add(userAward);
        }

        private static void ShowUsersAndAwards(IRepositoryLogic<LinkTable> linkTableLogic, IRepositoryLogic<User> userLogic, IRepositoryLogic<Award> awardLogic)
        {
            Console.WriteLine();
            int idUser;
            int idAward;

            foreach (var userAndAwards in linkTableLogic.GetAll())
            {
                idUser = userAndAwards.IdUser;
                userLogic.GetById(idUser);
                Console.WriteLine(userLogic.GetById(idUser));
                idAward = userAndAwards.IdAward;
                Console.WriteLine($"\t {awardLogic.GetById(idAward)}"); 
            }
        }

        private static void ShowAwards(IRepositoryLogic<Award> awardLogic)
        {
            Console.WriteLine();
            foreach (var award in awardLogic.GetAll())
            {                
                Console.WriteLine(award);
            }
        }

        private static void ShowAwardByID(IRepositoryLogic<Award> awardLogic)
        {
            Console.WriteLine($"{Environment.NewLine}Enter award ID.");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine(awardLogic.GetById(id));
        }

        private static void DeleteAward(IRepositoryLogic<Award> awardLogic)
        {
            Console.WriteLine($"{Environment.NewLine}Enter ID deleted award.");
            int id = int.Parse(Console.ReadLine());
            awardLogic.Delete(id);
        }

        private static void AddAward(IRepositoryLogic<Award> awardLogic)
        {
            Console.WriteLine($"{Environment.NewLine}Enter the information about award.");
            Console.Write("Title: ");
            string title = Console.ReadLine();

            var award = new Award(title);

            awardLogic.Add(award);
        }
    }
}
