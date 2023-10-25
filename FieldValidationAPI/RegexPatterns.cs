namespace FieldValidationAPI
{
    public class RegexPatterns
    {
        public const string PasswordRegex = "^([a-zA-Z0-9@*#]{8,15})$";

        public const string EmailRegexPattern = "^((([!#$%&'*+\\-/=?^_`{|}~\\w])|([!#$%&'*+\\-/=?^_`{|}~\\w][!#$%&'*+\\-/=?^_`{|}~\\.\\w]{0,}[!#$%&'*+\\-/=?^_`{|}~\\w]))[@]\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)$";
    }
}