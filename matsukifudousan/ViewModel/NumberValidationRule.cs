using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace matsukifudousan.ViewModel
{
    public class NumberValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {

            if (((string)value).Any(c => !char.IsNumber(c)))
            {
                return new ValidationResult(false, "数字で入力してください！");
            }
            else if (string.IsNullOrEmpty(value.ToString()))
            {
                 return new ValidationResult(false, "入力してください！");
            }
            else
            {
                return new ValidationResult(true, null);
            }
        }
    }
}
