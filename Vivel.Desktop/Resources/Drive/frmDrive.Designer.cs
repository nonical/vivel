namespace Vivel.Desktop.Resources.Drive
{
    partial class frmDrive
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
            this.components = new System.ComponentModel.Container();
            this.btnSearchDrive = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvDrive = new System.Windows.Forms.DataGridView();
            this.driveDTOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cmbHospitalSelect = new System.Windows.Forms.ComboBox();
            this.cbDriveOpen = new System.Windows.Forms.CheckBox();
            this.cbDriveClosed = new System.Windows.Forms.CheckBox();
            this.lblDrivePrevious = new System.Windows.Forms.LinkLabel();
            this.lblDriveNext = new System.Windows.Forms.LinkLabel();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bloodTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.urgencyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createdAtDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.updatedAtDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDrive)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.driveDTOBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSearchDrive
            // 
            this.btnSearchDrive.Enabled = false;
            this.btnSearchDrive.Location = new System.Drawing.Point(225, 66);
            this.btnSearchDrive.Name = "btnSearchDrive";
            this.btnSearchDrive.Size = new System.Drawing.Size(97, 23);
            this.btnSearchDrive.TabIndex = 8;
            this.btnSearchDrive.Text = "Search";
            this.btnSearchDrive.UseVisualStyleBackColor = true;
            this.btnSearchDrive.Click += new System.EventHandler(this.btnSearchDrive_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(75, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Hospital";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvDrive);
            this.groupBox1.Location = new System.Drawing.Point(75, 142);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(749, 349);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Drives";
            // 
            // dgvDrive
            // 
            this.dgvDrive.AllowUserToAddRows = false;
            this.dgvDrive.AllowUserToDeleteRows = false;
            this.dgvDrive.AutoGenerateColumns = false;
            this.dgvDrive.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDrive.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dateDataGridViewTextBoxColumn,
            this.bloodTypeDataGridViewTextBoxColumn,
            this.amountDataGridViewTextBoxColumn,
            this.statusDataGridViewTextBoxColumn,
            this.urgencyDataGridViewTextBoxColumn,
            this.createdAtDataGridViewTextBoxColumn,
            this.updatedAtDataGridViewTextBoxColumn});
            this.dgvDrive.DataSource = this.driveDTOBindingSource;
            this.dgvDrive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDrive.Location = new System.Drawing.Point(3, 16);
            this.dgvDrive.Name = "dgvDrive";
            this.dgvDrive.ReadOnly = true;
            this.dgvDrive.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDrive.Size = new System.Drawing.Size(743, 330);
            this.dgvDrive.TabIndex = 0;
            // 
            // driveDTOBindingSource
            // 
            this.driveDTOBindingSource.DataSource = typeof(Vivel.Model.Dto.DriveDTO);
            // 
            // cmbHospitalSelect
            // 
            this.cmbHospitalSelect.FormattingEnabled = true;
            this.cmbHospitalSelect.Location = new System.Drawing.Point(78, 66);
            this.cmbHospitalSelect.Name = "cmbHospitalSelect";
            this.cmbHospitalSelect.Size = new System.Drawing.Size(121, 21);
            this.cmbHospitalSelect.TabIndex = 9;
            // 
            // cbDriveOpen
            // 
            this.cbDriveOpen.AutoSize = true;
            this.cbDriveOpen.Checked = true;
            this.cbDriveOpen.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbDriveOpen.Location = new System.Drawing.Point(78, 99);
            this.cbDriveOpen.Name = "cbDriveOpen";
            this.cbDriveOpen.Size = new System.Drawing.Size(52, 17);
            this.cbDriveOpen.TabIndex = 12;
            this.cbDriveOpen.Text = "Open";
            this.cbDriveOpen.UseVisualStyleBackColor = true;
            // 
            // cbDriveClosed
            // 
            this.cbDriveClosed.AutoSize = true;
            this.cbDriveClosed.Checked = true;
            this.cbDriveClosed.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbDriveClosed.Location = new System.Drawing.Point(136, 99);
            this.cbDriveClosed.Name = "cbDriveClosed";
            this.cbDriveClosed.Size = new System.Drawing.Size(58, 17);
            this.cbDriveClosed.TabIndex = 13;
            this.cbDriveClosed.Text = "Closed";
            this.cbDriveClosed.UseVisualStyleBackColor = true;
            // 
            // lblDrivePrevious
            // 
            this.lblDrivePrevious.AutoSize = true;
            this.lblDrivePrevious.Enabled = false;
            this.lblDrivePrevious.Location = new System.Drawing.Point(717, 126);
            this.lblDrivePrevious.Name = "lblDrivePrevious";
            this.lblDrivePrevious.Size = new System.Drawing.Size(47, 13);
            this.lblDrivePrevious.TabIndex = 15;
            this.lblDrivePrevious.TabStop = true;
            this.lblDrivePrevious.Text = "previous";
            this.lblDrivePrevious.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblDrivePrevious_LinkClicked);
            // 
            // lblDriveNext
            // 
            this.lblDriveNext.AutoSize = true;
            this.lblDriveNext.Enabled = false;
            this.lblDriveNext.Location = new System.Drawing.Point(797, 126);
            this.lblDriveNext.Name = "lblDriveNext";
            this.lblDriveNext.Size = new System.Drawing.Size(27, 13);
            this.lblDriveNext.TabIndex = 14;
            this.lblDriveNext.TabStop = true;
            this.lblDriveNext.Text = "next";
            this.lblDriveNext.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblDriveNext_LinkClicked);
            // 
            // textBox2
            // 
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(403, 43);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(191, 16);
            this.textBox2.TabIndex = 25;
            this.textBox2.Text = "View selected hospital\'s drives";
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(457, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(68, 25);
            this.textBox1.TabIndex = 24;
            this.textBox1.Text = "Drives";
            // 
            // dateDataGridViewTextBoxColumn
            // 
            this.dateDataGridViewTextBoxColumn.DataPropertyName = "Date";
            this.dateDataGridViewTextBoxColumn.HeaderText = "Date";
            this.dateDataGridViewTextBoxColumn.Name = "dateDataGridViewTextBoxColumn";
            this.dateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bloodTypeDataGridViewTextBoxColumn
            // 
            this.bloodTypeDataGridViewTextBoxColumn.DataPropertyName = "BloodType";
            this.bloodTypeDataGridViewTextBoxColumn.HeaderText = "Blood Type";
            this.bloodTypeDataGridViewTextBoxColumn.Name = "bloodTypeDataGridViewTextBoxColumn";
            this.bloodTypeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // amountDataGridViewTextBoxColumn
            // 
            this.amountDataGridViewTextBoxColumn.DataPropertyName = "Amount";
            this.amountDataGridViewTextBoxColumn.HeaderText = "Amount";
            this.amountDataGridViewTextBoxColumn.Name = "amountDataGridViewTextBoxColumn";
            this.amountDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // statusDataGridViewTextBoxColumn
            // 
            this.statusDataGridViewTextBoxColumn.DataPropertyName = "Status";
            this.statusDataGridViewTextBoxColumn.HeaderText = "Status";
            this.statusDataGridViewTextBoxColumn.Name = "statusDataGridViewTextBoxColumn";
            this.statusDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // urgencyDataGridViewTextBoxColumn
            // 
            this.urgencyDataGridViewTextBoxColumn.DataPropertyName = "Urgency";
            this.urgencyDataGridViewTextBoxColumn.HeaderText = "Urgency";
            this.urgencyDataGridViewTextBoxColumn.Name = "urgencyDataGridViewTextBoxColumn";
            this.urgencyDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // createdAtDataGridViewTextBoxColumn
            // 
            this.createdAtDataGridViewTextBoxColumn.DataPropertyName = "CreatedAt";
            this.createdAtDataGridViewTextBoxColumn.HeaderText = "Created At";
            this.createdAtDataGridViewTextBoxColumn.Name = "createdAtDataGridViewTextBoxColumn";
            this.createdAtDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // updatedAtDataGridViewTextBoxColumn
            // 
            this.updatedAtDataGridViewTextBoxColumn.DataPropertyName = "UpdatedAt";
            this.updatedAtDataGridViewTextBoxColumn.HeaderText = "Updated At";
            this.updatedAtDataGridViewTextBoxColumn.Name = "updatedAtDataGridViewTextBoxColumn";
            this.updatedAtDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // frmDrive
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lblDrivePrevious);
            this.Controls.Add(this.lblDriveNext);
            this.Controls.Add(this.cbDriveClosed);
            this.Controls.Add(this.cbDriveOpen);
            this.Controls.Add(this.cmbHospitalSelect);
            this.Controls.Add(this.btnSearchDrive);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmDrive";
            this.Text = "frmDrive";
            this.Load += new System.EventHandler(this.frmDrive_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDrive)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.driveDTOBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSearchDrive;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvDrive;
        private System.Windows.Forms.ComboBox cmbHospitalSelect;
        private System.Windows.Forms.CheckBox cbDriveOpen;
        private System.Windows.Forms.CheckBox cbDriveClosed;
        private System.Windows.Forms.LinkLabel lblDrivePrevious;
        private System.Windows.Forms.LinkLabel lblDriveNext;
        private System.Windows.Forms.BindingSource driveDTOBindingSource;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bloodTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn amountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn urgencyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn createdAtDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn updatedAtDataGridViewTextBoxColumn;
    }
}
