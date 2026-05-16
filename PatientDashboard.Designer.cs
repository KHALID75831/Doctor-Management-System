namespace Login_System
{
    partial class PatientDashboard
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cmbDoctor = new System.Windows.Forms.ComboBox();
            this.btnBook = new System.Windows.Forms.Button();
            this.btnMyAppointments = new System.Windows.Forms.Button();
            this.dgvPatient = new System.Windows.Forms.DataGridView();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.lblSlot = new System.Windows.Forms.Label();
            this.lblDoctor = new System.Windows.Forms.Label();
            this.cmbNewSlot = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPatient)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbDoctor
            // 
            this.cmbDoctor.BackColor = System.Drawing.Color.Goldenrod;
            this.cmbDoctor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDoctor.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cmbDoctor.ForeColor = System.Drawing.SystemColors.InfoText;
            this.cmbDoctor.FormattingEnabled = true;
            this.cmbDoctor.Location = new System.Drawing.Point(120, 131);
            this.cmbDoctor.Name = "cmbDoctor";
            this.cmbDoctor.Size = new System.Drawing.Size(180, 29);
            this.cmbDoctor.TabIndex = 0;
            // 
            // btnBook
            // 
            this.btnBook.BackColor = System.Drawing.Color.LightBlue;
            this.btnBook.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnBook.Location = new System.Drawing.Point(219, 293);
            this.btnBook.Name = "btnBook";
            this.btnBook.Size = new System.Drawing.Size(171, 32);
            this.btnBook.TabIndex = 2;
            this.btnBook.Text = "Book Appointment";
            this.btnBook.UseVisualStyleBackColor = false;
            this.btnBook.Click += new System.EventHandler(this.btnBook_Click);
            // 
            // btnMyAppointments
            // 
            this.btnMyAppointments.BackColor = System.Drawing.Color.LightBlue;
            this.btnMyAppointments.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnMyAppointments.Location = new System.Drawing.Point(219, 344);
            this.btnMyAppointments.Name = "btnMyAppointments";
            this.btnMyAppointments.Size = new System.Drawing.Size(171, 36);
            this.btnMyAppointments.TabIndex = 3;
            this.btnMyAppointments.Text = "My Appointments";
            this.btnMyAppointments.UseVisualStyleBackColor = false;
            this.btnMyAppointments.Click += new System.EventHandler(this.btnMyAppointments_Click);
            // 
            // dgvPatient
            // 
            this.dgvPatient.AllowUserToAddRows = false;
            this.dgvPatient.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPatient.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPatient.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPatient.Location = new System.Drawing.Point(580, 132);
            this.dgvPatient.Name = "dgvPatient";
            this.dgvPatient.ReadOnly = true;
            this.dgvPatient.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPatient.RowHeadersVisible = false;
            this.dgvPatient.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPatient.Size = new System.Drawing.Size(641, 263);
            this.dgvPatient.TabIndex = 4;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(634, 21);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(228, 29);
            this.lblTitle.TabIndex = 5;
            this.lblTitle.Text = "Patient Dashboard";
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.Crimson;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(219, 426);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(100, 30);
            this.btnLogout.TabIndex = 7;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // lblSlot
            // 
            this.lblSlot.AutoSize = true;
            this.lblSlot.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblSlot.Location = new System.Drawing.Point(334, 100);
            this.lblSlot.Name = "lblSlot";
            this.lblSlot.Size = new System.Drawing.Size(90, 21);
            this.lblSlot.TabIndex = 8;
            this.lblSlot.Text = "Select Slot";
            // 
            // lblDoctor
            // 
            this.lblDoctor.AutoSize = true;
            this.lblDoctor.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblDoctor.Location = new System.Drawing.Point(120, 100);
            this.lblDoctor.Name = "lblDoctor";
            this.lblDoctor.Size = new System.Drawing.Size(112, 21);
            this.lblDoctor.TabIndex = 9;
            this.lblDoctor.Text = "Select Doctor";
            // 
            // cmbNewSlot
            // 
            this.cmbNewSlot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNewSlot.FormattingEnabled = true;
            this.cmbNewSlot.Location = new System.Drawing.Point(338, 138);
            this.cmbNewSlot.Name = "cmbNewSlot";
            this.cmbNewSlot.Size = new System.Drawing.Size(121, 21);
            this.cmbNewSlot.TabIndex = 10;
            // 
            // PatientDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(1567, 557);
            this.Controls.Add(this.cmbNewSlot);
            this.Controls.Add(this.lblDoctor);
            this.Controls.Add(this.lblSlot);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.dgvPatient);
            this.Controls.Add(this.btnMyAppointments);
            this.Controls.Add(this.btnBook);
            this.Controls.Add(this.cmbDoctor);
            this.Name = "PatientDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Patient Dashboard";
            this.Load += new System.EventHandler(this.PatientDashboard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPatient)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private System.Windows.Forms.ComboBox cmbDoctor;
        private System.Windows.Forms.Button btnBook;
        private System.Windows.Forms.Button btnMyAppointments;
        private System.Windows.Forms.DataGridView dgvPatient;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label lblSlot;
        private System.Windows.Forms.Label lblDoctor;
        private System.Windows.Forms.ComboBox cmbNewSlot;
    }
}