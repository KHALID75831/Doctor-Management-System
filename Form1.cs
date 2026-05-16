using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Login_System
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;

            // SQL Server connection
            string connectionString = "Server=localhost;Database=DoctorManagementDB;Integrated Security=True;";

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    string query = "SELECT Role FROM Users WHERE Username=@username AND Password=@password";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);

                        object result = cmd.ExecuteScalar();

                        if (result != null)
                        {
                            string role = result.ToString();

                            if (role == "Admin")
                            {
                                MessageBox.Show("Welcome Admin");

                                AdminDashboard adminForm = new AdminDashboard();
                                adminForm.Show();
                                this.Hide();
                            }
                            else if (role == "Patient")
                            {
                                MessageBox.Show("Welcome Patient");

                                PatientDashboard patientForm = new PatientDashboard();
                                patientForm.Show();
                                this.Hide();
                            }
                            else if (role == "SuperAdmin")
                            {
                                MessageBox.Show("Welcome Super Admin");
                                SuperAdminDashboard s = new SuperAdminDashboard();
                                s.Show();
                                this.Hide();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}