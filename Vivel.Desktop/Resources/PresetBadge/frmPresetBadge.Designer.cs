namespace Vivel.Desktop.Resources.PresetBadge
{
    partial class frmPresetBadge
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.labelDelete = new System.Windows.Forms.LinkLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.pbPresetBadgeImage = new System.Windows.Forms.PictureBox();
            this.txtPresetBadgeDescriptionUpsert = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblPresetBadgeClear = new System.Windows.Forms.LinkLabel();
            this.txtPresetBadgeIdUpsert = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnPresetBadgeSave = new System.Windows.Forms.Button();
            this.txtPresetBadgeNameUpsert = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvPresetBadge = new System.Windows.Forms.DataGridView();
            this.presetBadgeDTOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSearchPresetBadge = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPresetBadgeNameSearch = new System.Windows.Forms.TextBox();
            this.ofdPresetBadgeImage = new System.Windows.Forms.OpenFileDialog();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createdAtDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.updatedAtDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPresetBadgeImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPresetBadge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.presetBadgeDTOBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.AutoSize = true;
            this.groupBox2.Controls.Add(this.labelDelete);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.pbPresetBadgeImage);
            this.groupBox2.Controls.Add(this.txtPresetBadgeDescriptionUpsert);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.lblPresetBadgeClear);
            this.groupBox2.Controls.Add(this.txtPresetBadgeIdUpsert);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.btnPresetBadgeSave);
            this.groupBox2.Controls.Add(this.txtPresetBadgeNameUpsert);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(667, 118);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(249, 355);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Create/Update";
            // 
            // labelDelete
            // 
            this.labelDelete.AutoSize = true;
            this.labelDelete.LinkColor = System.Drawing.Color.Red;
            this.labelDelete.Location = new System.Drawing.Point(18, 318);
            this.labelDelete.Name = "labelDelete";
            this.labelDelete.Size = new System.Drawing.Size(36, 13);
            this.labelDelete.TabIndex = 21;
            this.labelDelete.TabStop = true;
            this.labelDelete.Text = "delete";
            this.labelDelete.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.labelDelete_LinkClicked);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 174);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Image";
            // 
            // pbPresetBadgeImage
            // 
            this.pbPresetBadgeImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbPresetBadgeImage.Location = new System.Drawing.Point(21, 190);
            this.pbPresetBadgeImage.Name = "pbPresetBadgeImage";
            this.pbPresetBadgeImage.Size = new System.Drawing.Size(197, 80);
            this.pbPresetBadgeImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbPresetBadgeImage.TabIndex = 12;
            this.pbPresetBadgeImage.TabStop = false;
            this.pbPresetBadgeImage.Click += new System.EventHandler(this.pbPresetBadgeImage_Click);
            // 
            // txtPresetBadgeDescriptionUpsert
            // 
            this.txtPresetBadgeDescriptionUpsert.Location = new System.Drawing.Point(21, 140);
            this.txtPresetBadgeDescriptionUpsert.Name = "txtPresetBadgeDescriptionUpsert";
            this.txtPresetBadgeDescriptionUpsert.Size = new System.Drawing.Size(197, 20);
            this.txtPresetBadgeDescriptionUpsert.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Description";
            // 
            // lblPresetBadgeClear
            // 
            this.lblPresetBadgeClear.AutoSize = true;
            this.lblPresetBadgeClear.Location = new System.Drawing.Point(18, 282);
            this.lblPresetBadgeClear.Name = "lblPresetBadgeClear";
            this.lblPresetBadgeClear.Size = new System.Drawing.Size(30, 13);
            this.lblPresetBadgeClear.TabIndex = 9;
            this.lblPresetBadgeClear.TabStop = true;
            this.lblPresetBadgeClear.Text = "clear";
            this.lblPresetBadgeClear.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblPresetBadgeClear_LinkClicked);
            // 
            // txtPresetBadgeIdUpsert
            // 
            this.txtPresetBadgeIdUpsert.Enabled = false;
            this.txtPresetBadgeIdUpsert.Location = new System.Drawing.Point(21, 41);
            this.txtPresetBadgeIdUpsert.Name = "txtPresetBadgeIdUpsert";
            this.txtPresetBadgeIdUpsert.Size = new System.Drawing.Size(197, 20);
            this.txtPresetBadgeIdUpsert.TabIndex = 8;
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
            // btnPresetBadgeSave
            // 
            this.btnPresetBadgeSave.Location = new System.Drawing.Point(59, 313);
            this.btnPresetBadgeSave.Name = "btnPresetBadgeSave";
            this.btnPresetBadgeSave.Size = new System.Drawing.Size(159, 23);
            this.btnPresetBadgeSave.TabIndex = 6;
            this.btnPresetBadgeSave.Text = "Save";
            this.btnPresetBadgeSave.UseVisualStyleBackColor = true;
            this.btnPresetBadgeSave.Click += new System.EventHandler(this.btnPresetBadgeSave_Click);
            // 
            // txtPresetBadgeNameUpsert
            // 
            this.txtPresetBadgeNameUpsert.Location = new System.Drawing.Point(21, 90);
            this.txtPresetBadgeNameUpsert.Name = "txtPresetBadgeNameUpsert";
            this.txtPresetBadgeNameUpsert.Size = new System.Drawing.Size(197, 20);
            this.txtPresetBadgeNameUpsert.TabIndex = 1;
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
            // dgvPresetBadge
            // 
            this.dgvPresetBadge.AllowUserToAddRows = false;
            this.dgvPresetBadge.AllowUserToDeleteRows = false;
            this.dgvPresetBadge.AutoGenerateColumns = false;
            this.dgvPresetBadge.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPresetBadge.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn,
            this.descriptionDataGridViewTextBoxColumn,
            this.createdAtDataGridViewTextBoxColumn,
            this.updatedAtDataGridViewTextBoxColumn});
            this.dgvPresetBadge.DataSource = this.presetBadgeDTOBindingSource;
            this.dgvPresetBadge.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPresetBadge.Location = new System.Drawing.Point(3, 16);
            this.dgvPresetBadge.Name = "dgvPresetBadge";
            this.dgvPresetBadge.ReadOnly = true;
            this.dgvPresetBadge.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPresetBadge.Size = new System.Drawing.Size(563, 330);
            this.dgvPresetBadge.TabIndex = 0;
            this.dgvPresetBadge.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPresetBadge_CellContentClick);
            // 
            // presetBadgeDTOBindingSource
            // 
            this.presetBadgeDTOBindingSource.DataSource = typeof(Vivel.Model.Dto.PresetBadgeDTO);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvPresetBadge);
            this.groupBox1.Location = new System.Drawing.Point(56, 124);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(569, 349);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Preset badges";
            // 
            // btnSearchPresetBadge
            // 
            this.btnSearchPresetBadge.Location = new System.Drawing.Point(206, 81);
            this.btnSearchPresetBadge.Name = "btnSearchPresetBadge";
            this.btnSearchPresetBadge.Size = new System.Drawing.Size(97, 23);
            this.btnSearchPresetBadge.TabIndex = 11;
            this.btnSearchPresetBadge.Text = "Search";
            this.btnSearchPresetBadge.UseVisualStyleBackColor = true;
            this.btnSearchPresetBadge.Click += new System.EventHandler(this.btnSearchPresetBadge_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(56, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Name";
            // 
            // txtPresetBadgeNameSearch
            // 
            this.txtPresetBadgeNameSearch.Location = new System.Drawing.Point(59, 83);
            this.txtPresetBadgeNameSearch.Name = "txtPresetBadgeNameSearch";
            this.txtPresetBadgeNameSearch.Size = new System.Drawing.Size(141, 20);
            this.txtPresetBadgeNameSearch.TabIndex = 9;
            // 
            // ofdPresetBadgeImage
            // 
            this.ofdPresetBadgeImage.FileName = "openFileDialog1";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // textBox2
            // 
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(426, 43);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(138, 16);
            this.textBox2.TabIndex = 25;
            this.textBox2.Text = "Modify preset badges";
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(423, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(141, 25);
            this.textBox1.TabIndex = 24;
            this.textBox1.Text = "Preset badges";
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "Description";
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            this.descriptionDataGridViewTextBoxColumn.ReadOnly = true;
            this.descriptionDataGridViewTextBoxColumn.Width = 220;
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
            // frmPresetBadge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnSearchPresetBadge);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPresetBadgeNameSearch);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPresetBadge";
            this.Text = "frmPresetBadge";
            this.Load += new System.EventHandler(this.frmPresetBadge_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPresetBadgeImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPresetBadge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.presetBadgeDTOBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.LinkLabel lblPresetBadgeClear;
        private System.Windows.Forms.TextBox txtPresetBadgeIdUpsert;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnPresetBadgeSave;
        private System.Windows.Forms.TextBox txtPresetBadgeNameUpsert;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvPresetBadge;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.BindingSource presetBadgeDTOBindingSource;
        private System.Windows.Forms.Button btnSearchPresetBadge;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPresetBadgeNameSearch;
        private System.Windows.Forms.TextBox txtPresetBadgeDescriptionUpsert;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pbPresetBadgeImage;
        private System.Windows.Forms.OpenFileDialog ofdPresetBadgeImage;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.LinkLabel labelDelete;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn createdAtDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn updatedAtDataGridViewTextBoxColumn;
    }
}
