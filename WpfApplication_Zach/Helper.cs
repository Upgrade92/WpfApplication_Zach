using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Text.RegularExpressions;

namespace WpfApplication_Zach
{
    public class Helper
    {
        public void TextBoxChanged(TextBox txt, Label label)
        {
            if (txt.Text.Equals(""))
            {
                label.Visibility = Visibility.Visible;
            }
            else
            {
                label.Visibility = Visibility.Hidden;
            }
        }
        public bool EmailValidation(TextBox text)
        {
            if (text.Text.Length > 4)
            {
                Regex mailRegex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", RegexOptions.IgnoreCase);
                return mailRegex.IsMatch(text.Text);
            }
            else return false;
        }

        public bool validBirthdate(DatePicker birthday)
        {
            if (DateTime.Today.Year - birthday.SelectedDate.Value.Year > 17)
            {
                return true;
            }
            else return false;
        }
    }
}
