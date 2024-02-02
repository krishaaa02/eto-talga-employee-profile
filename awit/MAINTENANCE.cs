using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace awit
{
    public partial class MAINTENANCE : Form
    {
        public MAINTENANCE()
        {
            InitializeComponent();
        }

        private void save_Click(object sender, EventArgs e)
        {
            string connection = "server=localhost;user id=root;password=;database=maintenance";
            string query = "INSERT INTO tbl_maintenance(`OCCUPANT ID`, `EMPLOYEE ASSIGNED`, `MAINTENANCE`, `DATE ISSUED`, `DATE FIXED`) VALUES(@OccupantId, @EmployeeAssigned, @Maintenance, @DateIssued, @DateFixed)";

            using (MySqlConnection conn = new MySqlConnection(connection))
            {
                try
                {
                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        
                        cmd.Parameters.AddWithValue("@OccupantId", txtoccupantid.Text);
                        cmd.Parameters.AddWithValue("@EmployeeAssigned", txtemployeeassigned.Text);
                        cmd.Parameters.AddWithValue("@Maintenance", txtmaintenance.Text);
                        cmd.Parameters.AddWithValue("@DateIssued", txtdateissued.Text); 
                        cmd.Parameters.AddWithValue("@DateFixed", txtdatefixed.Text);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Successfully saved!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving record: " + ex.Message);
                    MessageBox.Show("Error connecting to the database: " + ex.Message);
                }
            }
        }

        private void x_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void update_Click(object sender, EventArgs e)
        {
            string connection = "server=localhost;user id=root;password=;database=maintenance";
            string query = "UPDATE tbl_maintenance SET `OCCUPANT ID`=@OccupantId, `EMPLOYEE ASSIGNED`=@EmployeeAssigned, `MAINTENANCE`=@Maintenance, `DATE ISSUED`=@DateIssued, `DATE FIXED`=@DateFixed WHERE `ROOM NUMBER`=@RoomNumber";

            using (MySqlConnection conn = new MySqlConnection(connection))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@OccupantId", this.txtoccupantid.Text);
                    cmd.Parameters.AddWithValue("@EmployeeAssigned", this.txtemployeeassigned.Text);
                    cmd.Parameters.AddWithValue("@Maintenance", this.txtmaintenance.Text);
                    cmd.Parameters.AddWithValue("@DateIssued", this.txtdateissued.Text);
                    cmd.Parameters.AddWithValue("@DateFixed", this.txtdatefixed.Text);
                    cmd.Parameters.AddWithValue("@RoomNumber", this.txtroomnum.Text);

                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show(" Maintenance record has been updated successfully ");
            }
        }
    }
}