using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Configuration;

namespace WpfApplication_Zach
{
    class DatabaseHelper
    {

        private string connectionString = ConfigurationManager.ConnectionStrings["WpfApplication_Zach.Properties.Settings.WPFApp_DataBaseConnectionString"].ConnectionString;
        
        public void DoNonQuery(string query)
        {
            try
            {
                SqlConnection connection =  new SqlConnection(connectionString);
                connection.Open();
                SqlDataAdapter sda = new SqlDataAdapter(query, connection);
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch(SqlException e) 
            { 
                MessageBox.Show(e.Message);
            }            
        }

        public DataSet DoQuery(string query)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                SqlDataAdapter sda = new SqlDataAdapter(query, connection);
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                sda.Fill(ds, "Table");
                connection.Close();

                return ds;
            }
            catch (SqlException e) 
            {
                MessageBox.Show(e.Message); 
                return null;
            }        
        }
    }
}
