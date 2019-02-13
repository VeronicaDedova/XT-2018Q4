using System;

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

        public byte[] Img { get; set; }

        public override string ToString()
        {
            return $"{Id} {Title}";
        }
    }
}