using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApplication_Zach
{
    /// <summary>
    /// Interaction logic for NewUser.xaml
    /// </summary>
    public partial class NewUser : Window 
    {
        public NewUser()
        {
            InitializeComponent();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            SaveNewUser();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void radioButtonMale_Checked(object sender, RoutedEventArgs e)
        {
            if(radioButtonMale.IsChecked == true)
            {
                comboBoxTitle.SelectedIndex = 1;
            }
        }

        private void radioButtonFemale_Checked(object sender, RoutedEventArgs e)
        {
            if(radioButtonFemale.IsChecked == true)
            {
                comboBoxTitle.SelectedIndex = 2;
            }
        }

        private string GetGender()
        {
            string gender="";
            if (radioButtonMale.IsChecked == true) {
                gender = "männlich";
            }

            if (radioButtonFemale.IsChecked == true)
            {
                gender = "weiblich";
            }
            return gender;
        }

        private void SaveNewUser()
        {

            string firstname = textBoxFirstname.Text;
            string lastname = textBoxLastname.Text;
            string email = textBoxEmail.Text;
            string gender = GetGender();
            string birthdate = birthdatePicker.ToString();

            if (CheckAll())
            {             
                new DatabaseHelper().DoNonQuery($"INSERT INTO [TablePeople] (Firstname,Lastname,[E-Mail],Geschlecht, Geburtsdatum) VALUES('{firstname}','{lastname}','{email}','{gender}','{birthdate}')");
                MessageBox.Show("New User saved!");
                labelError.Visibility = Visibility.Hidden;        
            }
            else { 
                MessageBox.Show("NoNoNo");
                labelError.Visibility = Visibility.Visible;
            }
        }
        private bool TextboxFilled(TextBox txt)
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

        private bool TextboxFilled(TextBox txt,bool validation)
        {
            if (txt.Text != ""&& new Helper().EmailValidation(textBoxEmail,textBoxEmail.Text))
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


        private bool RadioButtonChecked()
        {
            if (radioButtonMale.IsChecked == true || radioButtonFemale.IsChecked == true)
            {
                radioButtonFemale.BorderBrush = Brushes.Transparent;
                radioButtonMale.BorderBrush = Brushes.Transparent;
                return true;
            }
            else
            {
                radioButtonFemale.BorderBrush = Brushes.Red;
                radioButtonMale.BorderBrush = Brushes.Red;
                return false;
            }
        }

        private bool DatePicked()
        {
            if (birthdatePicker.SelectedDate != null && new Helper().validBirthdate(birthdatePicker))
            {
                birthdatePicker.BorderBrush = Brushes.Transparent;
                return true;
            }
            else
            {
                birthdatePicker.BorderBrush = Brushes.Red;
                return false;
            }
        }
        private bool CheckAll()
        {
            bool check1 = TextboxFilled(textBoxFirstname);
            bool check2 = TextboxFilled(textBoxLastname);
            bool check3 = TextboxFilled(textBoxEmail) && new Helper().EmailValidation(textBoxEmail ,textBoxEmail.Text);
            bool check4 = RadioButtonChecked();
            bool check5 = DatePicked();
            
            if (check1 && check2 && check3 && check4 && check5)
            {
                return true;
            }
            else return false;
        }

        private void textBoxFirstname_TextChanged(object sender, TextChangedEventArgs e)
        {
            new Helper().TextBoxChanged(textBoxFirstname, labelFirstname);
        }

        private void textBoxLastname_TextChanged(object sender, TextChangedEventArgs e)
        {
            new Helper().TextBoxChanged(textBoxLastname, labelLastname);
        }

        private void textBoxEmail_TextChanged(object sender, TextChangedEventArgs e)
        {
            new Helper().TextBoxChanged(textBoxEmail, labelEmail);
        }
    }
}
