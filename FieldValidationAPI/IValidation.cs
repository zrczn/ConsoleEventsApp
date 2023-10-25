using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationAPI
{
    public interface IValidation
    {
        public delegate bool FieldEnteredValidDel(string fieldValue);
        public delegate bool RequiredLengthValidDel(string fieldValue, int min, int max);

    }
}
