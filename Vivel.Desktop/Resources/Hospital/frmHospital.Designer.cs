namespace Vivel.Desktop.Hospital
{
    partial class frmHospital
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvHospital = new System.Windows.Forms.DataGridView();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.latitudeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.longitudeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createdAtDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.updatedAtDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hospitalDTOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblHospitalClear = new System.Windows.Forms.LinkLabel();
            this.txtHospitalIdUpsert = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnHospitalSave = new System.Windows.Forms.Button();
            this.txtHospitalLongitudeUpsert = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtHospitalLatitudeUpsert = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtHospitalNameUpsert = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtHospitalNameSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSearchHospital = new System.Windows.Forms.Button();
            this.lblHospitalNext = new System.Windows.Forms.LinkLabel();
            this.lblHospitalPrevious = new System.Windows.Forms.LinkLabel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHospital)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hospitalDTOBindingSource)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvHospital);
            this.groupBox1.Location = new System.Drawing.Point(-1, 99);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(547, 349);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Hospitals";
            // 
            // dgvHospital
            // 
            this.dgvHospital.AllowUserToAddRows = false;
            this.dgvHospital.AllowUserToDeleteRows = false;
            this.dgvHospital.AutoGenerateColumns = false;
            this.dgvHospital.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHospital.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn,
            this.latitudeDataGridViewTextBoxColumn,
            this.longitudeDataGridViewTextBoxColumn,
            this.createdAtDataGridViewTextBoxColumn,
            this.updatedAtDataGridViewTextBoxColumn});
            this.dgvHospital.DataSource = this.hospitalDTOBindingSource;
            this.dgvHospital.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHospital.Location = new System.Drawing.Point(3, 16);
            this.dgvHospital.Name = "dgvHospital";
            this.dgvHospital.ReadOnly = true;
            this.dgvHospital.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHospital.Size = new System.Drawing.Size(541, 330);
            this.dgvHospital.TabIndex = 0;
            this.dgvHospital.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHospital_CellContentClick);
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // latitudeDataGridViewTextBoxColumn
            // 
            this.latitudeDataGridViewTextBoxColumn.DataPropertyName = "Latitude";
            this.latitudeDataGridViewTextBoxColumn.HeaderText = "Latitude";
            this.latitudeDataGridViewTextBoxColumn.Name = "latitudeDataGridViewTextBoxColumn";
            this.latitudeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // longitudeDataGridViewTextBoxColumn
            // 
            this.longitudeDataGridViewTextBoxColumn.DataPropertyName = "Longitude";
            this.longitudeDataGridViewTextBoxColumn.HeaderText = "Longitude";
            this.longitudeDataGridViewTextBoxColumn.Name = "longitudeDataGridViewTextBoxColumn";
            this.longitudeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // createdAtDataGridViewTextBoxColumn
            // 
            this.createdAtDataGridViewTextBoxColumn.DataPropertyName = "CreatedAt";
            this.createdAtDataGridViewTextBoxColumn.HeaderText = "CreatedAt";
            this.createdAtDataGridViewTextBoxColumn.Name = "createdAtDataGridViewTextBoxColumn";
            this.createdAtDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // updatedAtDataGridViewTextBoxColumn
            // 
            this.updatedAtDataGridViewTextBoxColumn.DataPropertyName = "UpdatedAt";
            this.updatedAtDataGridViewTextBoxColumn.HeaderText = "UpdatedAt";
            this.updatedAtDataGridViewTextBoxColumn.Name = "updatedAtDataGridViewTextBoxColumn";
            this.updatedAtDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // hospitalDTOBindingSource
            // 
            this.hospitalDTOBindingSource.DataSource = typeof(Vivel.Model.Dto.HospitalDTO);
            // 
            // groupBox2
            // 
            this.groupBox2.AutoSize = true;
            this.groupBox2.Controls.Add(this.lblHospitalClear);
            this.groupBox2.Controls.Add(this.txtHospitalIdUpsert);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.btnHospitalSave);
            this.groupBox2.Controls.Add(this.txtHospitalLongitudeUpsert);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtHospitalLatitudeUpsert);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtHospitalNameUpsert);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(552, 99);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(249, 349);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Create/Update";
            // 
            // lblHospitalClear
            // 
            this.lblHospitalClear.AutoSize = true;
            this.lblHospitalClear.Location = new System.Drawing.Point(23, 239);
            this.lblHospitalClear.Name = "lblHospitalClear";
            this.lblHospitalClear.Size = new System.Drawing.Size(30, 13);
            this.lblHospitalClear.TabIndex = 9;
            this.lblHospitalClear.TabStop = true;
            this.lblHospitalClear.Text = "clear";
            this.lblHospitalClear.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblHospitalClear_LinkClicked);
            // 
            // txtHospitalIdUpsert
            // 
            this.txtHospitalIdUpsert.Enabled = false;
            this.txtHospitalIdUpsert.Location = new System.Drawing.Point(21, 41);
            this.txtHospitalIdUpsert.Name = "txtHospitalIdUpsert";
            this.txtHospitalIdUpsert.Size = new System.Drawing.Size(197, 20);
            this.txtHospitalIdUpsert.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(18, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "ID";
            // 
            // btnHospitalSave
            // 
            this.btnHospitalSave.Location = new System.Drawing.Point(59, 234);
            this.btnHospitalSave.Name = "btnHospitalSave";
            this.btnHospitalSave.Size = new System.Drawing.Size(159, 23);
            this.btnHospitalSave.TabIndex = 6;
            this.btnHospitalSave.Text = "Save";
            this.btnHospitalSave.UseVisualStyleBackColor = true;
            this.btnHospitalSave.Click += new System.EventHandler(this.btnHospitalSave_Click);
            // 
            // txtHospitalLongitudeUpsert
            // 
            this.txtHospitalLongitudeUpsert.Location = new System.Drawing.Point(21, 190);
            this.txtHospitalLongitudeUpsert.Name = "txtHospitalLongitudeUpsert";
            this.txtHospitalLongitudeUpsert.Size = new System.Drawing.Size(197, 20);
            this.txtHospitalLongitudeUpsert.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 174);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Longitude";
            // 
            // txtHospitalLatitudeUpsert
            // 
            this.txtHospitalLatitudeUpsert.Location = new System.Drawing.Point(21, 140);
            this.txtHospitalLatitudeUpsert.Name = "txtHospitalLatitudeUpsert";
            this.txtHospitalLatitudeUpsert.Size = new System.Drawing.Size(197, 20);
            this.txtHospitalLatitudeUpsert.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Latitude";
            // 
            // txtHospitalNameUpsert
            // 
            this.txtHospitalNameUpsert.Location = new System.Drawing.Point(21, 90);
            this.txtHospitalNameUpsert.Name = "txtHospitalNameUpsert";
            this.txtHospitalNameUpsert.Size = new System.Drawing.Size(197, 20);
            this.txtHospitalNameUpsert.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Name";
            // 
            // txtHospitalNameSearch
            // 
            this.txtHospitalNameSearch.Location = new System.Drawing.Point(16, 45);
            this.txtHospitalNameSearch.Name = "txtHospitalNameSearch";
            this.txtHospitalNameSearch.Size = new System.Drawing.Size(141, 20);
            this.txtHospitalNameSearch.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Name";
            // 
            // btnSearchHospital
            // 
            this.btnSearchHospital.Location = new System.Drawing.Point(163, 43);
            this.btnSearchHospital.Name = "btnSearchHospital";
            this.btnSearchHospital.Size = new System.Drawing.Size(97, 23);
            this.btnSearchHospital.TabIndex = 4;
            this.btnSearchHospital.Text = "Search";
            this.btnSearchHospital.UseVisualStyleBackColor = true;
            this.btnSearchHospital.Click += new System.EventHandler(this.btnSearchHospital_Click);
            // 
            // lblHospitalNext
            // 
            this.lblHospitalNext.AutoSize = true;
            this.lblHospitalNext.Enabled = false;
            this.lblHospitalNext.Location = new System.Drawing.Point(492, 83);
            this.lblHospitalNext.Name = "lblHospitalNext";
            this.lblHospitalNext.Size = new System.Drawing.Size(27, 13);
            this.lblHospitalNext.TabIndex = 5;
            this.lblHospitalNext.TabStop = true;
            this.lblHospitalNext.Text = "next";
            this.lblHospitalNext.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblHospitalNext_LinkClicked);
            // 
            // lblHospitalPrevious
            // 
            this.lblHospitalPrevious.AutoSize = true;
            this.lblHospitalPrevious.Enabled = false;
            this.lblHospitalPrevious.Location = new System.Drawing.Point(412, 83);
            this.lblHospitalPrevious.Name = "lblHospitalPrevious";
            this.lblHospitalPrevious.Size = new System.Drawing.Size(47, 13);
            this.lblHospitalPrevious.TabIndex = 6;
            this.lblHospitalPrevious.TabStop = true;
            this.lblHospitalPrevious.Text = "previous";
            this.lblHospitalPrevious.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblHospitalPrevious_LinkClicked);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmHospital
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblHospitalPrevious);
            this.Controls.Add(this.lblHospitalNext);
            this.Controls.Add(this.btnSearchHospital);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtHospitalNameSearch);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmHospital";
            this.Text = "frmHospital";
            this.Load += new System.EventHandler(this.frmHospital_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHospital)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hospitalDTOBindingSource)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvHospital;
        private System.Windows.Forms.TextBox txtHospitalNameSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearchHospital;
        private System.Windows.Forms.TextBox txtHospitalNameUpsert;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnHospitalSave;
        private System.Windows.Forms.TextBox txtHospitalLongitudeUpsert;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtHospitalLatitudeUpsert;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtHospitalIdUpsert;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.LinkLabel lblHospitalClear;
        private System.Windows.Forms.LinkLabel lblHospitalNext;
        private System.Windows.Forms.LinkLabel lblHospitalPrevious;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn latitudeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn longitudeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn createdAtDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn updatedAtDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource hospitalDTOBindingSource;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
