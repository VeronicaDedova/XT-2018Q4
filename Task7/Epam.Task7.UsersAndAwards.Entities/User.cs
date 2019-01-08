using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task7.UsersAndAwards.Entities
{
    public class User
    {
        private string lastName;
        private string firstName;
        private string patronymic;
        private DateTime dateOfBirth;

        public User()
        {
        }

        public User(string firstName, string lastName, string patronymic, DateTime dateOfBirth)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Patronymic = patronymic;
            this.DateOfBirth = dateOfBirth;
        }

        public int Id { get; set; }

        public string FirstName
        {
            get => this.firstName;
            set
            {
                if ((value.Length == 0) || (value.Trim() == string.Empty))
                {
                    throw new Exception("Incorrect firstname.");
                }
                else
                {
                    this.firstName = value;
                }
            }
        }

        public string LastName
        {
            get => this.lastName;
            set
            {
                if ((value.Length == 0) || (value.Trim() == string.Empty))
                {
                    throw new Exception("Incorrect surname.");
                }
                else
                {
                    this.lastName = value;
                }
            }
        }

        public string Patronymic
        {
            get => this.patronymic;
            set
            {
                if ((value.Length == 0) || (value.Trim() == string.Empty))
                {
                    throw new Exception("Incorrect patronymic.");
                }
                else
                {
                    this.patronymic = value;
                }
            }
        }

        public DateTime DateOfBirth
        {
            get => this.dateOfBirth;
            set
            {
                if ((value.Year < 1868) || (value.Year > DateTime.Now.Year))
                {
                    throw new Exception("Incorrect date of birth.");
                }
                else
                {
                    this.dateOfBirth = value;
                }
            }
        }

        public int Age
        {
            get
            {
                int age = DateTime.Now.Year - this.DateOfBirth.Year;
                if ((DateTime.Now.Month <= this.DateOfBirth.Month) && (DateTime.Now.Day < this.DateOfBirth.Day))
                {
                    age--;
                }

                return age;
            }
        }

        public override string ToString()
        {
            return $"{Id} {firstName} {lastName} {Patronymic} {DateOfBirth.ToShortDateString()} {Age}";
        }
    }
}
