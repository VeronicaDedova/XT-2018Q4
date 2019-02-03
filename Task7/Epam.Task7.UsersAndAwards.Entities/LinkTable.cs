using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
