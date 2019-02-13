using System;

namespace Epam.Task7.UsersAndAwards.Entities
{
    public class LinkTable
    {
        public int IdUser { get; set; }

        public int IdAward { get; set; }

        public override string ToString()
        {
            return $"{IdUser} {IdAward}";
        }
    }
}
