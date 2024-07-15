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

namespace Guests
{
    public partial class Main : Form
    {
        public string ConnectionString = "server=DESKTOP-NFV331T\\SQLEXPRESS;initial catalog=Shabat;user id=sa;password=1234; TrustServerCertificate=Yes;";
        public SqlConnection Connection;
        public Main()
        {
            InitializeComponent();
            ShowAllGuests("");
        }
        public bool Connect()
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
        private void ShowAllGuests(string name)
        {
            string select = "select name from guests where name like '%'+@name+'%'";
            if (Connect())
            {
                SqlCommand command = new SqlCommand(select, Connection);
                command.Parameters.AddWithValue("@name", name);
                SqlDataReader reader = command.ExecuteReader();
                lstGuestsName.Items.Clear();
                if (reader.HasRows) //בדיקה האם קיימות שורות בטבלה
                    while (reader.Read())//ריצה על כל השורות במבנה טבלאי
                    {
                        lstGuestsName.Items.Add(reader[0].ToString());
                    }
                Connection.Close();

            }
        }

        private void btnEnterGuestName_Click(object sender, EventArgs e)
        {
            string insert = "if(@name_guest != '')\r\n\tbegin\r\n\tif not exists(select name from Guests where name=@name_guest)\r\n\t\tbegin\r\n\t\t\tinsert into Guests values(@name_guest)\r\n\t\tend\r\n\tend\r\n";
            if (Connect())
            {
                SqlCommand command = new SqlCommand(insert, Connection);
                command.Parameters.AddWithValue("@name_guest", txtGuestName.Text);
                int updateRows = command.ExecuteNonQuery();
                Connection.Close();
                if (updateRows > 0) ShowAllGuests("");
                ShowCategories(txtGuestName.Text);
                txtGuestName.Text = string.Empty;
                Connection.Close();                
            }

        }
        private void ShowCategories(string name)//מקבל שם אורח
        {
            if (name == "") return;
            string select = "select name from Categories";
            if (Connect())
            {
                SqlCommand command = new SqlCommand(select, Connection);
                SqlDataReader reader= command.ExecuteReader();               
                List<Categories> categories = new List<Categories>();
                int index = 0;
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        categories.Add(new Categories(this, reader[0].ToString(),name,index++));
                    }
                    categories.First().SetCategories = categories;
                    categories.First().Show();
                }
            }
        }

        private void lstGuestsName_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtGuestName.Text = lstGuestsName.Text;
        }

        private void txtGuestName_TextChanged(object sender, EventArgs e)
        {
            ShowAllGuests(txtGuestName.Text);
        }
    }
}
