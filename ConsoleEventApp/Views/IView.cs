using ConsoleEventApp.Validations.FieldValidators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleEventApp.Views
{
    public interface IView
    {
        void RunView();
        public IFieldValidators fieldValidator { get;}

    }
}
