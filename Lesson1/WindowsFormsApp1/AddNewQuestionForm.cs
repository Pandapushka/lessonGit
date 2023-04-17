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
    public partial class AddNewQuestionForm : Form
    {
        public AddNewQuestionForm()
        {
            InitializeComponent();
        }

        private void addQuestionButton_Click(object sender, EventArgs e)
        {
            var parsed = InputValidator.TryParseToNumber(AnswerTextBox.Text, out int userAnswer, out string errorMessage);
            if (!parsed)
            {
                MessageBox.Show(errorMessage);
            }

            var newQuestion = new Question(QuestionTextBox.Text, userAnswer);
            QuestionsStorage.Add(newQuestion);

            Close();
        }
    }
}
