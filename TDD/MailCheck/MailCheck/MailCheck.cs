//----------------------------------------------------------------------------------------------
// <copyright file="MailCheck.cs" company="Codic Education">
// By Marcus Medina, 2021 - http://MarcusMedina.Pro 
// This file is subject to the terms and conditions defined in file "license.txt"- GNU3, 
// which is part of this project. </copyright>
// ----------------------------------------------------------------------------------------------

namespace MailCheck
{
    using System.Linq;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Defines the <see cref="MailCheck" />.
    /// </summary>
    public class MailCheck
    {
        /// <summary>
        /// The CheckMail.
        /// </summary>
        /// <param name="email">The email<see cref="string"/>.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        public bool CheckMail(string email)
        {
            // För jämförelse, kolla https://stackoverflow.com/a/8554735/15032536

            const string cmp = "abcdefghijklmnopqrstuvwxyz0123456789@-._";
            if (string.IsNullOrEmpty(email)) return false;

            var pos = email.IndexOf('@');
            var domain = "";
            var name = "";
            if (pos > 0)
            {
                domain = email.Substring(pos);
                name = email.Substring(0, pos);
            }

            var check = !email.Contains(' '); // o Inga mellanslag får förekomma
            check = check && email.Contains('@'); // o Måste ha @ symbol
            check = check && email.Length < 60; // o Får inte vara längre än 60 tecken allt som allt
            check = check && email.Count(c => c == '@') < 2; // o Får bara ha ett @ symbol
            check = check && email.Count(c => char.IsUpper(c)) == 0; // o Får inte innehålla versaler
            check = check && domain.Trim().TrimEnd('.').Contains('.');// o Måste bestå av namn @ domän.suffix
            check = check && email.Except(cmp).Count() == 0; // o Får inte innehålla annat än bokstäver, siffror, punkt, @, minus och understreck
            check = check && name.Length < 50;

            /*
            
            o Namn kan vara namn.efternamn
            
            o Namndelen får inte vara längre än 50 tecken
             */


            return check;
        }

        /// <summary>
        /// Checks if a password is valid
        /// By comparing length greater than 6 and smaller than 25.
        /// </summary>
        /// <param name="pass">The password to test.</param>
        /// <returns>True if password is OK.</returns>
        public bool CheckPassword(string pass)
        {
            const string cmp = "!.:$%&()=/+-";
            if (string.IsNullOrEmpty(pass)) return false;

            var check = pass.Length > 6
                && pass.Length < 25
                && pass.Any(c => char.IsUpper(c))
                && pass.Any(c => char.IsLower(c))
                && pass.Any(c => char.IsNumber(c))
                && pass.Intersect(cmp).Any();

            return check;
        }

        /// <summary>
        /// Checks if a swedish phonenumber is OK
        /// </summary>
        /// <param name="phone">The phone<see cref="string"/>.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        public bool SwePhoneCheck(string phone)
        {
            if (string.IsNullOrEmpty(phone)) return false;
            // Check https://regexone.com/ och testa på https://regex101.com
            return Regex.IsMatch(phone, @"^(\+46)\s*(7[0236])\s*(\d{4})\s*(\d{3})$");
        }
    }
}
