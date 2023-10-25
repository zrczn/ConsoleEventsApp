using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleEventApp.Validations.FieldValidators
{
    public delegate bool FieldValidatorDel(int IndexField, string valueField, out string ErrorMsg);

    public interface IFieldValidators
    {
        void InitValidatorDel();

        FieldValidatorDel FieldValidatorDel { get; }

        string[] FieldArray { get; set; }

    }
}
