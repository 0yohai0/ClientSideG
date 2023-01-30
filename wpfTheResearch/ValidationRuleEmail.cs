using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace wpfTheResearch
{
    public class ValidationRuleEmail : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string email = value as string;
            if(email.Length==0)
            {
                return new ValidationResult(false, "אימייל נחוץ");
            }
            if(!email.Contains('@'))
            {
                return new ValidationResult(false, "אימייל צריך להכיל @");
            }
            if (!email.Contains('.'))
            {
                return new ValidationResult(false, "אימייל צריך להכיל נקודה");
            }
            if(email.Length<5)
            {
               return new ValidationResult(false, "אורך מייל חייב להיות מעל 5");  
            }

            return new ValidationResult(true, null);

        }
    }
}
