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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication_Zach
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
           
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            passwordBox.Visibility = Visibility.Hidden;
            passwordTextBox.Visibility = Visibility.Visible;     
        }
        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            passwordBox.Visibility = Visibility.Visible;
            passwordTextBox.Visibility = Visibility.Hidden;
        }

        void PasswordChangedHandler(Object sender, RoutedEventArgs args)
        {
            passwordTextBox.Text = passwordBox.Password;
            IsEmptyPassword();
        }
        void PasswordTextChangedHandler(Object sender, RoutedEventArgs args)
        {
            passwordBox.Password = passwordTextBox.Text;
            IsEmptyPassword();
        }

        private void IsEmptyPassword()
        {
            new Helper().TextBoxChanged(passwordTextBox, passwordBoxWatermark);                    
        }

        void UsernameBoxChangedHandler(Object sender, RoutedEventArgs args)
        {
            new Helper().TextBoxChanged(usernameBox, usernameWatermark);        
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            DoLogin();
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Return)
            {
                DoLogin();
            }
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void DoLogin()
        {
            string username = usernameBox.Text.ToString();
            string password = passwordBox.Password.ToString();
            SqlConnection connection = new SqlConnection(new DatabaseHelper().ConnectionString);
            try
            {
                connection.Open();
                string querry = "SELECT * FROM [Table] Where Username = '" + username + "' AND Password = '" + password + "'";
                SqlDataAdapter sda = new SqlDataAdapter(querry, connection);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                
                try
                {
                    UserAccount user = new UserAccount(username, password, Convert.ToInt32(dt.Rows[0][3]));

                    if (dt.Rows.Count == 1)
                    {
                        MessageBox.Show("Login successfully!\n" + user.UserName + "\n" + user.Password + "\n" + user.Permission);
                        MainWindow mainWindow = this;
                        mainWindow.Hide();
                        HomeWindow home = new HomeWindow();
                        home.Show();
                    }
                    connection.Close();
                }
                catch (IndexOutOfRangeException)
                {
                    MessageBox.Show("invalid credentials!");
                }
            }
            catch(SqlException)  {  }
        }
    }
}
