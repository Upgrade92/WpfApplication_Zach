using System;
using System.Data;
using System.Windows;

namespace WpfApplication_Zach
{
    public partial class EditUser : Window
    {
        int id;
        public EditUser(DataRow dr)
        {
            InitializeComponent();
            id = Convert.ToInt32(dr[0]);
            textboxFirstname.Text = Convert.ToString(dr[1].ToString());
            textboxLastname.Text = Convert.ToString(dr[2].ToString());
            textboxEmail.Text = Convert.ToString(dr[3].ToString());
            PickGender(Convert.ToString(dr[4].ToString()));
            datePicker.SelectedDate = DateTime.Parse(dr[5].ToString());
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateUser();
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void PickGender(string gender)
        {
            if (gender.ToLower().Equals("männlich"))
            {
                radioButtonMale.IsChecked = true;
            }

            if (gender.ToLower().Equals("weiblich"))
            {
                radioButtonFemale.IsChecked = true;
            }
        }        

        private void UpdateUser()
        {            
            new DatabaseHelper().DoNonQuery($"UPDATE [TablePeople] " +
                                            $"SET Firstname ='{textboxFirstname.Text}'," +
                                            $"Lastname = '{textboxLastname.Text}'," +
                                            $"[E-Mail] = '{textboxEmail.Text}'," +
                                            $"Geschlecht = '{new Helper().RadioButtonToString(radioButtonMale,radioButtonFemale)}'," +
                                            $"Geburtsdatum = '{datePicker.SelectedDate.Value.Date.ToString()}' " +
                                            $"WHERE ID = '{id}'");
            MessageBox.Show("Änderungen übernommen!");
        }
    }
}
