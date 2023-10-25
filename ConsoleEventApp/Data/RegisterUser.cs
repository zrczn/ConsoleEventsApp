using ConsoleEventApp.AppDbContext;
using ConsoleEventApp.Models;
using ConsoleEventApp.Validations.FieldValidators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleEventApp.Data
{
    public class RegisterUser : IRegister
    {
        public bool EmailExists(string email)
        {
            User usr;

            using (var dbcontext = new AppDbContextt())
            {
                usr = dbcontext.users.Where(x => x.Email == email.ToLower()).FirstOrDefault();
            }

            if (usr != null)
                return true;

            return false;
        }

        public bool Register(string[] elements)
        {

            User usr = new User()
            {
                Email = elements[(int)UserFields.Email],
                Password = elements[(int)UserFields.Password]
            };

            try
            {
                using (var dbcontext = new AppDbContextt())
                {
                    dbcontext.Add(usr);
                    dbcontext.SaveChanges();
                }
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}
