using ConsoleEventApp.Data;
using ConsoleEventApp.Models;
using ConsoleEventApp.Validations.FieldValidators;
using ConsoleEventApp.wwwroot;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleEventApp.Views
{
    public class UserLoginView : IView
    {
        private ILogin _login = null;

        public IFieldValidators fieldValidator => throw new NotImplementedException();

        public void RunView()
        {
            CommonView.WriteHeading(CommonView.LoginHeading);
            LoginLoop(_login);
        }

        public UserLoginView(ILogin login)
        {
            _login = login;
        }

        private static void LoginLoop(ILogin login)
        {

            string email = null;
            string password = null;

            do
            {
                Console.WriteLine($"Please provide an {nameof(email)} field");
                email = Console.ReadLine();
                Console.WriteLine($"Please provide an {nameof(password)} field");
                password = Console.ReadLine();

                if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                    continue;

            } while (!TryToLogIn(email, password));

            bool TryToLogIn(string Email, string password)
            {
                if (login.Login(Email, password) == null)
                {
                    CommonTextSyles.ChangeColorPaletteTo(type.danger);
                    Console.WriteLine("Failed to login!");
                    CommonTextSyles.ChangeColorPaletteTo(type.def);
                    return false;
                }

                CommonTextSyles.ChangeColorPaletteTo(type.success);
                Console.WriteLine("Logged in successful!");
                CommonTextSyles.ChangeColorPaletteTo(type.def);
                return true;
            }

        }

    }
}
