using System.Security.Cryptography;
using System.Text;

namespace Epam.Task11.UsersAndAwards.WebUI.Cs
{
    public class ForPassword
    {
        public static string SHA256(string password)
        {
            var crypt = new SHA256Managed();
            var hash = new StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(password));

            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }

            return hash.ToString();
        }
    }
}