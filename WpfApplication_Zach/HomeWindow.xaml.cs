using System;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;


namespace WpfApplication_Zach
{
    public partial class HomeWindow : Window
    {
        public HomeWindow()
        {
            InitializeComponent();
            GetLinqList();
        } 

        private void newButton_Click(object sender, RoutedEventArgs e)
        {
            new NewUser().Show();
        }

        private void edit_Click2(object sender, RoutedEventArgs e)
        {
            if (listBox.SelectedItem != null)
            {
                string firstname = listBox.SelectedItem.ToString().Split(' ')[0];
                string lastname = listBox.SelectedItem.ToString().Split(' ')[1];

                DataSet ds = new DatabaseHelper().DoQuery($"SELECT * FROM [TablePeople] " +
                                                          $"WHERE Firstname = '{firstname}' " +
                                                          $"AND Lastname ='{lastname}'");
                new EditUser(ds.Tables[0].Rows[0],this).Show();
            }
        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {
            if (listBox.SelectedItem != null)
            {
                string firstname = listBox.SelectedItem.ToString().Split(' ')[0];
                string lastname = listBox.SelectedItem.ToString().Split(' ')[1];

                DataClasses1DataContext dc = new DataClasses1DataContext();

                var selectQuery = from creds in dc.GetTable<TablePeople>()
                                  where creds.Firstname == firstname && creds.Lastname == lastname
                                  select creds;

                new EditUser(selectQuery, this).Show();
            }
        }

        private void deleteButton_Click2(object sender, RoutedEventArgs e)
        {
            try
            {
                if (listBox.SelectedItem != null)
                {
                    string firstname = listBox.SelectedItem.ToString().Split(' ')[0];
                    string lastname = listBox.SelectedItem.ToString().Split(' ')[1];

                    if (MessageBox.Show($"Wollen Sie {firstname} {lastname} löschen?", "SafeDelete", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                    {
                        new DatabaseHelper().DoNonQuery($"DELETE FROM [TablePeople] " +
                                                        $"WHERE Firstname = '{firstname}' " +
                                                        $"AND Lastname ='{lastname}'");
                        try
                        {
                            listBox.Items.RemoveAt(listBox.Items.IndexOf(listBox.SelectedItem));
                        }
                        catch (System.ArgumentOutOfRangeException ex) { MessageBox.Show(ex.ToString()); }
                    }
                }
            }
            catch (NullReferenceException ex) { MessageBox.Show(ex.ToString()); }
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (listBox.SelectedItem != null)
                {
                    string firstname = listBox.SelectedItem.ToString().Split(' ')[0];
                    string lastname = listBox.SelectedItem.ToString().Split(' ')[1];

                    if (MessageBox.Show($"Wollen Sie {firstname} {lastname} löschen?", "SafeDelete", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                    {
                        DataClasses1DataContext dc = new DataClasses1DataContext();


                        var deleteQuery = (from emp in dc.GetTable<TablePeople>()
                                           where emp.Firstname == firstname
                                           && emp.Lastname == lastname
                                           select emp).FirstOrDefault();
                        dc.TablePeople.DeleteOnSubmit(deleteQuery);
                        dc.SubmitChanges();
                                          
                                          
                        try
                        {
                            listBox.Items.RemoveAt(listBox.Items.IndexOf(listBox.SelectedItem));
                        }
                        catch (System.ArgumentOutOfRangeException ex) { MessageBox.Show(ex.ToString()); }
                    }
                }
            }
            catch (NullReferenceException ex) { MessageBox.Show(ex.ToString()); }
        }

        private void logoutButton_Click(object sender, RoutedEventArgs e)
        {
            //System.Windows.Application.Current.Shutdown();
            this.Close();
            MainWindow main = new MainWindow();
            main.Show();
        }

        private void GetList()
        {
            listBox.Items.Clear();            
            DataSet ds = new DatabaseHelper().DoQuery("SELECT * FROM [TablePeople]");

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                listBox.Items.Add(Convert.ToString(dr[1].ToString()) + " " + Convert.ToString(dr[2].ToString()));
            }
            labelTimestamp.Content = $"Datensatz erstellt am: {DateTime.Today.Date.ToString("dd/MM/yyyy")}";
        }

        public static void DoRefresh(HomeWindow homeWindow)
        {
            homeWindow.GetList();
        }

        private void listBox_SelectionChanged2(object sender, SelectionChangedEventArgs e)
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

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            listView.Items.Clear();
            if (listBox.SelectedItem != null)
            {
                string firstname = listBox.SelectedItem.ToString().Split(' ')[0];
                string lastname = listBox.SelectedItem.ToString().Split(' ')[1];

                DataClasses1DataContext dc = new DataClasses1DataContext();

                var selectQuery = from a in dc.GetTable<TablePeople>()
                                  where a.Firstname == firstname && a.Lastname == lastname
                                  select a;
                FillTable(selectQuery);
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

        private void FillTable(IQueryable query)
        {
            foreach (TablePeople people in query)
            {
                listView.Items.Add($"Anrede: \t\t{new Helper().GetTitle(people.Geschlecht)}");
                listView.Items.Add($"Vorname: \t{people.Firstname}");
                listView.Items.Add($"Nachname:\t{people.Lastname}");
                listView.Items.Add($"");
                listView.Items.Add($"E-Mail:  \t\t{people.E_Mail}");
                listView.Items.Add($"Geboren: \t{people.Geburtstag}");
            }
        }

        private void GetLinqList()
        {

            listBox.Items.Clear();
            DataClasses1DataContext dc = new DataClasses1DataContext();
            var selectQuery = from a in dc.GetTable<TablePeople>()
                              select a;

            foreach (TablePeople table in selectQuery)
            {
                listBox.Items.Add($"{table.Firstname} {table.Lastname}");
            }
        }

        private void LoadList(object sender, RoutedEventArgs e)
        {
            GetLinqList();
        }
    }
}
