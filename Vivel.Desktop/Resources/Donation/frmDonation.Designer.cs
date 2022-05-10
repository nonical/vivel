namespace Vivel.Desktop.Resources.User
{
    partial class frmDonation
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.userNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bloodTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.verifiedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userDTOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dgvUserDonations = new System.Windows.Forms.DataGridView();
            this.donationDTOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lbSearch = new System.Windows.Forms.Label();
            this.lbUsers = new System.Windows.Forms.Label();
            this.lbUserDonations = new System.Windows.Forms.Label();
            this.lblUserPrevious = new System.Windows.Forms.LinkLabel();
            this.lblUserNext = new System.Windows.Forms.LinkLabel();
            this.lblDonationPrevious = new System.Windows.Forms.LinkLabel();
            this.lblDonationNext = new System.Windows.Forms.LinkLabel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.updatedAtDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createdAtDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.plateletCountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.erythrocyteCountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.leukocyteCountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.noteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.scheduledAtDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userDTOBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserDonations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.donationDTOBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(14, 53);
            this.txtSearch.Multiline = true;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(143, 23);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.WordWrap = false;
            this.txtSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyUp);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(163, 53);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dgvUsers
            // 
            this.dgvUsers.AllowUserToAddRows = false;
            this.dgvUsers.AllowUserToDeleteRows = false;
            this.dgvUsers.AllowUserToResizeColumns = false;
            this.dgvUsers.AllowUserToResizeRows = false;
            this.dgvUsers.AutoGenerateColumns = false;
            this.dgvUsers.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUsers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.userNameDataGridViewTextBoxColumn,
            this.bloodTypeDataGridViewTextBoxColumn,
            this.verifiedDataGridViewTextBoxColumn});
            this.dgvUsers.DataSource = this.userDTOBindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Consolas", 8.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvUsers.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvUsers.Location = new System.Drawing.Point(13, 126);
            this.dgvUsers.MultiSelect = false;
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.ReadOnly = true;
            this.dgvUsers.RowHeadersVisible = false;
            this.dgvUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsers.Size = new System.Drawing.Size(203, 371);
            this.dgvUsers.TabIndex = 2;
            this.dgvUsers.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dgvUsers_RowStateChanged);
            // 
            // userNameDataGridViewTextBoxColumn
            // 
            this.userNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.userNameDataGridViewTextBoxColumn.DataPropertyName = "UserName";
            this.userNameDataGridViewTextBoxColumn.HeaderText = "UserName";
            this.userNameDataGridViewTextBoxColumn.Name = "userNameDataGridViewTextBoxColumn";
            this.userNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bloodTypeDataGridViewTextBoxColumn
            // 
            this.bloodTypeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.bloodTypeDataGridViewTextBoxColumn.DataPropertyName = "BloodType";
            this.bloodTypeDataGridViewTextBoxColumn.HeaderText = "BloodType";
            this.bloodTypeDataGridViewTextBoxColumn.Name = "bloodTypeDataGridViewTextBoxColumn";
            this.bloodTypeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // verifiedDataGridViewTextBoxColumn
            // 
            this.verifiedDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.verifiedDataGridViewTextBoxColumn.DataPropertyName = "Verified";
            this.verifiedDataGridViewTextBoxColumn.HeaderText = "Verified";
            this.verifiedDataGridViewTextBoxColumn.Name = "verifiedDataGridViewTextBoxColumn";
            this.verifiedDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // userDTOBindingSource
            // 
            this.userDTOBindingSource.DataSource = typeof(Vivel.Model.Dto.UserDTO);
            // 
            // dgvUserDonations
            // 
            this.dgvUserDonations.AllowUserToAddRows = false;
            this.dgvUserDonations.AllowUserToDeleteRows = false;
            this.dgvUserDonations.AllowUserToResizeColumns = false;
            this.dgvUserDonations.AllowUserToResizeRows = false;
            this.dgvUserDonations.AutoGenerateColumns = false;
            this.dgvUserDonations.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvUserDonations.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dgvUserDonations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUserDonations.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.scheduledAtDataGridViewTextBoxColumn,
            this.amountDataGridViewTextBoxColumn,
            this.statusDataGridViewTextBoxColumn,
            this.noteDataGridViewTextBoxColumn,
            this.leukocyteCountDataGridViewTextBoxColumn,
            this.erythrocyteCountDataGridViewTextBoxColumn,
            this.plateletCountDataGridViewTextBoxColumn,
            this.createdAtDataGridViewTextBoxColumn,
            this.updatedAtDataGridViewTextBoxColumn});
            this.dgvUserDonations.DataSource = this.donationDTOBindingSource;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Consolas", 8.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvUserDonations.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvUserDonations.Location = new System.Drawing.Point(235, 126);
            this.dgvUserDonations.Name = "dgvUserDonations";
            this.dgvUserDonations.ReadOnly = true;
            this.dgvUserDonations.RowHeadersVisible = false;
            this.dgvUserDonations.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvUserDonations.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUserDonations.Size = new System.Drawing.Size(753, 371);
            this.dgvUserDonations.TabIndex = 3;
            // 
            // donationDTOBindingSource
            // 
            this.donationDTOBindingSource.DataSource = typeof(Vivel.Model.Dto.DonationDTO);
            // 
            // lbSearch
            // 
            this.lbSearch.AutoSize = true;
            this.lbSearch.Location = new System.Drawing.Point(14, 37);
            this.lbSearch.Name = "lbSearch";
            this.lbSearch.Size = new System.Drawing.Size(112, 13);
            this.lbSearch.TabIndex = 4;
            this.lbSearch.Text = "Search users by name";
            // 
            // lbUsers
            // 
            this.lbUsers.AutoSize = true;
            this.lbUsers.Location = new System.Drawing.Point(14, 110);
            this.lbUsers.Name = "lbUsers";
            this.lbUsers.Size = new System.Drawing.Size(34, 13);
            this.lbUsers.TabIndex = 5;
            this.lbUsers.Text = "Users";
            // 
            // lbUserDonations
            // 
            this.lbUserDonations.AutoSize = true;
            this.lbUserDonations.Location = new System.Drawing.Point(232, 110);
            this.lbUserDonations.Name = "lbUserDonations";
            this.lbUserDonations.Size = new System.Drawing.Size(87, 13);
            this.lbUserDonations.TabIndex = 6;
            this.lbUserDonations.Text = "User\'s Donations";
            // 
            // lblUserPrevious
            // 
            this.lblUserPrevious.AutoSize = true;
            this.lblUserPrevious.Enabled = false;
            this.lblUserPrevious.Location = new System.Drawing.Point(109, 110);
            this.lblUserPrevious.Name = "lblUserPrevious";
            this.lblUserPrevious.Size = new System.Drawing.Size(47, 13);
            this.lblUserPrevious.TabIndex = 19;
            this.lblUserPrevious.TabStop = true;
            this.lblUserPrevious.Text = "previous";
            this.lblUserPrevious.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblUserPrevious_LinkClicked);
            // 
            // lblUserNext
            // 
            this.lblUserNext.AutoSize = true;
            this.lblUserNext.Enabled = false;
            this.lblUserNext.Location = new System.Drawing.Point(189, 110);
            this.lblUserNext.Name = "lblUserNext";
            this.lblUserNext.Size = new System.Drawing.Size(27, 13);
            this.lblUserNext.TabIndex = 18;
            this.lblUserNext.TabStop = true;
            this.lblUserNext.Text = "next";
            this.lblUserNext.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblUserNext_LinkClicked);
            // 
            // lblDonationPrevious
            // 
            this.lblDonationPrevious.AutoSize = true;
            this.lblDonationPrevious.Enabled = false;
            this.lblDonationPrevious.Location = new System.Drawing.Point(852, 110);
            this.lblDonationPrevious.Name = "lblDonationPrevious";
            this.lblDonationPrevious.Size = new System.Drawing.Size(47, 13);
            this.lblDonationPrevious.TabIndex = 21;
            this.lblDonationPrevious.TabStop = true;
            this.lblDonationPrevious.Text = "previous";
            this.lblDonationPrevious.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblDonationPrevious_LinkClicked);
            // 
            // lblDonationNext
            // 
            this.lblDonationNext.AutoSize = true;
            this.lblDonationNext.Enabled = false;
            this.lblDonationNext.Location = new System.Drawing.Point(932, 110);
            this.lblDonationNext.Name = "lblDonationNext";
            this.lblDonationNext.Size = new System.Drawing.Size(27, 13);
            this.lblDonationNext.TabIndex = 20;
            this.lblDonationNext.TabStop = true;
            this.lblDonationNext.Text = "next";
            this.lblDonationNext.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblDonationNext_LinkClicked);
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(452, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(101, 25);
            this.textBox1.TabIndex = 22;
            this.textBox1.Text = "Donations";
            // 
            // textBox2
            // 
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(413, 43);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(191, 16);
            this.textBox2.TabIndex = 23;
            this.textBox2.Text = "View selected user\'s donations";
            // 
            // updatedAtDataGridViewTextBoxColumn
            // 
            this.updatedAtDataGridViewTextBoxColumn.DataPropertyName = "UpdatedAt";
            this.updatedAtDataGridViewTextBoxColumn.HeaderText = "Updated At";
            this.updatedAtDataGridViewTextBoxColumn.Name = "updatedAtDataGridViewTextBoxColumn";
            this.updatedAtDataGridViewTextBoxColumn.ReadOnly = true;
            this.updatedAtDataGridViewTextBoxColumn.Width = 79;
            // 
            // createdAtDataGridViewTextBoxColumn
            // 
            this.createdAtDataGridViewTextBoxColumn.DataPropertyName = "CreatedAt";
            this.createdAtDataGridViewTextBoxColumn.HeaderText = "Created At";
            this.createdAtDataGridViewTextBoxColumn.Name = "createdAtDataGridViewTextBoxColumn";
            this.createdAtDataGridViewTextBoxColumn.ReadOnly = true;
            this.createdAtDataGridViewTextBoxColumn.Width = 76;
            // 
            // plateletCountDataGridViewTextBoxColumn
            // 
            this.plateletCountDataGridViewTextBoxColumn.DataPropertyName = "PlateletCount";
            this.plateletCountDataGridViewTextBoxColumn.HeaderText = "Platelet Count";
            this.plateletCountDataGridViewTextBoxColumn.Name = "plateletCountDataGridViewTextBoxColumn";
            this.plateletCountDataGridViewTextBoxColumn.ReadOnly = true;
            this.plateletCountDataGridViewTextBoxColumn.Width = 90;
            // 
            // erythrocyteCountDataGridViewTextBoxColumn
            // 
            this.erythrocyteCountDataGridViewTextBoxColumn.DataPropertyName = "ErythrocyteCount";
            this.erythrocyteCountDataGridViewTextBoxColumn.HeaderText = "Erythrocyte Count";
            this.erythrocyteCountDataGridViewTextBoxColumn.Name = "erythrocyteCountDataGridViewTextBoxColumn";
            this.erythrocyteCountDataGridViewTextBoxColumn.ReadOnly = true;
            this.erythrocyteCountDataGridViewTextBoxColumn.Width = 106;
            // 
            // leukocyteCountDataGridViewTextBoxColumn
            // 
            this.leukocyteCountDataGridViewTextBoxColumn.DataPropertyName = "LeukocyteCount";
            this.leukocyteCountDataGridViewTextBoxColumn.HeaderText = "Leukocyte Count";
            this.leukocyteCountDataGridViewTextBoxColumn.Name = "leukocyteCountDataGridViewTextBoxColumn";
            this.leukocyteCountDataGridViewTextBoxColumn.ReadOnly = true;
            this.leukocyteCountDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.leukocyteCountDataGridViewTextBoxColumn.Width = 104;
            // 
            // noteDataGridViewTextBoxColumn
            // 
            this.noteDataGridViewTextBoxColumn.DataPropertyName = "Note";
            this.noteDataGridViewTextBoxColumn.HeaderText = "Note";
            this.noteDataGridViewTextBoxColumn.Name = "noteDataGridViewTextBoxColumn";
            this.noteDataGridViewTextBoxColumn.ReadOnly = true;
            this.noteDataGridViewTextBoxColumn.Width = 55;
            // 
            // statusDataGridViewTextBoxColumn
            // 
            this.statusDataGridViewTextBoxColumn.DataPropertyName = "Status";
            this.statusDataGridViewTextBoxColumn.HeaderText = "Status";
            this.statusDataGridViewTextBoxColumn.Name = "statusDataGridViewTextBoxColumn";
            this.statusDataGridViewTextBoxColumn.ReadOnly = true;
            this.statusDataGridViewTextBoxColumn.Width = 62;
            // 
            // amountDataGridViewTextBoxColumn
            // 
            this.amountDataGridViewTextBoxColumn.DataPropertyName = "Amount";
            this.amountDataGridViewTextBoxColumn.HeaderText = "Amount";
            this.amountDataGridViewTextBoxColumn.Name = "amountDataGridViewTextBoxColumn";
            this.amountDataGridViewTextBoxColumn.ReadOnly = true;
            this.amountDataGridViewTextBoxColumn.Width = 68;
            // 
            // scheduledAtDataGridViewTextBoxColumn
            // 
            this.scheduledAtDataGridViewTextBoxColumn.DataPropertyName = "ScheduledAt";
            this.scheduledAtDataGridViewTextBoxColumn.HeaderText = "Scheduled At";
            this.scheduledAtDataGridViewTextBoxColumn.Name = "scheduledAtDataGridViewTextBoxColumn";
            this.scheduledAtDataGridViewTextBoxColumn.ReadOnly = true;
            this.scheduledAtDataGridViewTextBoxColumn.Width = 96;
            // 
            // frmDonation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lblDonationPrevious);
            this.Controls.Add(this.lblDonationNext);
            this.Controls.Add(this.lblUserPrevious);
            this.Controls.Add(this.lblUserNext);
            this.Controls.Add(this.lbUserDonations);
            this.Controls.Add(this.lbUsers);
            this.Controls.Add(this.lbSearch);
            this.Controls.Add(this.dgvUserDonations);
            this.Controls.Add(this.dgvUsers);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmDonation";
            this.Text = "frmUser";
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userDTOBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserDonations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.donationDTOBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dgvUsers;
        private System.Windows.Forms.DataGridView dgvUserDonations;
        private System.Windows.Forms.Label lbSearch;
        private System.Windows.Forms.Label lbUsers;
        private System.Windows.Forms.Label lbUserDonations;
        private System.Windows.Forms.BindingSource userDTOBindingSource;
        private System.Windows.Forms.BindingSource donationDTOBindingSource;
        private System.Windows.Forms.LinkLabel lblUserPrevious;
        private System.Windows.Forms.LinkLabel lblUserNext;
        private System.Windows.Forms.LinkLabel lblDonationPrevious;
        private System.Windows.Forms.LinkLabel lblDonationNext;
        private System.Windows.Forms.DataGridViewTextBoxColumn userNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bloodTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn verifiedDataGridViewTextBoxColumn;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.DataGridViewTextBoxColumn scheduledAtDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn amountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn noteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn leukocyteCountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn erythrocyteCountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn plateletCountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn createdAtDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn updatedAtDataGridViewTextBoxColumn;
    }
}
