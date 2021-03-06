﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Asgnm4.Validation1
{
    class ValidationPaddockSize : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            double number = 0;

            if (!double.TryParse((string)value, out number))
            {
                return new ValidationResult(false, "Size can be only numeric");
            }
            else if (number < 0)
            {
                return new ValidationResult(false, "Size cann't be negative");
            }
            else
            {
                return ValidationResult.ValidResult;
            }
        }
    }
}
