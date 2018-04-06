using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Asgnm4.Validation1
{
    class ValidationAge:ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            uint number = 0;

            if(!uint.TryParse((string)value,out number))
            {
                return new ValidationResult(false, "Age can be only integer starting from 0");
            }
            else
            { 
                return ValidationResult.ValidResult;
                
            }
        }
    }
}
