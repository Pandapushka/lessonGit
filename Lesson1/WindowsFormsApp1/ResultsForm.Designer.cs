namespace WindowsFormsApp1
{
    partial class ResultsForm
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
            this.resultsDataGridView = new System.Windows.Forms.DataGridView();
            this.UserNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CountRightAnswersColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiagnoseColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.resultsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // resultsDataGridView
            // 
            this.resultsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resultsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UserNameColumn,
            this.CountRightAnswersColumn,
            this.DiagnoseColumn});
            this.resultsDataGridView.Location = new System.Drawing.Point(12, 12);
            this.resultsDataGridView.Name = "resultsDataGridView";
            this.resultsDataGridView.Size = new System.Drawing.Size(355, 279);
            this.resultsDataGridView.TabIndex = 0;
            // 
            // UserNameColumn
            // 
            this.UserNameColumn.HeaderText = "Имя";
            this.UserNameColumn.Name = "UserNameColumn";
            // 
            // CountRightAnswersColumn
            // 
            this.CountRightAnswersColumn.HeaderText = "Кол-во правельных ответов";
            this.CountRightAnswersColumn.Name = "CountRightAnswersColumn";
            // 
            // DiagnoseColumn
            // 
            this.DiagnoseColumn.HeaderText = "Диагноз";
            this.DiagnoseColumn.Name = "DiagnoseColumn";
            // 
            // ResultsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 303);
            this.Controls.Add(this.resultsDataGridView);
            this.Name = "ResultsForm";
            this.Text = "ResultsForm";
            this.Load += new System.EventHandler(this.ResultsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.resultsDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView resultsDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CountRightAnswersColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiagnoseColumn;
    }
}