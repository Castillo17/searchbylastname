using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Name_and_Address
{
    class StandardValidations
    {
        public static bool IsAlphaOnlyString(string alphaString)
        {
            string pattern = @"^[A-Z,a-z]+$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(alphaString);
        }

        public static bool IsPhoneValid(string phoneNumber)
        {
            string pattern = @"^[2-9]\d{2}-\d{3}-\d{4}$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(phoneNumber);
        }

        public static bool IsUSZipCode(string zipCode)
        {
            string pattern = @"^[0-9]{5}(?:-[0-9]{4})?$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(zipCode);

        }


    }
}
