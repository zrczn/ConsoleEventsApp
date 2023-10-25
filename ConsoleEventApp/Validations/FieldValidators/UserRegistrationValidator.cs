using FieldValidationAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleEventApp.StaticFiles;
using ConsoleEventApp.Data;

namespace ConsoleEventApp.Validations.FieldValidators
{
    public class UserRegistrationValidator : IFieldValidators
    {
        private IRegister _register = null;

        private MatchAgainstRegexValidDel _matchAgainstRegexValidDel = null;
        private FieldEnteredValidDel _fieldEnteredValidDel = null;
        private RequiredLengthValidDel _requiredLengthValidDel = null;
        private EmailValidDel _emailValidDel = null;

        private FieldValidatorDel _fieldValidatorDel = null;

        public FieldValidatorDel FieldValidatorDel => _fieldValidatorDel;

        public string[] FieldArray { get; set; } = new string[Enum.GetValues(typeof(UserFields)).Length];

        public delegate bool EmailValidDel(string email);

        public void InitValidatorDel()
        {
            _matchAgainstRegexValidDel = CommonFieldValidation.MatchAgainstRegexValid;
            _fieldEnteredValidDel = CommonFieldValidation.FieldEnteredValid;
            _requiredLengthValidDel = CommonFieldValidation.RequiredLengthValid;

            _emailValidDel = new EmailValidDel(_register.EmailExists);
            _fieldValidatorDel = new FieldValidatorDel(fieldValidator);
        }

        public UserRegistrationValidator(IRegister register)
        {
            _register = register;
        }

        private bool fieldValidator(int fieldIndex, string fieldValue, out string ErrorMsg)
        {
            string ErrorMessage = "";

            UserFields getField = (UserFields)Enum.ToObject(typeof(UserFields), fieldIndex);

            switch (getField)
            {
                case UserFields.Email:
                    ErrorMessage = _fieldEnteredValidDel.Invoke(fieldValue) ? "" :
                        "Field is empty, provide it with some data";
                    ErrorMessage = _matchAgainstRegexValidDel(fieldValue, RegexPatterns.EmailRegexPattern) ? "" :
                        "Following Email is invalid";
                    ErrorMessage = _emailValidDel.Invoke(fieldValue) ? "Same email already exists" : ErrorMessage;
                    break;
                case UserFields.Password:
                    ErrorMessage = _fieldEnteredValidDel.Invoke(fieldValue) ? "" :
                        "Field is empty, provide it with some data";
                    ErrorMessage = _matchAgainstRegexValidDel(fieldValue, RegexPatterns.PasswordRegex) ? "" :
                        $"Following Password Is Invalid : {RegexDescription.PasswordRegexExplianation}";
                    break;
                default:
                    throw new Exception("there's no field like that");

            }

            ErrorMsg = ErrorMessage;

            if (string.IsNullOrEmpty(ErrorMsg))
                return false;

            return true; //validation problem
        }
    }
}
