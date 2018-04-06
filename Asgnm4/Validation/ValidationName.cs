using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Asgnm4.Validation1
{
    class ValidationName:ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {

            if (value.ToString()=="")
            {
                return new ValidationResult(false, "Name field can not be empty");
            }
            else
            {
                return ValidationResult.ValidResult;
            }
        }
    }
}
