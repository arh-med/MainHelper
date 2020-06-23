using System.Globalization;
using System.Windows.Controls;

namespace MainHelper.UserControlProject.UserControlTask.Validators
{
    public class NameCategoryValidator : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null)
            {
                return new ValidationResult(false, "Поле не заполнено");
            }

            string stringValue = value.ToString();

            if (stringValue.Length > 10)
            {
                return new ValidationResult(false, "Длина слова не должна превышать 10 букв");
            }

            if (string.IsNullOrWhiteSpace(stringValue))
            {
                return new ValidationResult(false, "Поле не заполнено");
            }

            return new ValidationResult(true, null);
        }
    }
}
