using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace wpfTheResearch
{
    public class validationRulePassword : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string password = value as string;
            if (password.Length == 0)
            {
                return new ValidationResult(false, "ססמה נחוצה");
            }
            //33-47
            int specialCount = 0;
            foreach (char c in password)
            {
                int i = Convert.ToInt32(c);
                if ( i > 32 && i < 48)
                {
                    specialCount++;
                }
            }
            int upperCount = 0;
            foreach (char c in password)
            {
                if (char.IsUpper(c))
                {
                    upperCount++;
                }
            }
            if (specialCount < 2)
            {
                return new ValidationResult(false, "ססמה צריכה להכיל 2 סימנים מיוחדים");
            }
            if (upperCount == 0)
            {
                return new ValidationResult(false, " ססמה צריכה להכיל אות גדולה אחת");
            }
            if (password.Length < 5)
            {
                return new ValidationResult(false, "אורך ססמה חייב להיות מעל 5");
            }
            if (password.Length > 14)
            {
                return new ValidationResult(false, "אורך ססמה חייב להיות מתחת ל-14");
            }

            return new ValidationResult(true, null);
        }
    }
}
