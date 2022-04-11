namespace Vivel.Desktop.Resources.FAQ
{
    partial class frmFAQ
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
            this.dgvFAQs = new System.Windows.Forms.DataGridView();
            this.questionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.answerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.answeredDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createdAtDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.updatedAtDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.faqDTOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txtQuestionId = new System.Windows.Forms.TextBox();
            this.txtAnswer = new System.Windows.Forms.TextBox();
            this.lbQuestionId = new System.Windows.Forms.Label();
            this.lbAnswer = new System.Windows.Forms.Label();
            this.lbQuestion = new System.Windows.Forms.Label();
            this.txtQuestion = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnFAQSearch = new System.Windows.Forms.Button();
            this.cbFAQAnswered = new System.Windows.Forms.CheckBox();
            this.lblFAQPrevious = new System.Windows.Forms.LinkLabel();
            this.lblFAQNext = new System.Windows.Forms.LinkLabel();
            this.cbFAQFormAnswered = new System.Windows.Forms.CheckBox();
            this.lblFAQClear = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFAQs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.faqDTOBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvFAQs
            // 
            this.dgvFAQs.AllowUserToAddRows = false;
            this.dgvFAQs.AllowUserToDeleteRows = false;
            this.dgvFAQs.AllowUserToResizeColumns = false;
            this.dgvFAQs.AllowUserToResizeRows = false;
            this.dgvFAQs.AutoGenerateColumns = false;
            this.dgvFAQs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFAQs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFAQs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.questionDataGridViewTextBoxColumn,
            this.answerDataGridViewTextBoxColumn,
            this.answeredDataGridViewTextBoxColumn,
            this.createdAtDataGridViewTextBoxColumn,
            this.updatedAtDataGridViewTextBoxColumn});
            this.dgvFAQs.DataSource = this.faqDTOBindingSource;
            this.dgvFAQs.Location = new System.Drawing.Point(12, 41);
            this.dgvFAQs.MultiSelect = false;
            this.dgvFAQs.Name = "dgvFAQs";
            this.dgvFAQs.ReadOnly = true;
            this.dgvFAQs.RowHeadersVisible = false;
            this.dgvFAQs.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvFAQs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFAQs.Size = new System.Drawing.Size(452, 397);
            this.dgvFAQs.TabIndex = 2;
            this.dgvFAQs.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dgvFAQs_RowStateChanged);
            // 
            // questionDataGridViewTextBoxColumn
            // 
            this.questionDataGridViewTextBoxColumn.DataPropertyName = "Question";
            this.questionDataGridViewTextBoxColumn.HeaderText = "Question";
            this.questionDataGridViewTextBoxColumn.Name = "questionDataGridViewTextBoxColumn";
            this.questionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // answerDataGridViewTextBoxColumn
            // 
            this.answerDataGridViewTextBoxColumn.DataPropertyName = "Answer";
            this.answerDataGridViewTextBoxColumn.HeaderText = "Answer";
            this.answerDataGridViewTextBoxColumn.Name = "answerDataGridViewTextBoxColumn";
            this.answerDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // answeredDataGridViewTextBoxColumn
            // 
            this.answeredDataGridViewTextBoxColumn.DataPropertyName = "Answered";
            this.answeredDataGridViewTextBoxColumn.HeaderText = "Answered";
            this.answeredDataGridViewTextBoxColumn.Name = "answeredDataGridViewTextBoxColumn";
            this.answeredDataGridViewTextBoxColumn.ReadOnly = true;
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
            // faqDTOBindingSource
            // 
            this.faqDTOBindingSource.DataSource = typeof(Vivel.Model.Dto.FaqDTO);
            // 
            // txtQuestionId
            // 
            this.txtQuestionId.Enabled = false;
            this.txtQuestionId.Location = new System.Drawing.Point(473, 57);
            this.txtQuestionId.Name = "txtQuestionId";
            this.txtQuestionId.Size = new System.Drawing.Size(315, 20);
            this.txtQuestionId.TabIndex = 3;
            // 
            // txtAnswer
            // 
            this.txtAnswer.Location = new System.Drawing.Point(473, 179);
            this.txtAnswer.Multiline = true;
            this.txtAnswer.Name = "txtAnswer";
            this.txtAnswer.Size = new System.Drawing.Size(315, 157);
            this.txtAnswer.TabIndex = 4;
            // 
            // lbQuestionId
            // 
            this.lbQuestionId.AutoSize = true;
            this.lbQuestionId.Location = new System.Drawing.Point(470, 41);
            this.lbQuestionId.Name = "lbQuestionId";
            this.lbQuestionId.Size = new System.Drawing.Size(63, 13);
            this.lbQuestionId.TabIndex = 5;
            this.lbQuestionId.Text = "Question ID";
            // 
            // lbAnswer
            // 
            this.lbAnswer.AutoSize = true;
            this.lbAnswer.Location = new System.Drawing.Point(470, 163);
            this.lbAnswer.Name = "lbAnswer";
            this.lbAnswer.Size = new System.Drawing.Size(42, 13);
            this.lbAnswer.TabIndex = 6;
            this.lbAnswer.Text = "Answer";
            // 
            // lbQuestion
            // 
            this.lbQuestion.AutoSize = true;
            this.lbQuestion.Location = new System.Drawing.Point(470, 80);
            this.lbQuestion.Name = "lbQuestion";
            this.lbQuestion.Size = new System.Drawing.Size(49, 13);
            this.lbQuestion.TabIndex = 7;
            this.lbQuestion.Text = "Question";
            // 
            // txtQuestion
            // 
            this.txtQuestion.Location = new System.Drawing.Point(473, 96);
            this.txtQuestion.Multiline = true;
            this.txtQuestion.Name = "txtQuestion";
            this.txtQuestion.Size = new System.Drawing.Size(315, 58);
            this.txtQuestion.TabIndex = 8;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(470, 415);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(318, 23);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnFAQSearch
            // 
            this.btnFAQSearch.Location = new System.Drawing.Point(108, 8);
            this.btnFAQSearch.Name = "btnFAQSearch";
            this.btnFAQSearch.Size = new System.Drawing.Size(75, 23);
            this.btnFAQSearch.TabIndex = 12;
            this.btnFAQSearch.Text = "Search";
            this.btnFAQSearch.UseVisualStyleBackColor = true;
            this.btnFAQSearch.Click += new System.EventHandler(this.btnFAQSearch_Click);
            // 
            // cbFAQAnswered
            // 
            this.cbFAQAnswered.AutoSize = true;
            this.cbFAQAnswered.Location = new System.Drawing.Point(12, 12);
            this.cbFAQAnswered.Name = "cbFAQAnswered";
            this.cbFAQAnswered.Size = new System.Drawing.Size(73, 17);
            this.cbFAQAnswered.TabIndex = 13;
            this.cbFAQAnswered.Text = "Answered";
            this.cbFAQAnswered.UseVisualStyleBackColor = true;
            // 
            // lblFAQPrevious
            // 
            this.lblFAQPrevious.AutoSize = true;
            this.lblFAQPrevious.Enabled = false;
            this.lblFAQPrevious.Location = new System.Drawing.Point(356, 18);
            this.lblFAQPrevious.Name = "lblFAQPrevious";
            this.lblFAQPrevious.Size = new System.Drawing.Size(47, 13);
            this.lblFAQPrevious.TabIndex = 17;
            this.lblFAQPrevious.TabStop = true;
            this.lblFAQPrevious.Text = "previous";
            this.lblFAQPrevious.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblFAQPrevious_LinkClicked);
            // 
            // lblFAQNext
            // 
            this.lblFAQNext.AutoSize = true;
            this.lblFAQNext.Enabled = false;
            this.lblFAQNext.Location = new System.Drawing.Point(436, 18);
            this.lblFAQNext.Name = "lblFAQNext";
            this.lblFAQNext.Size = new System.Drawing.Size(27, 13);
            this.lblFAQNext.TabIndex = 16;
            this.lblFAQNext.TabStop = true;
            this.lblFAQNext.Text = "next";
            this.lblFAQNext.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblFAQNext_LinkClicked);
            // 
            // cbFAQFormAnswered
            // 
            this.cbFAQFormAnswered.AutoSize = true;
            this.cbFAQFormAnswered.Location = new System.Drawing.Point(473, 355);
            this.cbFAQFormAnswered.Name = "cbFAQFormAnswered";
            this.cbFAQFormAnswered.Size = new System.Drawing.Size(73, 17);
            this.cbFAQFormAnswered.TabIndex = 18;
            this.cbFAQFormAnswered.Text = "Answered";
            this.cbFAQFormAnswered.UseVisualStyleBackColor = true;
            // 
            // lblFAQClear
            // 
            this.lblFAQClear.AutoSize = true;
            this.lblFAQClear.Location = new System.Drawing.Point(470, 388);
            this.lblFAQClear.Name = "lblFAQClear";
            this.lblFAQClear.Size = new System.Drawing.Size(30, 13);
            this.lblFAQClear.TabIndex = 19;
            this.lblFAQClear.TabStop = true;
            this.lblFAQClear.Text = "clear";
            this.lblFAQClear.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblFAQClear_LinkClicked);
            // 
            // frmFAQ
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblFAQClear);
            this.Controls.Add(this.cbFAQFormAnswered);
            this.Controls.Add(this.lblFAQPrevious);
            this.Controls.Add(this.lblFAQNext);
            this.Controls.Add(this.cbFAQAnswered);
            this.Controls.Add(this.btnFAQSearch);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtQuestion);
            this.Controls.Add(this.lbQuestion);
            this.Controls.Add(this.lbAnswer);
            this.Controls.Add(this.lbQuestionId);
            this.Controls.Add(this.txtAnswer);
            this.Controls.Add(this.txtQuestionId);
            this.Controls.Add(this.dgvFAQs);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmFAQ";
            this.Text = "frmFAQ";
            ((System.ComponentModel.ISupportInitialize)(this.dgvFAQs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.faqDTOBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvFAQs;
        private System.Windows.Forms.TextBox txtQuestionId;
        private System.Windows.Forms.TextBox txtAnswer;
        private System.Windows.Forms.Label lbQuestionId;
        private System.Windows.Forms.Label lbAnswer;
        private System.Windows.Forms.BindingSource faqDTOBindingSource;
        private System.Windows.Forms.Label lbQuestion;
        private System.Windows.Forms.TextBox txtQuestion;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnFAQSearch;
        private System.Windows.Forms.CheckBox cbFAQAnswered;
        private System.Windows.Forms.LinkLabel lblFAQPrevious;
        private System.Windows.Forms.LinkLabel lblFAQNext;
        private System.Windows.Forms.DataGridViewTextBoxColumn questionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn answerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn answeredDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn createdAtDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn updatedAtDataGridViewTextBoxColumn;
        private System.Windows.Forms.CheckBox cbFAQFormAnswered;
        private System.Windows.Forms.LinkLabel lblFAQClear;
    }
}
