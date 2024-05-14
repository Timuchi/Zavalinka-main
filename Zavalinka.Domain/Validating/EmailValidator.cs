using System.Text.RegularExpressions;

namespace Zavalinka.Domain.Validating
{
    public static class EmailValidator
    {
        private const string ValidEmailPattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
                                                 + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
                                                 + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

        public static bool IsEmailValid(string email) 
            => Regex.IsMatch(email, ValidEmailPattern);
    }
}