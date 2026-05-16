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

namespace Login_System
{
    public partial class SuperAdminDashboard : Form
    {
        string cs = @"Data Source=DESKTOP-M3NBITM;Initial catalog=DoctorManagementDB;Integrated Security=True";
        public SuperAdminDashboard()
        {
            InitializeComponent();
        }

        private void btnViewUsers_Click(object sender, EventArgs e)
        {
            string cs = @"Data Source=DESKTOP-M3NBITM;Initial Catalog=DoctorManagementDB;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                string query = "SELECT UserId, Username, Role FROM Users";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvSuperAdmin.DataSource = dt;
            }
        }

        private void btnViewDoctors_Click(object sender, EventArgs e)
        {
            string cs = @"Data Source=DESKTOP-M3NBITM;Initial Catalog=DoctorManagementDB;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                string query = "SELECT * FROM Doctors";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvSuperAdmin.DataSource = dt;
            }
        }

        private void btnViewPatients_Click(object sender, EventArgs e)
        {
            string cs = @"Data Source=DESKTOP-M3NBITM;Initial Catalog=DoctorManagementDB;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                string query = "SELECT * FROM Patients";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvSuperAdmin.DataSource = dt;
            }
        }

        private void btnViewAppointments_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                string query = @"
       SELECT
           a.AppointmentId,
           p.Name AS Patient,
           d.Name AS Doctor,
           a.AppointmentDate,
           a.TimeSlot,
           a.Status
       FROM Appointments a
       JOIN Patients p
       ON a.PatientId = p.PatientId
       JOIN Doctors d
       ON a.DoctorId = d.DoctorId";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvSuperAdmin.DataSource = dt;
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Form1 login = new Form1();
            login.Show();
            this.Close();
        }

        private void dgvSuperAdmin_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
