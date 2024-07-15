using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Host
{
    public partial class Main : Form
    {
        string ConnectionString = "server=DESKTOP-NFV331T\\SQLEXPRESS;initial catalog=Shabat;user id=sa;password=1234; TrustServerCertificate=Yes;";
        SqlConnection Connection;
        public Main()
        {
            InitializeComponent();
            ShowAllCategories("");
        }
        private bool Connect()
        {
            try
            {
                Connection = new SqlConnection(ConnectionString);
                Connection.Open();
                return true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        private void ShowAllCategories(string name)
        {
            string select = "select name from categories where name like '%'+@name+'%'";
            if (Connect())
            {
                SqlCommand command = new SqlCommand(select, Connection);
                command.Parameters.AddWithValue("@name", name);
                SqlDataReader reader = command.ExecuteReader();
                lstCategory.Items.Clear();
                if (reader.HasRows) //בדיקה האם קיימות שורות בטבלה
                    while (reader.Read())//ריצה על כל השורות במבנה טבלאי
                    {
                        lstCategory.Items.Add(reader[0].ToString());
                    }
                Connection.Close();

            }
        }
        private void btnEnterCategory_Click(object sender, EventArgs e)
        {
            string insert = "if(@name_category != '')\r\n\tbegin\r\n\tif not exists(select name from Categories where name=@name_category)\r\n\t\tbegin\r\n\t\t\tinsert into Categories values(@name_category)\r\n\t\tend\r\n\tend";
            if (Connect()) 
            {
                SqlCommand command = new SqlCommand(insert, Connection);
                command.Parameters.AddWithValue("@name_category",txtCategory.Text);
                int updateRows = command.ExecuteNonQuery();
                Connection.Close();
                if(updateRows > 0)ShowAllCategories("");
                txtCategory.Text = string.Empty;
            }

        }

        private void txtCategory_TextChanged(object sender, EventArgs e)
        {
            ShowAllCategories(txtCategory.Text);
        }
    }
}
