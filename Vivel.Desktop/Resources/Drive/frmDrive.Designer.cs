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
            this.btnSearchDrive = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvDrive = new System.Windows.Forms.DataGridView();
            this.cmbHospitalSelect = new System.Windows.Forms.ComboBox();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnClosed = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDrive)).BeginInit();
            this.SuspendLayout();
            //
            // btnSearchDrive
            //
            this.btnSearchDrive.Location = new System.Drawing.Point(164, 44);
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
            this.label1.Location = new System.Drawing.Point(14, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Hospital";
            //
            // groupBox1
            //
            this.groupBox1.Controls.Add(this.dgvDrive);
            this.groupBox1.Location = new System.Drawing.Point(0, 100);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(799, 349);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Drives";
            //
            // dgvDrive
            //
            this.dgvDrive.AllowUserToAddRows = false;
            this.dgvDrive.AllowUserToDeleteRows = false;
            this.dgvDrive.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDrive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDrive.Location = new System.Drawing.Point(3, 16);
            this.dgvDrive.Name = "dgvDrive";
            this.dgvDrive.ReadOnly = true;
            this.dgvDrive.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDrive.Size = new System.Drawing.Size(793, 330);
            this.dgvDrive.TabIndex = 0;
            //
            // cmbHospitalSelect
            //
            this.cmbHospitalSelect.FormattingEnabled = true;
            this.cmbHospitalSelect.Location = new System.Drawing.Point(17, 44);
            this.cmbHospitalSelect.Name = "cmbHospitalSelect";
            this.cmbHospitalSelect.Size = new System.Drawing.Size(121, 21);
            this.cmbHospitalSelect.TabIndex = 9;
            //
            // btnOpen
            //
            this.btnOpen.Location = new System.Drawing.Point(571, 44);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(97, 23);
            this.btnOpen.TabIndex = 10;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            //
            // btnClosed
            //
            this.btnClosed.Location = new System.Drawing.Point(691, 44);
            this.btnClosed.Name = "btnClosed";
            this.btnClosed.Size = new System.Drawing.Size(97, 23);
            this.btnClosed.TabIndex = 11;
            this.btnClosed.Text = "Closed";
            this.btnClosed.UseVisualStyleBackColor = true;
            this.btnClosed.Click += new System.EventHandler(this.btnClosed_Click);
            //
            // frmDrive
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 450);
            this.Controls.Add(this.btnClosed);
            this.Controls.Add(this.btnOpen);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSearchDrive;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvDrive;
        private System.Windows.Forms.ComboBox cmbHospitalSelect;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnClosed;
    }
}
