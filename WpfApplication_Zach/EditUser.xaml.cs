using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaktionslogik für EditUser.xaml
    /// </summary>
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
            new DatabaseHelper().DoNonQuery($"UPDATE INTO [TablePeople] (Id, Firstname,Lastname,[E-Mail],Geschlecht, Geburtsdatum) VALUES('{id}','{textboxFirstname.Text}','{textboxLastname.Text}','{textboxEmail.Text}','{new Helper().RadioButtonToString(radioButtonMale,radioButtonFemale)}','{datePicker.SelectedDate.Value.Date.ToString()}')");
            MessageBox.Show("Änderungen übernommen!");
        }
    }
}
