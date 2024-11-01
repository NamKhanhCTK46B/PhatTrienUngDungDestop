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

namespace Lab7_Advanced_Command
{
    public partial class frmFoodCategoryInfo : Form
    {
        public frmFoodCategoryInfo()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = "server = ADMIN-PC\\SQLEXPRESS; database = RestaurantManagement; Integrated Security = true; ";
                SqlConnection conn = new SqlConnection(connectionString);
                int t = 0;
                if (rdFood.Checked)
                    t = 1;

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "EXECUTE InsertFoodCategory @id OUTPUT, @name, @type";

                cmd.Parameters.Add("@id", SqlDbType.Int);
                cmd.Parameters.Add("@name", SqlDbType.NVarChar, 1000);
                cmd.Parameters.Add("@type", SqlDbType.Int);

                cmd.Parameters["@id"].Direction = ParameterDirection.Output;

                cmd.Parameters["@name"].Value = txtCategoryName.Text;
                cmd.Parameters["@type"].Value = t;

                conn.Open();

                int numRowAffected = cmd.ExecuteNonQuery();

                if (numRowAffected > 0)
                {
                    string categoryID = cmd.Parameters["@id"].Value.ToString();

                    MessageBox.Show("Successfully adding new foodcategory. Category ID = " + categoryID, "Notification",
                                    MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Adding food category failed. Please try again", "Notification", 
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                conn.Close();
                conn.Dispose();
            }
            catch (SqlException ex)
            {

                MessageBox.Show(ex.Message, "SQL Error");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
    }
}
