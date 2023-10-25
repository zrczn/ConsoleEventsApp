using ConsoleEventApp.AppDbContext;
using ConsoleEventApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleEventApp.Data
{
    public class LoginUser : ILogin
    {
        public User Login(string email, string password)
        {
            User usr = null;

            using (var dbcontext = new AppDbContextt())
            {
                usr = dbcontext.users.Where(x => x.Email == email && x.Password == password).FirstOrDefault();
            }

            return usr;
        }
    }
}
