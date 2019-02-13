using System;
using System.Web.Helpers;
using Epam.Task7.UsersAndAwards.Entities;

namespace Epam.Task11.UsersAndAwards.WebUI
{
    public class Img
    {
        private static readonly string Path = AppContext.BaseDirectory + @"\..\usersAndAwards\";

        public static string GetUserImage(User user)
        {
            if (user.Img != null)
            {
                WebImage img = new WebImage(user.Img);

                return $"data:image/{img.ImageFormat};base64,{Convert.ToBase64String(user.Img)}";
            }

            WebImage imgDef = new WebImage(Path + @"\ImgUser\" + "default");

            return $"data:image/{imgDef.ImageFormat};base64,{Convert.ToBase64String(imgDef.GetBytes())}";
        }

        public static string GetAwardImage(Award award)
        {
            if (award.Img != null)
            {
                WebImage img = new WebImage(award.Img);

                return $"data:image/{img.ImageFormat};base64,{Convert.ToBase64String(award.Img)}";
            }

            WebImage imgDef = new WebImage(Path + @"\ImgAward\" + "default");

            return $"data:image/{imgDef.ImageFormat};base64,{Convert.ToBase64String(imgDef.GetBytes())}";
        }
    }
}