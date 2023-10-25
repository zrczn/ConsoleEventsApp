using ConsoleEventApp.Validations.FieldValidators;
using ConsoleEventApp.wwwroot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleEventApp.Views
{
    internal class MainView : IView
    {
        private IView _userRegistration = null;
        private IView _userLogin = null;

        public IFieldValidators fieldValidator => throw new NotImplementedException();

        public MainView(IView userRegistration, IView userLogin)
        {
            _userRegistration = userRegistration;
            _userLogin = userLogin;
        }

        public void RunView()
        {
            string key;

            CommonView.WriteHeading(CommonView.MainHeading);

            do
            {
                Console.WriteLine("press f to register, or j to login, (esc to quit app)");

                key = Console.ReadKey().Key.ToString().ToLower();

                if (key == "f")
                {
                    runRegistration();
                }
                else if (key == "j")
                {
                    runLogin();
                }

            } while (key != "esc");

            Console.WriteLine("Goodbye!");


        }

        private void runRegistration()
        {
            _userRegistration.RunView();
        }

        private void runLogin()
        {
            _userLogin.RunView();
        }
    }
}
