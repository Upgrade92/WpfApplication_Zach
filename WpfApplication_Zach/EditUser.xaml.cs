using System;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace WpfApplication_Zach
{
    public partial class EditUser : Window
    {
        int id;
        HomeWindow homeWindow;
        public EditUser(DataRow dr,HomeWindow window)
        {
            InitializeComponent();
            homeWindow = window;
            id = Convert.ToInt32(dr[0]);
            textboxFirstname.Text = Convert.ToString(dr[1].ToString());
            textboxLastname.Text = Convert.ToString(dr[2].ToString());
            textboxEmail.Text = Convert.ToString(dr[3].ToString());
            PickGender(Convert.ToString(dr[4].ToString()));
            datePicker.SelectedDate = DateTime.Parse(dr[5].ToString());
        }

        public EditUser(IQueryable query, HomeWindow window)
        {
            
            InitializeComponent();
            homeWindow = window;
            foreach (TablePeople tbl in query)
            {
                id = Convert.ToInt32(tbl.Id);
                textboxFirstname.Text = tbl.Firstname;
                textboxLastname.Text = tbl.Lastname;
                textboxEmail.Text = tbl.E_Mail;
                PickGender(tbl.Geschlecht);
                datePicker.SelectedDate = DateTime.Parse(tbl.Geburtstag);
            }
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            if (CheckAll())
            {
                UpdateUser();
            }
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

        private void UpdateUser2()
        {            
            new DatabaseHelper().DoNonQuery($"UPDATE [TablePeople] " +
                                            $"SET Firstname ='{textboxFirstname.Text}'," +
                                            $"Lastname = '{textboxLastname.Text}'," +
                                            $"[E-Mail] = '{textboxEmail.Text}'," +
                                            $"Geschlecht = '{new Helper().RadioButtonToString(radioButtonMale,radioButtonFemale)}'," +
                                            $"Geburtstag = '{datePicker.SelectedDate.Value.Date.ToString()}' " +
                                            $"WHERE ID = '{id}'");
            MessageBox.Show("Änderungen übernommen!");
            HomeWindow.DoRefresh(homeWindow);
        }

        private void UpdateUser()
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();

            TablePeople tablePeople = dc.TablePeople.FirstOrDefault(empl => empl.Id == id);
            tablePeople.Firstname = textboxFirstname.Text;
            tablePeople.Lastname = textboxLastname.Text;
            tablePeople.E_Mail = textboxEmail.Text;
            tablePeople.Geschlecht = new Helper().RadioButtonToString(radioButtonMale, radioButtonFemale);
            tablePeople.Geburtstag = datePicker.SelectedDate.Value.Date.ToString();

            dc.SubmitChanges();

            MessageBox.Show("Änderungen übernommen!");
            HomeWindow.DoRefresh(homeWindow);
        }

        private bool CheckAll()
        {
            bool check1 = new Helper().TextboxFilled(textboxFirstname);
            bool check2 = new Helper().TextboxFilled(textboxLastname);
            bool check3 = new Helper().TextboxFilled(textboxEmail,new Helper().EmailValidation(textboxEmail));
            bool check4 = new Helper().DatePicked(datePicker);

            if(check1 && check2 && check3 && check4)
            {
                return true;
            }
            else { return false; }
        }
    }
}
