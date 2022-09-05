using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

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

            }
            else
            {
                MessageBox.Show("Nope");
            }
            
        }
        private bool TextboxFilled(TextBox txt, Label label)
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

        

        private bool TextboxFilled(TextBox txt,bool validation, Label label)
        {
            if (txt.Text != "" && new Helper().EmailValidation(textBoxEmail))
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


        private bool RadioButtonChecked(Label errormsg, Label label)
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

        private bool DatePicked(Label label)
        {
            if (birthdatePicker.SelectedDate != null && new Helper().validBirthdate(birthdatePicker))
            {
                label.Visibility = Visibility.Hidden;
                birthdatePicker.BorderBrush = Brushes.Transparent;
                return true;
            }
            else
            {
                label.Visibility = Visibility.Visible;
                birthdatePicker.BorderBrush = Brushes.Red;
                return false;
            }
        }
        private bool CheckAll()
        {
            bool check1 = TextboxFilled(textBoxFirstname,labelErrorFirstname);
            bool check2 = TextboxFilled(textBoxLastname, labelErrorLastname);
            bool check3 = TextboxFilled(textBoxEmail,new Helper().EmailValidation(textBoxEmail) ,labelErrorMail);
            bool check4 = RadioButtonChecked(labelErrorGender, labelGender);
            bool check5 = DatePicked(labelErrorDate);
            
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
