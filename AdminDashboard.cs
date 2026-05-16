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
    public partial class AdminDashboard : Form
    {

        private int selectedDoctorTd = 0;
        private int selectedPatientId = 0;
        private int selectedAppointmentId = 0;
      

        public AdminDashboard()
        {
            InitializeComponent();
            LoadDashboardCounts();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void LoadDoctors()
        {
            string connectionString = @"Data Source=DESKTOP-M3NBITM;Initial Catalog=DoctorManagementDB;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "SELECT * FROM Doctors";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvDoctors.DataSource = dt;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panelContent.Visible = false;
            panelDoctor.Visible = true;
            panelDoctor.BringToFront();
            try
            {
                string connectionString = @"Data Source=DESKTOP-M3NBITM;Initial Catalog=DoctorManagementDB;Integrated Security=True";
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = "SELECT * FROM Doctors";
                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvDoctors.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

            panelContent.Visible = false;
            panelDoctor.Visible = true;
            panelDoctor.BringToFront();

            string connectionString = @"Data Source=DESKTOP-M3NBITM;Initial Catalog=DoctorManagementDB;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Slots", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvCommon.DataSource = dt;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAddDoctor_Click(object sender, EventArgs e)
        {
            // Validation
            if (txtName.Text == "" || txtSpeciality.Text == "" || txtPhone.Text == "")
            {
                MessageBox.Show("Please fill all fields");
                return;
            }

            string connectionString = @"Data Source=DESKTOP-M3NBITM;Initial Catalog=DoctorManagementDB;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "INSERT INTO Doctors (Name, Specialty, Phone, AvailabilityStatus) VALUES (@name, @specialty, @phone, @status)";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@name", txtName.Text);
                    cmd.Parameters.AddWithValue("@specialty", txtSpeciality.Text);
                    cmd.Parameters.AddWithValue("@phone", txtPhone.Text);
                    cmd.Parameters.AddWithValue("@status", "Available"); // default
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Doctor Added Successfully");
                }
            }
        }

        private int selectedDoctorId = 0;
        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvDoctors.Rows[e.RowIndex];
                selectedDoctorId = Convert.ToInt32(row.Cells["DoctorId"].Value);
                txtName.Text = row.Cells["Name"].Value.ToString();
                txtSpeciality.Text = row.Cells["Specialty"].Value.ToString();
                txtPhone.Text = row.Cells["Phone"].Value.ToString();
            }
        }

        private void btnUpdateDoctor_Click(object sender, EventArgs e)
        {

            // Validation
            if (txtName.Text == "" || txtSpeciality.Text == "" || txtPhone.Text == "")
            {
                MessageBox.Show("Please fill all fields");
                return;
            }

            if (selectedDoctorId == 0)
            {
                MessageBox.Show("Please select a doctor first");
                return;
            }
            string connectionString = @"Data Source=DESKTOP-M3NBITM;Initial Catalog=DoctorManagementDB;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "UPDATE Doctors SET Name=@name, Specialty=@specialty, Phone=@phone WHERE DoctorId=@id";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@name", txtName.Text);
                    cmd.Parameters.AddWithValue("@specialty", txtSpeciality.Text);
                    cmd.Parameters.AddWithValue("@phone", txtPhone.Text);
                    cmd.Parameters.AddWithValue("@id", selectedDoctorId);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Doctor Updated Successfully");
                }
            }
            LoadDoctors();
        }

        private void btnDeleteDoctor_Click(object sender, EventArgs e)
        {
            if (selectedDoctorId == 0)
            {
                MessageBox.Show("Please select a doctor first");
                return;
            }

            DialogResult result = MessageBox.Show("Are you sure you want to delete this doctor?",
                                    "Confirm Delete",
                                    MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                return;
            }

            string connectionString = @"Data Source=DESKTOP-M3NBITM;Initial Catalog=DoctorManagementDB;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "DELETE FROM Doctors WHERE DoctorId=@id";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@id", selectedDoctorId);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Doctor Deleted Successfully");
                }
            }
            LoadDoctors();

            txtName.Clear();
            txtSpeciality.Clear();
            txtPhone.Clear();
            selectedDoctorId = 0;
        }

        private void btnViewAppointments_Click(object sender, EventArgs e)
        {

            panelContent.Visible = false;
            panelDoctor.Visible = false;
            panelPatients.Visible = false;

            panelAppointments.Visible = true;
            panelAppointments.BringToFront();

            LoadAppointments();

            string connectionString = @"Data Source=DESKTOP-M3NBITM;Initial Catalog=DoctorManagementDB;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "SELECT * FROM Appointments";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvCommon.DataSource = dt;
            }
        }

        private void labelTitle_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelDoctor_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            panelDoctor.Visible = false;
            panelContent.Visible = true;
            panelContent.BringToFront();
        }

        private void dgvDoctors_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvDoctors_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvDoctors.Rows[e.RowIndex];
                txtName.Text = row.Cells["Name"].Value.ToString();
                txtSpeciality.Text = row.Cells["Specialty"].Value.ToString();
                txtPhone.Text = row.Cells["Phone"].Value.ToString();
                selectedDoctorId = Convert.ToInt32(row.Cells["DoctorId"].Value);
            }
        }

        private void txtSearchDoctor_TextChanged(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=DESKTOP-M3NBITM;Initial Catalog=DoctorManagementDB;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "SELECT * FROM Doctors WHERE Name LIKE @search";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@search", "%" + txtSearchDoctor.Text + "%");
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvDoctors.DataSource = dt;
                }
            }
        }

        private void AdminDashboard_Load(object sender, EventArgs e)
        {
            panelDoctor.Visible = false;
            panelContent.Visible = true;
            
        }

        private void dgvDoctors_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void lblTotalDoctors_Click(object sender, EventArgs e)
        {

        }

        private void panelContent_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelDoctor_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void lblSearch_Click(object sender, EventArgs e)
        {

        }

        private void btnAddPatient_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdatePatient_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=DESKTOP-M3NBITM;Initial Catalog=DoctorManagementDB;Integrated security=True";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                string query = "Update Patients SET Name=@Name, Age=@Age, Phone=@Phone, Gender=@Gender, Email=@Email WHERE PAtientId=@PatientId";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@Name", txtPatientName.Text);
                cmd.Parameters.AddWithValue("@Age", txtPatientAge.Text);
                cmd.Parameters.AddWithValue("@Phone", txtPatientPhone.Text);
                cmd.Parameters.AddWithValue("@Gender", txtPatientGender.Text);
                cmd.Parameters.AddWithValue("@Email", txtPatientEmail.Text);

                cmd.Parameters.AddWithValue("@PatientId", selectedPatientId);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Patient Updated Successfully");

                LoadPatients();
            }
        }

        private void btnDeletePatient_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=DESKTOP-M3NBITM;Initial Catalog=DoctorManagementDB;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "DELETE FROM Patients WHERE PatientId=@PatientId";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@PatientId", selectedPatientId);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Patient Deleted Successfully");
                LoadPatients();
            }
        }

        private void LoadPatients()
        {
            string connectionString = @"Data Source=DESKTOP-M3NBITM;Initial Catalog=DoctorManagementDB;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "SELECT * FROM Patients";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvPatients.DataSource = dt;
            }
        }

        private void LoadAppointments()
        {
            string connectionString = @"Data Source=DESKTOP-M3NBITM;Initial Catalog=DoctorManagementDB;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "SELECT * FROM Appointments";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvAppointments.DataSource = dt;
            }
        }

        private void btnViewPatient_Click(object sender, EventArgs e)
        {
            panelContent.Visible = false;
            panelDoctor.Visible = false;
            panelPatients.Visible = true;
            panelPatients.BringToFront();
            LoadPatients();
        }

        private void dgvPatients_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvPatients.Rows[e.RowIndex];
                txtPatientName.Text = row.Cells["Name"].Value.ToString();
                txtPatientPhone.Text = row.Cells["Phone"].Value.ToString();
                txtPatientAge.Text = row.Cells["Age"].Value.ToString();
                txtPatientGender.Text = row.Cells["Gender"].Value.ToString();
                txtPatientEmail.Text = row.Cells["Email"].Value.ToString();
                selectedPatientId = Convert.ToInt32(row.Cells["PatientId"].Value);
            }
        }

        private void btnAddPatient_Click_1(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=DESKTOP-M3NBITM;Initial Catalog=DoctorManagementDB;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "INSERT INTO Patients (Name, Age, Phone, Gender, Email) VALUES (@Name, @Age, @Phone, @Gender, @Email)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Name", txtPatientName.Text);
                cmd.Parameters.AddWithValue("@Age", txtPatientAge.Text);
                cmd.Parameters.AddWithValue("@Phone", txtPatientPhone.Text);
                cmd.Parameters.AddWithValue("@Gender", txtPatientGender.Text);
                cmd.Parameters.AddWithValue("@Email", txtPatientEmail.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Patient Added Successfully");
                LoadPatients();
            }
        }

        private void txtSearchPatient_TextChanged(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=DESKTOP-M3NBITM;Initial Catalog=DoctorManagementDB;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "SELECT * FROM Patients WHERE Name LIKE @Search";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                da.SelectCommand.Parameters.AddWithValue("@Search", "%" + txtSearchPatients.Text + "%");
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvPatients.DataSource = dt;
            }
        }

        private void txtAppointmentDoctorId_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvAppointments_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvAppointments.Rows[e.RowIndex];
                txtPatientId.Text = row.Cells["PatientId"].Value.ToString();
                txtDoctorId.Text = row.Cells["DoctorId"].Value.ToString();
                txtAppointmentDate.Text = row.Cells["AppointmentDate"].Value.ToString();
                txtTimeSlot.Text = row.Cells["TimeSlot"].Value.ToString();
                txtStatus.Text = row.Cells["Status"].Value.ToString();
                selectedAppointmentId = Convert.ToInt32(row.Cells["AppointmentId"].Value);
            }
        }

        private void btnAddAppointment_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=DESKTOP-M3NBITM;Initial Catalog=DoctorManagementDB;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                // CHECK IF SLOT ALREADY BOOKED
                string checkQuery = @"SELECT COUNT(*)
                             FROM Appointments
                             WHERE DoctorId = @DoctorId
                             AND AppointmentDate = @AppointmentDate
                             AND TimeSlot = @TimeSlot";
                SqlCommand checkCmd = new SqlCommand(checkQuery, con);
                checkCmd.Parameters.AddWithValue("@DoctorId", txtDoctorId.Text);
                checkCmd.Parameters.AddWithValue("@AppointmentDate",
                    Convert.ToDateTime(txtAppointmentDate.Text));
                checkCmd.Parameters.AddWithValue("@TimeSlot", txtTimeSlot.Text);
                int count = (int)checkCmd.ExecuteScalar();
                if (count > 0)
                {
                    MessageBox.Show("Doctor already booked for this slot!");
                    return;
                }
                // INSERT APPOINTMENT
                string query = @"INSERT INTO Appointments
                       (PatientId, DoctorId, AppointmentDate, TimeSlot, Status)
                       VALUES
                       (@PatientId, @DoctorId, @AppointmentDate, @TimeSlot, @Status)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@PatientId", txtPatientId.Text);
                cmd.Parameters.AddWithValue("@DoctorId", txtDoctorId.Text);
                cmd.Parameters.AddWithValue("@AppointmentDate",
                    Convert.ToDateTime(txtAppointmentDate.Text));
                cmd.Parameters.AddWithValue("@TimeSlot", txtTimeSlot.Text);
                cmd.Parameters.AddWithValue("@Status", txtStatus.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Appointment Added Successfully");
            }
            LoadAppointments();
        }

        private void btnUpdateAppointment_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=DESKTOP-M3NBITM;Initial Catalog=DoctorManagementDB;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = @"UPDATE Appointments
                    SET PatientId = @PatientId,
                        DoctorId = @DoctorId,
                        AppointmentDate = @AppointmentDate,
                        TimeSlot = @TimeSlot,
                        Status = @Status
                    WHERE AppointmentId = @AppointmentId";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@PatientId", txtPatientId.Text);
                cmd.Parameters.AddWithValue("@DoctorId", txtDoctorId.Text);
                cmd.Parameters.AddWithValue("@AppointmentDate", Convert.ToDateTime(txtAppointmentDate.Text));
                cmd.Parameters.AddWithValue("@TimeSlot", txtTimeSlot.Text);
                cmd.Parameters.AddWithValue("@Status", txtStatus.Text);
                cmd.Parameters.AddWithValue("@AppointmentId", selectedAppointmentId);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Appointment Updated Successfully");
            }
            LoadAppointments();
        }

        private void btnDeleteAppointment_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=DESKTOP-M3NBITM;Initial Catalog=DoctorManagementDB;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "DELETE FROM Appointments WHERE AppointmentId = @AppointmentId";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@AppointmentId", selectedAppointmentId);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Appointment Deleted Successfully");
            }
            LoadAppointments();
        }

        private void txtSearchAppointment_TextChanged(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=DESKTOP-M3NBITM;Initial Catalog=DoctorManagementDB;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = @"SELECT * FROM Appointments
                    WHERE PatientId LIKE @Search
                    OR DoctorId LIKE @Search
                    OR Status LIKE @Search";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                da.SelectCommand.Parameters.AddWithValue("@Search",
                    "%" + txtSearchAppointment.Text + "%");
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvAppointments.DataSource = dt;
            }
        }

        private void LoadDashboardCounts()
        {
            string connectionString = @"Data Source=DESKTOP-M3NBITM;Initial Catalog=DoctorManagementDB;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                // Total Doctors
                SqlCommand cmdDoctors = new SqlCommand("SELECT COUNT(*) FROM Doctors", con);
                lblTotalDoctors.Text = cmdDoctors.ExecuteScalar().ToString();
                // Total Patients
                SqlCommand cmdPatients = new SqlCommand("SELECT COUNT(*) FROM Patients", con);
                lblTotalPatients.Text = cmdPatients.ExecuteScalar().ToString();
                // Total Appointments
                SqlCommand cmdAppointments = new SqlCommand("SELECT COUNT(*) FROM Appointments", con);
                lblAppointments.Text = cmdAppointments.ExecuteScalar().ToString();
                // Available Slots
                SqlCommand cmdSlots = new SqlCommand("SELECT COUNT(*) FROM Slots WHERE Status='Available'", con);
                lblAvailableSlots.Text = "0";
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Form1 login = new Form1();
            login.Show();
            this.Hide();
        }

        private void btnLogout_Click_1(object sender, EventArgs e)
        {
            Form1 login = new Form1();
            login.Show();
            this.Hide();
        }

        private void dgvAppointments_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
