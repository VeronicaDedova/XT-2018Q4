using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task7.UsersAndAwards.Entities
{
    public class Award
    {
        private string title;

        public Award()
        {
        }

        public Award(string title)
        {
            this.Title = title;
        }

        public int Id { get; set; }

        public string Title
        {
            get => this.title;
            set
            {
                if ((value.Length == 0) || (value.Trim() == string.Empty))
                {
                    throw new Exception("Incorrect title.");
                }
                else
                {
                    this.title = value;
                }
            }
        }

        public override string ToString()
        {
            return $"{Id} {Title}";
        }
    }
}
