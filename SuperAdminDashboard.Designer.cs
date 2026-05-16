namespace Login_System
{
    partial class SuperAdminDashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.btnViewUsers = new System.Windows.Forms.Button();
            this.btnViewDoctors = new System.Windows.Forms.Button();
            this.btnViewPatients = new System.Windows.Forms.Button();
            this.btnViewAppointments = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.dgvSuperAdmin = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSuperAdmin)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(615, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(288, 34);
            this.label1.TabIndex = 0;
            this.label1.Text = "Super Admin Dashboard";
            this.label1.UseCompatibleTextRendering = true;
            // 
            // btnViewUsers
            // 
            this.btnViewUsers.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnViewUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewUsers.ForeColor = System.Drawing.Color.White;
            this.btnViewUsers.Location = new System.Drawing.Point(242, 106);
            this.btnViewUsers.Name = "btnViewUsers";
            this.btnViewUsers.Size = new System.Drawing.Size(115, 37);
            this.btnViewUsers.TabIndex = 1;
            this.btnViewUsers.Text = "View Users";
            this.btnViewUsers.UseVisualStyleBackColor = false;
            this.btnViewUsers.Click += new System.EventHandler(this.btnViewUsers_Click);
            // 
            // btnViewDoctors
            // 
            this.btnViewDoctors.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnViewDoctors.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewDoctors.ForeColor = System.Drawing.Color.White;
            this.btnViewDoctors.Location = new System.Drawing.Point(242, 160);
            this.btnViewDoctors.Name = "btnViewDoctors";
            this.btnViewDoctors.Size = new System.Drawing.Size(135, 36);
            this.btnViewDoctors.TabIndex = 2;
            this.btnViewDoctors.Text = "View Doctors";
            this.btnViewDoctors.UseVisualStyleBackColor = false;
            this.btnViewDoctors.Click += new System.EventHandler(this.btnViewDoctors_Click);
            // 
            // btnViewPatients
            // 
            this.btnViewPatients.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnViewPatients.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewPatients.ForeColor = System.Drawing.Color.White;
            this.btnViewPatients.Location = new System.Drawing.Point(242, 213);
            this.btnViewPatients.Name = "btnViewPatients";
            this.btnViewPatients.Size = new System.Drawing.Size(149, 37);
            this.btnViewPatients.TabIndex = 3;
            this.btnViewPatients.Text = "View Patients";
            this.btnViewPatients.UseVisualStyleBackColor = false;
            this.btnViewPatients.Click += new System.EventHandler(this.btnViewPatients_Click);
            // 
            // btnViewAppointments
            // 
            this.btnViewAppointments.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnViewAppointments.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewAppointments.ForeColor = System.Drawing.Color.White;
            this.btnViewAppointments.Location = new System.Drawing.Point(242, 265);
            this.btnViewAppointments.Name = "btnViewAppointments";
            this.btnViewAppointments.Size = new System.Drawing.Size(194, 37);
            this.btnViewAppointments.TabIndex = 4;
            this.btnViewAppointments.Text = "View Appointments";
            this.btnViewAppointments.UseVisualStyleBackColor = false;
            this.btnViewAppointments.Click += new System.EventHandler(this.btnViewAppointments_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.Crimson;
            this.btnLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(242, 425);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(92, 37);
            this.btnLogout.TabIndex = 5;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // dgvSuperAdmin
            // 
            this.dgvSuperAdmin.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSuperAdmin.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSuperAdmin.Location = new System.Drawing.Point(615, 88);
            this.dgvSuperAdmin.Name = "dgvSuperAdmin";
            this.dgvSuperAdmin.ReadOnly = true;
            this.dgvSuperAdmin.Size = new System.Drawing.Size(727, 374);
            this.dgvSuperAdmin.TabIndex = 6;
            this.dgvSuperAdmin.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSuperAdmin_CellContentClick);
            // 
            // SuperAdminDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(1535, 557);
            this.Controls.Add(this.dgvSuperAdmin);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnViewAppointments);
            this.Controls.Add(this.btnViewPatients);
            this.Controls.Add(this.btnViewDoctors);
            this.Controls.Add(this.btnViewUsers);
            this.Controls.Add(this.label1);
            this.Name = "SuperAdminDashboard";
            this.Text = "SuperAdminDashboard";
            ((System.ComponentModel.ISupportInitialize)(this.dgvSuperAdmin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnViewUsers;
        private System.Windows.Forms.Button btnViewDoctors;
        private System.Windows.Forms.Button btnViewPatients;
        private System.Windows.Forms.Button btnViewAppointments;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.DataGridView dgvSuperAdmin;
    }
}