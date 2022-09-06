using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;


namespace WpfApplication_Zach
{
    public partial class HomeWindow : Window
    {
        public HomeWindow()
        {
            InitializeComponent();
            LoadList();
        } 

        private void newButton_Click(object sender, RoutedEventArgs e)
        {
            new NewUser().Show();
        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {
            if (listBox.SelectedItem != null)
            {
                string firstname = listBox.SelectedItem.ToString().Split(' ')[0];
                string lastname = listBox.SelectedItem.ToString().Split(' ')[1];

                DataSet ds = new DatabaseHelper().DoQuery($"SELECT * FROM [TablePeople] " +
                                                          $"WHERE Firstname = '{firstname}' " +
                                                          $"AND Lastname ='{lastname}'");
                new EditUser(ds.Tables[0].Rows[0]).Show();
            }
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (listBox.SelectedItem != null)
                {
                    string firstname = listBox.SelectedItem.ToString().Split(' ')[0];
                    string lastname = listBox.SelectedItem.ToString().Split(' ')[1];

                    if (MessageBox.Show($"You Sure you want to delete {firstname} {lastname}?", "SafeDelete", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                    {
                        new DatabaseHelper().DoNonQuery($"DELETE FROM [TablePeople] " +
                                                        $"WHERE Firstname = '{firstname}' " +
                                                        $"AND Lastname ='{lastname}'");
                        try
                        {
                            listBox.Items.RemoveAt(listBox.Items.IndexOf(listBox.SelectedItem));
                        }
                        catch (System.ArgumentOutOfRangeException) { }
                    }
                }
            }
            catch (NullReferenceException) { }
        }

        private void logoutButton_Click(object sender, RoutedEventArgs e)
        {
            //System.Windows.Application.Current.Shutdown();
            this.Close();
            MainWindow main = new MainWindow();
            main.Show();
        }

        private void LoadList()
        {
            listBox.Items.Clear();            
            DataSet ds = new DatabaseHelper().DoQuery("SELECT * FROM [TablePeople]");

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                listBox.Items.Add(Convert.ToString(dr[1].ToString()) + " " + Convert.ToString(dr[2].ToString()));
            }
            labelTimestamp.Content = $"Datensatz erstellt am: {DateTime.Today.Date.ToString("dd/MM/yyyy")}";
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            listView.Items.Clear();
            if (listBox.SelectedItem != null) { 
            string firstname = listBox.SelectedItem.ToString().Split(' ')[0];
            string lastname = listBox.SelectedItem.ToString().Split(' ')[1];

                DataSet ds = new DatabaseHelper().DoQuery($"SELECT * FROM [TablePeople] " +
                                                          $"WHERE Firstname = '{firstname}' " +
                                                          $"AND Lastname ='{lastname}'");
                FillTable(ds);                         
            }
        }

        private void FillTable(DataSet ds)
        {
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                listView.Items.Add($"Anrede: \t\t{new Helper().GetTitle(Convert.ToString(dr[4].ToString()))}");
                listView.Items.Add($"Vorname: \t{Convert.ToString(dr[1].ToString())}");
                listView.Items.Add($"Nachname:\t{Convert.ToString(dr[2].ToString())}");
                listView.Items.Add($"");
                listView.Items.Add($"E-Mail:  \t\t{Convert.ToString(dr[3].ToString())}");
                listView.Items.Add($"Geboren: \t{Convert.ToString(dr[5].ToString().Split(' ')[0])}");
            }
        }

        private void LoadList(object sender, RoutedEventArgs e)
        {
            LoadList();
        }
    }
}
