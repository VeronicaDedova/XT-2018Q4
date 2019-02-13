﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Task7.UsersAndAwards.Entities;

namespace Epam.Task7.UsersAndAwards.BLL.Interface
{
    public interface IUserAccountLogic
    {
        bool Login(string userName, string password);

        bool Registration(string userName, string password);

        bool AppointAdmin(string userName);

        bool RemoveAdmin(string userName);
    }
}
