using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FieldValidationAPI
{
    public delegate bool MatchAgainstRegexValidDel(string fieldValue, string RegexPattern);
    public delegate bool FieldEnteredValidDel(string fieldValue);
    public delegate bool RequiredLengthValidDel(string fieldValue, int min, int max);



    public class CommonFieldValidation
    {
        private static MatchAgainstRegexValidDel _matchAgainstRegexValidDel = null;
        private static FieldEnteredValidDel _fieldEnteredValidDel = null;
        private static RequiredLengthValidDel _requiredLengthValidDel = null;

        public static MatchAgainstRegexValidDel MatchAgainstRegexValid
        {
            get
            {
                if (_matchAgainstRegexValidDel == null)
                    _matchAgainstRegexValidDel = new MatchAgainstRegexValidDel(regexCompare);

                return _matchAgainstRegexValidDel;
            }
        }

        public static FieldEnteredValidDel FieldEnteredValid
        {
            get
            {
                if (_fieldEnteredValidDel == null)
                    _fieldEnteredValidDel = new FieldEnteredValidDel(fieldNotNull);

                return _fieldEnteredValidDel;
            }
        }

        public static RequiredLengthValidDel RequiredLengthValid
        {
            get
            {
                if (_requiredLengthValidDel == null)
                    _requiredLengthValidDel = new RequiredLengthValidDel(checkLength);

                return _requiredLengthValidDel;
            }
        }

        private static bool regexCompare(string fieldValue, string RegexPattern)
        {
            Regex rgx = new(RegexPattern);

            if (rgx.IsMatch(fieldValue))
                return true;

            return false;
        }

        private static bool fieldNotNull(string fieldValue)
        {
            if (string.IsNullOrEmpty(fieldValue))
                return false;

            return true;
        }

        private static bool checkLength(string fieldValue, int min, int max)
        {
            if (fieldValue.Length <= max && fieldValue.Length >= min)
                return true;

            return false;
        }
    }
}
