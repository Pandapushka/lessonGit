namespace WindowsFormsApp1
{
    partial class QuestionsListForm
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
            this.QuestionsDataGridView = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.delitButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.QuestionsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // QuestionsDataGridView
            // 
            this.QuestionsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.QuestionsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.QuestionsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.QuestionsDataGridView.Location = new System.Drawing.Point(12, 56);
            this.QuestionsDataGridView.MultiSelect = false;
            this.QuestionsDataGridView.Name = "QuestionsDataGridView";
            this.QuestionsDataGridView.Size = new System.Drawing.Size(643, 248);
            this.QuestionsDataGridView.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Текст";
            this.Column1.Name = "Column1";
            this.Column1.Width = 62;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Ответ";
            this.Column2.Name = "Column2";
            this.Column2.Width = 62;
            // 
            // delitButton
            // 
            this.delitButton.Location = new System.Drawing.Point(562, 12);
            this.delitButton.Name = "delitButton";
            this.delitButton.Size = new System.Drawing.Size(75, 23);
            this.delitButton.TabIndex = 1;
            this.delitButton.Text = "Удалить";
            this.delitButton.UseVisualStyleBackColor = true;
            this.delitButton.Click += new System.EventHandler(this.delitButton_Click);
            // 
            // QuestionsListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 310);
            this.Controls.Add(this.delitButton);
            this.Controls.Add(this.QuestionsDataGridView);
            this.Name = "QuestionsListForm";
            this.Text = "QuestionsListForm";
            this.Load += new System.EventHandler(this.QuestionsListForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.QuestionsDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView QuestionsDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.Button delitButton;
    }
}