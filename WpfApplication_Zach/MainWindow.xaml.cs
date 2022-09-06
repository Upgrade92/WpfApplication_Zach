using System;
using System.Data;
using System.Windows;
using System.Windows.Input;

namespace WpfApplication_Zach
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            labelNote.Content = "Admin\nAdmin";
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

        private void closeButtonclick(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void DoLogin()
        {
            string username = usernameBox.Text.ToString();
            string password = passwordBox.Password.ToString();

            DataSet ds = new DatabaseHelper().DoQuery("SELECT * FROM [Table] " +
                                                          "Where Username = '" + username + "' " +
                                                          "AND Password = '" + password + "'");
            try
            {
                if (ds.Tables.Count == 1)
                {
                    MessageBox.Show("Login erfolgreich!\n");
                    MainWindow mainWindow = this;
                    mainWindow.Hide();
                    HomeWindow home = new HomeWindow();
                    home.Show();
                }
            }
            catch (IndexOutOfRangeException)
            {
                MessageBox.Show("Benutzerdaten unbekannt!");
            }
        }
    }
}
