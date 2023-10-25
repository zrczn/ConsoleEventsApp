using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleEventApp.StaticFiles
{
    public static class RegexDescription
    {
        public const string PasswordRegexExplianation = """
                                                           Password matching expression.
                                                           Match all alphanumeric character and predefined wild characters.
                                                           Password must consists of at least 8 characters and not more than 15 characters.
                                                        """;
    }
}
