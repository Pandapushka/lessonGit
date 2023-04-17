using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class QuestionsListForm : Form
    {
        public QuestionsListForm()
        {
            InitializeComponent();
        }

        private void QuestionsListForm_Load(object sender, EventArgs e)
        {
            var questions = QuestionsStorage.GetAll();
            foreach (var question in questions)
            {
                QuestionsDataGridView.Rows.Add(question.Text, question.Answer);
            }
        }

        private void delitButton_Click(object sender, EventArgs e)
        {
            var rows = QuestionsDataGridView.SelectedRows;
            if (rows.Count == 0)
            {
                MessageBox.Show("Вы не выбрали строку с вопросом");
                return;
            }

            var questionsText = rows[0].Cells[0].Value.ToString();
            if (questionsText != null)
            {
                QuestionsStorage.Remove(questionsText);
            }
            Close();
        }
    }
}
