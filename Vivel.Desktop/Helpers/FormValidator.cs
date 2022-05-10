using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vivel.Desktop.Helpers
{
    public class FormValidator
    {
        public static bool validateTextField(ErrorProvider errorProvider, TextBox textBox, string message)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                errorProvider.SetError(textBox, message);
                return false;
            }

            return true;
        }

        public static bool validateGeolocation(ErrorProvider errorProvider, TextBox txtLatitude, TextBox txtLongitude)
        {
            decimal latitude;
            decimal longitude;

            if (decimal.TryParse(txtLatitude.Text.Replace(",", "."), out latitude) && (latitude < -90 || latitude > 90))
            {
                errorProvider.SetError(txtLatitude, "Latitude must be between -90 and 90 degrees inclusive.");
                return false;
            }

            if (decimal.TryParse(txtLongitude.Text.Replace(",", "."), out longitude) && (longitude < -180 || longitude > 180))
            {
                errorProvider.SetError(txtLongitude, "Longitude must be between -180 and 180 degrees inclusive.");
                return false;
            }

            return true;
        }

        public static bool validatePassword(ErrorProvider errorProvider, TextBox txtPassword)
        {
            var input = txtPassword.Text;

            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMiniMaxChars = new Regex(@".{8,15}");
            var hasLowerChar = new Regex(@"[a-z]+");
            var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");

            if (!hasLowerChar.IsMatch(input))
            {
                errorProvider.SetError(txtPassword, "Password should contain at least one lower case letter.");
                return false;
            }
            else if (!hasUpperChar.IsMatch(input))
            {
                errorProvider.SetError(txtPassword, "Password should contain at least one upper case letter.");
                return false;
            }
            else if (!hasMiniMaxChars.IsMatch(input))
            {
                errorProvider.SetError(txtPassword, "Password should not be lesser than 8 or greater than 15 characters.");
                return false;
            }
            else if (!hasNumber.IsMatch(input))
            {
                errorProvider.SetError(txtPassword, "Password should contain at least one numeric value.");
                return false;
            }

            else if (!hasSymbols.IsMatch(input))
            {
                errorProvider.SetError(txtPassword, "Password should contain at least one special case character.");
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
