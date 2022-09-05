using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfApplication_Zach
{
    class DatabaseHelper
    {
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Admin\source\repos\WpfApplication_Zach\WpfApplication_Zach\Database1.mdf;Integrated Security=True";

        public string ConnectionString { get { return connectionString; } }
        public void DoNonQuery(string query)
        {
            try
            {
                SqlConnection connection = new SqlConnection(this.ConnectionString);
                connection.Open();
                SqlDataAdapter sda = new SqlDataAdapter(query, connection);
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch(SqlException) { }
        }

        public DataSet DoQuery(string query)
        {
            try
            {
                SqlConnection connection = new SqlConnection(this.ConnectionString);
                connection.Open();
                SqlDataAdapter sda = new SqlDataAdapter(query, connection);
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                sda.Fill(ds, "Table");
                connection.Close();
                return ds;
            }
            catch (SqlException) { return null; }
            
        }

    }
}
