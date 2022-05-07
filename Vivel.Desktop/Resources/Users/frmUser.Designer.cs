namespace Vivel.Desktop.Resources.Users
{
    partial class frmUser
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
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.userNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bloodTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.verifiedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.latitudeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.longitudeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userDTOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.labelDelete = new System.Windows.Forms.LinkLabel();
            this.txtUserPassword = new System.Windows.Forms.TextBox();
            this.lblUserClear = new System.Windows.Forms.LinkLabel();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtUserUsername = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSearchUser = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUserUsernameSearch = new System.Windows.Forms.TextBox();
            this.lblUserPrevious = new System.Windows.Forms.LinkLabel();
            this.lblUserNext = new System.Windows.Forms.LinkLabel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userDTOBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvUsers
            // 
            this.dgvUsers.AllowUserToAddRows = false;
            this.dgvUsers.AllowUserToDeleteRows = false;
            this.dgvUsers.AutoGenerateColumns = false;
            this.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.userNameDataGridViewTextBoxColumn,
            this.bloodTypeDataGridViewTextBoxColumn,
            this.verifiedDataGridViewTextBoxColumn,
            this.latitudeDataGridViewTextBoxColumn,
            this.longitudeDataGridViewTextBoxColumn});
            this.dgvUsers.DataSource = this.userDTOBindingSource;
            this.dgvUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUsers.Location = new System.Drawing.Point(3, 16);
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.ReadOnly = true;
            this.dgvUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsers.Size = new System.Drawing.Size(543, 333);
            this.dgvUsers.TabIndex = 0;
            this.dgvUsers.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsers_CellContentClick);
            // 
            // userNameDataGridViewTextBoxColumn
            // 
            this.userNameDataGridViewTextBoxColumn.DataPropertyName = "UserName";
            this.userNameDataGridViewTextBoxColumn.HeaderText = "UserName";
            this.userNameDataGridViewTextBoxColumn.Name = "userNameDataGridViewTextBoxColumn";
            this.userNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bloodTypeDataGridViewTextBoxColumn
            // 
            this.bloodTypeDataGridViewTextBoxColumn.DataPropertyName = "BloodType";
            this.bloodTypeDataGridViewTextBoxColumn.HeaderText = "BloodType";
            this.bloodTypeDataGridViewTextBoxColumn.Name = "bloodTypeDataGridViewTextBoxColumn";
            this.bloodTypeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // verifiedDataGridViewTextBoxColumn
            // 
            this.verifiedDataGridViewTextBoxColumn.DataPropertyName = "Verified";
            this.verifiedDataGridViewTextBoxColumn.HeaderText = "Verified";
            this.verifiedDataGridViewTextBoxColumn.Name = "verifiedDataGridViewTextBoxColumn";
            this.verifiedDataGridViewTextBoxColumn.ReadOnly = true;
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
            // userDTOBindingSource
            // 
            this.userDTOBindingSource.DataSource = typeof(Vivel.Model.Dto.UserDTO);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvUsers);
            this.groupBox1.Location = new System.Drawing.Point(46, 112);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(549, 352);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Users";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.labelDelete);
            this.groupBox2.Controls.Add(this.txtUserPassword);
            this.groupBox2.Controls.Add(this.lblUserClear);
            this.groupBox2.Controls.Add(this.btnSave);
            this.groupBox2.Controls.Add(this.txtUserID);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtUserUsername);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(669, 112);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(319, 352);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Create/Update";
            // 
            // labelDelete
            // 
            this.labelDelete.AutoSize = true;
            this.labelDelete.LinkColor = System.Drawing.Color.Red;
            this.labelDelete.Location = new System.Drawing.Point(19, 210);
            this.labelDelete.Name = "labelDelete";
            this.labelDelete.Size = new System.Drawing.Size(36, 13);
            this.labelDelete.TabIndex = 22;
            this.labelDelete.TabStop = true;
            this.labelDelete.Text = "delete";
            this.labelDelete.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.labelDelete_LinkClicked);
            // 
            // txtUserPassword
            // 
            this.txtUserPassword.Location = new System.Drawing.Point(22, 138);
            this.txtUserPassword.Name = "txtUserPassword";
            this.txtUserPassword.Size = new System.Drawing.Size(197, 20);
            this.txtUserPassword.TabIndex = 0;
            // 
            // lblUserClear
            // 
            this.lblUserClear.AutoSize = true;
            this.lblUserClear.Location = new System.Drawing.Point(19, 172);
            this.lblUserClear.Name = "lblUserClear";
            this.lblUserClear.Size = new System.Drawing.Size(30, 13);
            this.lblUserClear.TabIndex = 20;
            this.lblUserClear.TabStop = true;
            this.lblUserClear.Text = "clear";
            this.lblUserClear.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblUserClear_LinkClicked);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(81, 205);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(138, 23);
            this.btnSave.TabIndex = 19;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtUserID
            // 
            this.txtUserID.Enabled = false;
            this.txtUserID.Location = new System.Drawing.Point(22, 41);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(197, 20);
            this.txtUserID.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(18, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "ID";
            // 
            // txtUserUsername
            // 
            this.txtUserUsername.Location = new System.Drawing.Point(22, 90);
            this.txtUserUsername.Name = "txtUserUsername";
            this.txtUserUsername.Size = new System.Drawing.Size(197, 20);
            this.txtUserUsername.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Username";
            // 
            // btnSearchUser
            // 
            this.btnSearchUser.Enabled = false;
            this.btnSearchUser.Location = new System.Drawing.Point(196, 68);
            this.btnSearchUser.Name = "btnSearchUser";
            this.btnSearchUser.Size = new System.Drawing.Size(97, 23);
            this.btnSearchUser.TabIndex = 14;
            this.btnSearchUser.Text = "Search";
            this.btnSearchUser.UseVisualStyleBackColor = true;
            this.btnSearchUser.Click += new System.EventHandler(this.btnSearchUser_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(46, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Username";
            // 
            // txtUserUsernameSearch
            // 
            this.txtUserUsernameSearch.Location = new System.Drawing.Point(49, 70);
            this.txtUserUsernameSearch.Name = "txtUserUsernameSearch";
            this.txtUserUsernameSearch.Size = new System.Drawing.Size(141, 20);
            this.txtUserUsernameSearch.TabIndex = 12;
            // 
            // lblUserPrevious
            // 
            this.lblUserPrevious.AutoSize = true;
            this.lblUserPrevious.Enabled = false;
            this.lblUserPrevious.Location = new System.Drawing.Point(489, 96);
            this.lblUserPrevious.Name = "lblUserPrevious";
            this.lblUserPrevious.Size = new System.Drawing.Size(47, 13);
            this.lblUserPrevious.TabIndex = 17;
            this.lblUserPrevious.TabStop = true;
            this.lblUserPrevious.Text = "previous";
            this.lblUserPrevious.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblUserPrevious_LinkClicked);
            // 
            // lblUserNext
            // 
            this.lblUserNext.AutoSize = true;
            this.lblUserNext.Enabled = false;
            this.lblUserNext.Location = new System.Drawing.Point(569, 96);
            this.lblUserNext.Name = "lblUserNext";
            this.lblUserNext.Size = new System.Drawing.Size(27, 13);
            this.lblUserNext.TabIndex = 16;
            this.lblUserNext.TabStop = true;
            this.lblUserNext.Text = "next";
            this.lblUserNext.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblUserNext_LinkClicked);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(296, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Password (leave blank if you don\'t want to change password)";
            // 
            // frmUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.lblUserPrevious);
            this.Controls.Add(this.lblUserNext);
            this.Controls.Add(this.btnSearchUser);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtUserUsernameSearch);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmUser";
            this.Text = "frmUser";
            this.Load += new System.EventHandler(this.frmUser_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userDTOBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvUsers;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtUserID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtUserUsername;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.LinkLabel lblUserClear;
        private System.Windows.Forms.TextBox txtUserPassword;
        private System.Windows.Forms.Button btnSearchUser;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtUserUsernameSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn userNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bloodTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn verifiedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn latitudeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn longitudeDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource userDTOBindingSource;
        private System.Windows.Forms.LinkLabel lblUserPrevious;
        private System.Windows.Forms.LinkLabel lblUserNext;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.LinkLabel labelDelete;
        private System.Windows.Forms.Label label3;
    }
}