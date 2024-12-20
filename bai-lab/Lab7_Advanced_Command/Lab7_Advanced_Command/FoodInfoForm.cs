﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab7_Advanced_Command
{
    public partial class FoodInfoForm : Form
    {
        public FoodInfoForm()
        {
            InitializeComponent();
        }

        private void InitValues()
        {
            string connectionString = "server = ADMIN-PC\\SQLEXPRESS; database = RestaurantManagement; Integrated Security = true; ";
            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT ID, Name FROM Category";

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            conn.Open();

            adapter.Fill(ds, "Category");

            cbbCatName.DataSource = ds.Tables["Category"];
            cbbCatName.DisplayMember = "Name";
            cbbCatName.ValueMember = "ID";

            conn.Close();
            conn.Dispose();
        }

        private void ResetText()
        {
            txtFoodID.ResetText();
            txtName.ResetText();
            txtNotes.ResetText();
            txtUnit.ResetText();
            cbbCatName.ResetText();
            nudPrice.ResetText();
        }

        private void FoodInfoForm_Load(object sender, EventArgs e)
        {
            this.InitValues();
        }

        public void DisplayFoodInfo(DataRowView rowView)
        {
            try
            {
                txtFoodID.Text = rowView["ID"].ToString();
                txtName.Text = rowView["Name"].ToString();
                txtUnit.Text = rowView["Unit"].ToString();
                txtNotes.Text = rowView["Notes"].ToString();
                nudPrice.Value = (int)rowView["Price"];

                cbbCatName.SelectedIndex = -1;

                for (int index = 0; index < cbbCatName.Items.Count; index++)
                {
                    DataRowView cat = cbbCatName.Items[index] as DataRowView;
                    if (cat["ID"].ToString() == rowView["FoodCategoryID"].ToString())
                    {
                        cbbCatName.SelectedIndex = index;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                this.Close();
            }
        }

        private void btnAddFood_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = "server = ADMIN-PC\\SQLEXPRESS; database = RestaurantManagement; Integrated Security = true; ";
                SqlConnection conn = new SqlConnection(connectionString);

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "EXECUTE InsertFood @id OUTPUT, @name, @unit, @foodCategoryID, @price, @notes";

                cmd.Parameters.Add("@id", SqlDbType.Int);
                cmd.Parameters.Add("@name", SqlDbType.NVarChar, 1000);
                cmd.Parameters.Add("@unit", SqlDbType.NVarChar, 100);
                cmd.Parameters.Add("@foodCategoryId", SqlDbType.Int);
                cmd.Parameters.Add("@price", SqlDbType.Int);
                cmd.Parameters.Add("@notes", SqlDbType.NVarChar, 3000);

                cmd.Parameters["@id"].Direction = ParameterDirection.Output;

                cmd.Parameters["@name"].Value = txtName.Text;
                cmd.Parameters["@unit"].Value = txtUnit.Text;
                cmd.Parameters["@foodCategoryId"].Value = cbbCatName.SelectedValue;
                cmd.Parameters["@price"].Value = nudPrice.Value;
                cmd.Parameters["@notes"].Value = txtNotes.Text;

                conn.Open();

                int numRowAffected = cmd.ExecuteNonQuery();

                if (numRowAffected > 0)
                {
                    string foodID = cmd.Parameters["@id"].Value.ToString();

                    MessageBox.Show("Successfully adding new food. Food ID = " + foodID, "Message");

                    this.ResetText();
                }
                else
                    MessageBox.Show("Adding food faild");

                conn.Close();
                conn.Dispose();
            }
            catch (SqlException exception)
            {
                MessageBox.Show(exception.Message, "SQL Error");
            }

            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error");
            }
        }

        private void btnUpdateFood_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = "server = ADMIN-PC\\SQLEXPRESS; database = RestaurantManagement; Integrated Security = true; ";
                SqlConnection conn = new SqlConnection(connectionString);

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "EXECUTE UpdateFood @id, @name, @unit, @foodCategoryID, @price, @notes";

                cmd.Parameters.Add("@id", SqlDbType.Int);
                cmd.Parameters.Add("@name", SqlDbType.NVarChar, 1000);
                cmd.Parameters.Add("@unit", SqlDbType.NVarChar, 100);
                cmd.Parameters.Add("@foodCategoryId", SqlDbType.Int);
                cmd.Parameters.Add("@price", SqlDbType.Int);
                cmd.Parameters.Add("@notes", SqlDbType.NVarChar, 3000);

                cmd.Parameters["@id"].Value = int.Parse(txtFoodID.Text);
                cmd.Parameters["@name"].Value = txtName.Text;
                cmd.Parameters["@unit"].Value = txtUnit.Text;
                cmd.Parameters["@foodCategoryId"].Value = cbbCatName.SelectedValue;
                cmd.Parameters["@price"].Value = nudPrice.Value;
                cmd.Parameters["@notes"].Value = txtNotes.Text;

                conn.Open();

                int numRowAffected = cmd.ExecuteNonQuery();

                if (numRowAffected > 0)
                {
                    MessageBox.Show("Successfully updating food", "Message");

                    this.ResetText();
                }
                else
                    MessageBox.Show("Updateting food failed");

                conn.Close();
                conn.Dispose();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SQL Error");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            frmFoodCategoryInfo categoryForm = new frmFoodCategoryInfo();
            categoryForm.FormClosed += new FormClosedEventHandler(categoryForm_FormClosed);

            categoryForm.Show(this); 
        }

        void categoryForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.InitValues();
        }
    }
}
