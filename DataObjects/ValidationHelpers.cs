using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

/// <summary>
/// Creator:            Liam Easton
/// Created:            01/30/2024
/// Summary:            Creation of ValidationHelpers class
/// Last Updated By:    Liam Easton
/// Last Updated:       01/30/2024
/// What Was Changed:   Creation of ValidationHelpers class
/// </summary>
namespace DataObjects
{
    public static class ValidationHelpers
    {
        private static Regex phoneNumberRegex = new Regex("^[2-9]\\d{2}-\\d{3}-\\d{4}$");
        /// <summary>
        /// Creator:            Liam Easton
        /// Created:            01/30/2024
        /// Summary:            Creation of IsValidEmail method
        /// Last Updated By:    Liam Easton
        /// Last Updated:       01/30/2024
        /// What Was Changed:   Creation of IsValidEmail method
        /// </summary>
        public static bool IsValidEmail(this string email)
        {
            bool isValid = false;

            if (email.Contains("@") &&
                email.Contains(".") &&
                email.Length >= 10 &&
                email.Length <= 100) 
			{
                isValid = true;
            }
            return isValid;
        }

        /// <summary>
        /// Creator:            Liam Easton
        /// Created:            02/15/2024
        /// Summary:            Creation of IsValidHour method
        /// Last Updated By:    Liam Easton
        /// Last Updated:       02/15/2024
        /// What Was Changed:   Creation of IsValidHour method
        /// </summary>
        public static bool IsValidHour(this int hour) {
            bool isValid = false;

            if (hour > 0 &&
                hour <= 12) 
			{
				isValid = true;
            }
            return isValid;
        }

        /// <summary>
        /// Creator:            Liam Easton
        /// Created:            02/15/2024
        /// Summary:            Creation of IsValidHour method
        /// Last Updated By:    Liam Easton
        /// Last Updated:       02/15/2024
        /// What Was Changed:   Creation of IsValidHour method
        /// </summary>
        public static bool IsValidMinute(this int minute) 
		{
            bool isValid = false;

            if (minute >= 0 &&
                minute <= 59)
            {
                isValid = true;
            }
            return isValid;
        }

        /// <summary>
        /// Creator:            Liam Easton
        /// Created:            01/30/2024
        /// Summary:            Creation of IsValidPassword method
        /// Last Updated By:    Liam Easton
        /// Last Updated:       01/30/2024
        /// What Was Changed:   Creation of IsValidPassword method
        /// </summary>
        public static bool IsValidPassword(this string password)
        {
            bool isValid = false;

            if (password.Length >= 8)
            {
                isValid = true;
            }

            return isValid;
        }

        /// <summary>
        /// Creator:            Jared Harvey
        /// Created:            03/08/2024
        /// Summary:            Creation of IsValidPhoneNumber method
        /// Last Updated By:    Jared Harvey
        /// Last Updated:       03/08/2024
        /// What Was Changed:   Creation of IsValidPhoneNumber method
        /// </summary>
        public static bool IsValidPhoneNumber(string phoneNumber) {
            if (phoneNumberRegex.IsMatch(phoneNumber)) return true;
            return false;
        }
    }
}
