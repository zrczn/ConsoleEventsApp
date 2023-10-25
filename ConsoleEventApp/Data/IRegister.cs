using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleEventApp.Data
{
    public interface IRegister
    {
        bool Register(string[] elements);
        bool EmailExists(string email);
    }
}
