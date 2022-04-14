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
    }
}
