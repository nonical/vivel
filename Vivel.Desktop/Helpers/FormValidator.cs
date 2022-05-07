using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    }
}
