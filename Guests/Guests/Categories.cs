using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Guests
{
    public partial class Categories : Form
    {
        Main Parent;
        static List<Categories> GetCategories;
        int Index;
        public Categories(Main parent,string categoryName,string guestName,int index)
        {
            InitializeComponent();
            Parent = parent;
            lblCategoryName.Text = categoryName;
            lblGuestName.Text = guestName;
            Index = index;
            ShowAllChoice();
            ShowGuestChoice();
        }
        public List<Categories> SetCategories
        {
            set { GetCategories = value; }
        }

        private void ShowAllChoice()
        {
            string select = "select Food.name as 'שם מאכל'\r\nfrom Food inner join Categories on Food.Category_ID=Categories.ID\r\ninner join Guests on Food.Guest_ID = Guests.ID\r\n where Categories.name='"+lblCategoryName.Text+"'";
            SqlDataAdapter adapter = new SqlDataAdapter(select,Parent.ConnectionString);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dgvAllChoice.DataSource = dt;
        }
        private void ShowGuestChoice()
        {
            string select = "select Food.name as 'שם מאכל'\r\nfrom Food inner join Categories on Food.Category_ID=Categories.ID\r\ninner join Guests on Food.Guest_ID = Guests.ID\r\nwhere Categories.name='"+lblCategoryName.Text+"' and Guests.name='"+lblGuestName.Text+"'";
            SqlDataAdapter adapter = new SqlDataAdapter(select,Parent.ConnectionString);
            
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dgvGuestChoice.DataSource = dt;
        }

        private void btBack_Click(object sender, EventArgs e)
        {
            Visible = false;
            if(Index > 0) GetCategories[Index-1].Visible = true;
        }

        private void btForward_Click(object sender, EventArgs e)
        {
            Visible = false;
            if(Index<GetCategories.Count()-1) GetCategories[Index+1].Visible = true;
        }
        private void InsertFood(string food)
        {
            if(food =="")return;
            string insert = "insert into Food values((select ID from Guests where name= '" + lblGuestName.Text + "'),\r\n(select ID from Categories where name= '" + lblCategoryName.Text + "'),'" + food + "')";
            if (Parent.Connect())
            {
                SqlCommand command=new SqlCommand(insert,Parent.Connection);
                int i = command.ExecuteNonQuery();
                Parent.Connection.Close();
                ShowAllChoice();
                ShowGuestChoice();
            }
        }

        private void btAddFood_Click(object sender, EventArgs e)
        {
            pAddFood.Visible = true;
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            if(txtAddFood.Text=="")return;
            InsertFood(txtAddFood.Text);
            pAddFood.Visible=false;
        }

        private void dgvAllChoice_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            InsertFood(dgvAllChoice[0, e.RowIndex].Value.ToString());
        }
    }
}
