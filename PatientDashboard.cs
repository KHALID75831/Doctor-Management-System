using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace Login_System
{
    public partial class PatientDashboard : Form
    {
        string cs = @"Data Source=DESKTOP-M3NBITM;Initial Catalog=DoctorManagementDB;Integrated Security=True";
        bool isLoaded = false;
        Dictionary<string, int> slotDictionary = new Dictionary<string, int>();
        public PatientDashboard()
        {
            InitializeComponent();
            this.Load += PatientDashboard_Load;
            cmbDoctor.SelectedIndexChanged += cmbDoctor_SelectedIndexChanged;
        }
        private void PatientDashboard_Load(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT DoctorId, Name FROM Doctors",
                    con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cmbDoctor.DataSource = dt;
                cmbDoctor.DisplayMember = "Name";
                cmbDoctor.ValueMember = "DoctorId";
            }
            isLoaded = true;

            LoadSlotsByDoctor();
        }

        private void cmbDoctor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isLoaded)
                return;
            LoadSlotsByDoctor();
        }
        private void LoadSlotsByDoctor()
        {
            cmbNewSlot.Items.Clear();
            slotDictionary.Clear();
            if (cmbDoctor.SelectedValue == null)
                return;
            if (cmbDoctor.SelectedValue is DataRowView)
                return;
            int doctorId = Convert.ToInt32(cmbDoctor.SelectedValue);
            
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                string query = @"
       SELECT SlotId, SlotTime
       FROM Slots
       WHERE DoctorId = @doctorId";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@doctorId", doctorId);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string slotText = reader["SlotId"].ToString() + " - " + reader["SlotTime"].ToString();
                    int slotId = Convert.ToInt32(reader["SlotId"]);
                    cmbNewSlot.Items.Add(slotText);
                    slotDictionary[slotText] = slotId;
                }
            }
        }

        private void btnBook_Click(object sender, EventArgs e)
        {
            if (cmbDoctor.SelectedIndex == -1 || cmbNewSlot.SelectedIndex == -1)
            {
                MessageBox.Show("Please select doctor and slot");
                return;
            }
            string selectedSlotText = cmbNewSlot.SelectedItem.ToString();
            int slotId = slotDictionary[selectedSlotText];
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                string slotQuery = "SELECT SlotDate, SlotTime FROM Slots WHERE SlotId = @slotId";
                SqlCommand slotCmd = new SqlCommand(slotQuery, con);
                slotCmd.Parameters.AddWithValue("@slotId", slotId);
                SqlDataReader reader = slotCmd.ExecuteReader();
                DateTime slotDate = DateTime.Now;
                string slotTime = "";
                if (reader.Read())
                {
                    slotDate = Convert.ToDateTime(reader["SlotDate"]);
                    slotTime = reader["SlotTime"].ToString();
                }
                reader.Close();
                string insertQuery = @"
   INSERT INTO Appointments
   (PatientId, DoctorId, AppointmentDate, TimeSlot, Status)
   VALUES
   (@patientId, @doctorId, @appointmentDate, @timeSlot, 'Booked')";
                SqlCommand cmd = new SqlCommand(insertQuery, con);
                cmd.Parameters.AddWithValue("@patientId", 1);
                cmd.Parameters.AddWithValue("@doctorId", cmbDoctor.SelectedValue);
                cmd.Parameters.AddWithValue("@appointmentDate", slotDate);
                cmd.Parameters.AddWithValue("@timeSlot", slotTime);
                cmd.ExecuteNonQuery();
                string updateQuery = @"
   UPDATE Slots
   SET IsBooked = 1
   WHERE SlotId = @slotId";
                SqlCommand cmd2 = new SqlCommand(updateQuery, con);
                cmd2.Parameters.AddWithValue("@slotId", slotId);
                cmd2.ExecuteNonQuery();
            }
            MessageBox.Show("Appointment Booked!");
            LoadSlotsByDoctor();
        }
        private void btnMyAppointments_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                string query = @"
               SELECT
                   a.AppointmentId,
                   d.Name AS Doctor,
                   a.AppointmentDate,
                   a.TimeSlot,
                   a.Status
               FROM Appointments a
               JOIN Doctors d
               ON a.DoctorId = d.DoctorId";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvPatient.DataSource = dt;
            }
        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 login = new Form1();
            login.Show();
        }

        //private void cmbSlot_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //}
    }
}