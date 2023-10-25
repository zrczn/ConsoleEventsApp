using ConsoleEventApp.Data;
using ConsoleEventApp.Validations.FieldValidators;
using ConsoleEventApp.wwwroot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleEventApp.Views
{
    public class UserRegistrationView : IView
    {
        private IRegister _register = null;
        private IFieldValidators _fieldValidators = null;

        public IFieldValidators fieldValidator => _fieldValidators;

        public void RunView()
        {
            bool passedValidation;
            bool raiseFlag = true;
            string mssg;

            CommonView.WriteHeading(CommonView.RegisterHeading);

            for (int i = 0; i < Enum.GetNames(typeof(UserFields)).Length; i++)
            {
                Console.WriteLine($"Please enter falue for {Enum.GetName(typeof(UserFields), i)}");

                do
                {
                    string input = Console.ReadLine();

                    passedValidation = SingleFieldValidation(i, input, out mssg);

                    if (!passedValidation)
                    {
                        CommonTextSyles.ChangeColorPaletteTo(type.danger);
                        Console.WriteLine(mssg);
                        CommonTextSyles.ChangeColorPaletteTo(type.def);
                    }
                    else
                    {
                        raiseFlag = false;

                        _fieldValidators.FieldArray[i] = input;
                    }

                } while (raiseFlag);


                raiseFlag = true;
            }

            _register.Register(_fieldValidators.FieldArray);

            CommonTextSyles.ChangeColorPaletteTo(type.success);
            Console.WriteLine("sucessfully registered!");
            CommonTextSyles.ChangeColorPaletteTo(type.def);

            Console.ReadLine();
        }

        public UserRegistrationView(IRegister register, IFieldValidators fieldValidators)
        {
            _register = register;
            _fieldValidators = fieldValidators;
        }

        public bool SingleFieldValidation(int indexOfEnum, string value, out string message)
        {
            string mssg = "";
            bool tryToValidate;

            tryToValidate = _fieldValidators.FieldValidatorDel(indexOfEnum, value, out mssg);

            if (tryToValidate)
            {
                message = mssg;
                return false;
            }

            message = null;
            return true;
        }
    }
}
