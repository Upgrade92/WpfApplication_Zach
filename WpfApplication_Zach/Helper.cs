using System;
using System.Windows.Controls;
using System.Windows;
using System.Text.RegularExpressions;
using System.Windows.Media;

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

        public bool TextboxFilled(TextBox txt, Label label)
        {
            if (txt.Text != "")
            {
                label.Visibility = Visibility.Hidden;
                txt.BorderBrush = Brushes.Transparent;
                return true;
            }
            else
            {
                label.Visibility = Visibility.Visible;
                txt.BorderBrush = Brushes.Red;
                return false;
            }
        }

        public bool TextboxFilled(TextBox txt)
        {
            if (txt.Text != "")
            {
                txt.BorderBrush = Brushes.Transparent;
                return true;
            }
            else
            {
                txt.BorderBrush = Brushes.Red;
                return false;
            }
        }
        public bool TextboxFilled(TextBox txt, bool validation)
        {
            if (txt.Text != "" && EmailValidation(txt))
            {
                txt.BorderBrush = Brushes.Transparent;
                return true;
            }
            else
            {
                txt.BorderBrush = Brushes.Red;
                return false;
            }
        }

        public bool TextboxFilled(TextBox txt, bool validation, Label label)
        {
            if (txt.Text != "" && EmailValidation(txt))
            {
                label.Visibility = Visibility.Hidden;
                txt.BorderBrush = Brushes.Transparent;
                return true;
            }
            else
            {
                label.Visibility = Visibility.Visible;
                txt.BorderBrush = Brushes.Red;
                return false;
            }
        }

        public bool RadioButtonChecked(Label errormsg, Label label,RadioButton radioButtonMale, RadioButton radioButtonFemale)
        {
            if (radioButtonMale.IsChecked == true || radioButtonFemale.IsChecked == true)
            {
                errormsg.Visibility = Visibility.Hidden;
                label.Background = Brushes.Transparent;
                radioButtonFemale.BorderBrush = Brushes.Transparent;
                radioButtonMale.BorderBrush = Brushes.Transparent;
                return true;
            }
            else
            {
                errormsg.Visibility = Visibility.Visible;
                label.Background = Brushes.Red;
                radioButtonFemale.BorderBrush = Brushes.Red;
                radioButtonMale.BorderBrush = Brushes.Red;
                return false;
            }
        }

        public bool DatePicked(Label label, DatePicker date)
        {
            if (date.SelectedDate != null && validBirthdate(date))
            {
                label.Visibility = Visibility.Hidden;
                date.BorderBrush = Brushes.Transparent;
                return true;
            }
            else
            {
                label.Visibility = Visibility.Visible;
                date.BorderBrush = Brushes.Red;
                return false;
            }
        }

        public bool DatePicked(DatePicker date)
        {
            if (date.SelectedDate != null && validBirthdate(date))
            {
                date.BorderBrush = Brushes.Transparent;
                return true;
            }
            else
            {
                date.BorderBrush = Brushes.Red;
                return false;
            }
        }

        public string GetTitle(string gender)
        {
            if (gender.ToLower().Equals("weiblich"))
            {
                return "Frau";
            }
            else if (gender.ToLower().Equals("männlich"))
            {
                return "Herr";
            }
            else
            {
                return "Anrede";
            }
        }

        public string RadioButtonToString(RadioButton male, RadioButton female)
        {
            string gender = "";
            if (male.IsChecked == true)
            {
                gender = "männlich";
            }

            if (female.IsChecked == true)
            {
                gender = "weiblich";
            }
            return gender;
        }
    }
}
