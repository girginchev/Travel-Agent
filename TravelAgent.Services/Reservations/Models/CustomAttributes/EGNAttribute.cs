namespace TravelAgent.Services.Reservations.Models.CustomAttributes
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class EGNAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string egn = value.ToString();
            var unsuccesfullMessage = new ValidationResult("Invalid EGN number.");

            if (egn.Length != 10)
            {
                return unsuccesfullMessage;
            }
            var regex = new Regex("[^ 0 - 9]");
            if (!regex.IsMatch(egn))
            {
                return unsuccesfullMessage;
            }

            var year = int.Parse(egn.Substring(0, 2));
            var month = int.Parse(egn.Substring(2, 2));
            var day = int.Parse(egn.Substring(4, 2));

            if (month >= 40)
            {
                year += 2000;
                month -= 40;
            }
            else if (month >= 20)
            {
                year += 1800;
                month -= 20;
            }
            else
            {
                year += 1900;
            }


            var checkSum = 0;
            var weights = new List<int> { 2, 4, 8, 5, 10, 9, 7, 3, 6 };

            for (var i = 0; i < weights.Count; i++)
            {
                checkSum += weights[i] * int.Parse(egn.ElementAt(i).ToString());
            }

            checkSum %= 11;
            checkSum %= 10;

            if (checkSum != int.Parse(egn.ElementAt(9).ToString()))
            {
                return unsuccesfullMessage;
            }

            return ValidationResult.Success;
        }
    }
}
