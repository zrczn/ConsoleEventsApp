﻿using ConsoleEventApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleEventApp.Data
{
    public interface ILogin
    {
        User Login(string email, string password);
    }
}
