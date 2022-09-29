using System;
using System.Windows;
using System.Windows.Controls;
using System.Linq;

namespace WpfApplication_Zach
{
     public partial class NewUser : Window 
    {
        public NewUser()
        {
            InitializeComponent();             
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            saveButton.Content = "Speichern";
            SaveNewUser();
            
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            cancelButton.Content = "Schließen"; // This one here is new
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
        
        private void SaveNewUser2()
        {
            string firstname = textBoxFirstname.Text;
            string lastname = textBoxLastname.Text;
            string email = textBoxEmail.Text;
            string gender = new Helper().RadioButtonToString(radioButtonMale,radioButtonFemale);
            string birthdate = birthdatePicker.ToString();

            if (CheckAll())
            {             
                new DatabaseHelper().DoNonQuery($"INSERT INTO [TablePeople] " +
                                                $"(Firstname,Lastname,[E-Mail],Geschlecht,Geburtstag) " +
                                                $"VALUES('{firstname}','{lastname}','{email}','{gender}','{birthdate}')");
                MessageBox.Show("Neuer User erfolgreich angelegt!");
            }
            else
            {
                MessageBox.Show("Nope");
            }            
        }

        private void SaveNewUser()
        {
            string firstname = textBoxFirstname.Text;
            string lastname = textBoxLastname.Text;
            string email = textBoxEmail.Text;
            string gender = new Helper().RadioButtonToString(radioButtonMale, radioButtonFemale);
            string birthdate = birthdatePicker.ToString();

            if (CheckAll())
            {
                DataClasses1DataContext dc = new DataClasses1DataContext();

                TablePeople newPerson = new TablePeople();
                newPerson.Firstname = firstname;
                newPerson.Lastname = lastname;
                newPerson.E_Mail = email;
                newPerson.Geschlecht = gender;
                newPerson.Geburtstag = birthdate;
                dc.TablePeople.InsertOnSubmit(newPerson);
                dc.SubmitChanges();



                MessageBox.Show("Neuer User erfolgreich angelegt!");
            }
            else
            {
                MessageBox.Show("Nope");
            }
        }

        private bool CheckAll()
        {
            bool check1 = new Helper().TextboxFilled(textBoxFirstname,labelErrorFirstname);
            bool check2 = new Helper().TextboxFilled(textBoxLastname, labelErrorLastname);
            bool check3 = new Helper().TextboxFilled(textBoxEmail,new Helper().EmailValidation(textBoxEmail) ,labelErrorMail);
            bool check4 = new Helper().RadioButtonChecked(labelErrorGender, labelGender,radioButtonMale,radioButtonFemale);
            bool check5 = new Helper().DatePicked(labelErrorDate,birthdatePicker);
            
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
