using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace ConsoleEventApp.wwwroot
{
    public static class CommonView
    { 

        public static string MainHeading
        {
            get
            {
                return $"Event Management App{Environment.NewLine}{new string('-', 20)}";
            }
        }

        public static string RegisterHeading
        {
            get
            {
                return $"Registration {Environment.NewLine}{new string('-', 20)}";
            }
        }

        public static string LoginHeading
        {
            get
            {
                return $"Logg in {Environment.NewLine}{new string('-', 20)}";
            }
        }

        public static Action<string> WriteHeading = (h) => {
            Console.Clear();
            Console.WriteLine(h);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
        };

    }
}
