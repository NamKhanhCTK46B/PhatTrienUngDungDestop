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
using System.Collections.Generic;

namespace Lab6_Basic_Command
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void DisplayCategory(SqlDataReader reader)
        {
            lvCategory.Items.Clear();

            while (reader.Read())
            {
                ListViewItem item = new ListViewItem(reader["ID"].ToString());
                lvCategory.Items.Add(item);
                item.SubItems.Add(reader["Name"].ToString());
                item.SubItems.Add(reader["Type"].ToString());
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            string connectionString = "server = Admin-PC\\SQLEXPRESS; database = RestaurantManagement; Integrated Security = true;";

            SqlConnection sqlConnection = new SqlConnection(connectionString);

            SqlCommand sqlCommand = sqlConnection.CreateCommand();

            string query = "SELECT ID, Name, Type FROM Category";
            sqlCommand.CommandText = query;

            sqlConnection.Open();

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            this.DisplayCategory(sqlDataReader);

            sqlConnection.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string connectionString = "server = Admin-PC\\SQLEXPRESS; database = RestaurantManagement; Integrated Security = true;";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            SqlCommand sqlCommand = sqlConnection.CreateCommand();

            sqlCommand.CommandText = "INSERT INTO Category(Name, [Type])" +
                                    "VALUES (N'" + txtName.Text + "', " + txtType.Text + ")";

            sqlConnection.Open();

            int numOfRowsEffected = sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();

            if (numOfRowsEffected == 1)
            {
                MessageBox.Show("Thêm nhóm món ăn thành công");

                btnLoad.PerformClick();

                txtName.Text = "";
                txtType.Text = "";
            }
            else
            {
                MessageBox.Show("Đã có lỗi xảy ra");
            }
        }

        private void lvCategory_Click(object sender, EventArgs e)
        {
            ListViewItem lvitem = lvCategory.SelectedItems[0];

            txtID.Text = lvitem.Text;
            txtName.Text = lvitem.SubItems[1].Text;
            txtType.Text = lvitem.SubItems[2].Text == "0" ? "Thức uống" : "Đồ ăn";

            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string connectionString = "server = Admin-PC\\SQLEXPRESS; database = RestaurantManagement; Integrated Security = true;";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            SqlCommand sqlCommand = sqlConnection.CreateCommand();

            sqlCommand.CommandText = "UPDATE Category SET Name = N'" + txtName.Text + "', [Type] = " + txtType.Text + "  WHERE ID = " + txtID.Text ;  
            sqlConnection.Open();

            int numOfRowsEffected = sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();

            if (numOfRowsEffected == 1) 
            {
                ListViewItem item = lvCategory.SelectedItems[0];

                item.SubItems[1].Text = txtName.Text;
                item.SubItems[2].Text = txtType.Text;

                txtID.Text = "";
                txtName.Text = "";
                txtType.Text = "";

                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;

                MessageBox.Show("Cập nhật món ăn thành công");
            }
            else
            {
                MessageBox.Show("Đã có lỗi xảy ra, Vui lòng thử lại");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string connectionString = "server = Admin-PC\\SQLEXPRESS; database = RestaurantManagement; Integrated Security = true;";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = "DELETE FROM Category " + "WHERE ID = " + txtID.Text;

            sqlConnection.Open();

            int numOfRowsEffected = sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();

            if (numOfRowsEffected == 1)
            {
                ListViewItem item = lvCategory.SelectedItems[0];
                lvCategory.Items.Remove(item);

                txtID.Text = "";
                txtName.Text = "";
                txtType.Text = "";

                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;

                MessageBox.Show("Xoá nhóm món ăn thành công");
            }

            else
            {
                MessageBox.Show("Đã có lỗi xảy ra, Vui lòng thử lại");
            }
        }

        private void tsmDelete_Click(object sender, EventArgs e)
        {
            if (lvCategory.SelectedItems.Count > 0) 
            { 
                btnDelete.PerformClick();
            }
        }

        private void tsmViewFood_Click(object sender, EventArgs e)
        {
            if (txtID.Text != "")
            {
               frmFood foodForm = new frmFood();
                foodForm.Show(this);
                foodForm.LoadFood(Convert.ToInt32(txtID.Text));
            }    
        }
    }
}
