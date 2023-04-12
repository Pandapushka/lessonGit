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
    public partial class MainForm : Form
    {
        Game game;
        public MainForm()
        {
            InitializeComponent();
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            var welcomeForm = new WelcomeForm();
            welcomeForm.ShowDialog();

            var user = new User(welcomeForm.UserNameTextBox.Text);
            game = new Game(user);
            ShowNextQuestion();
            
        }

        private void ShowNextQuestion()
        {
            
            var currentQuestion = game.GetNextQuestion();
            questionTextLabel.Text = currentQuestion.Text;
            questionNumberLabel.Text = game.GetQuestionNumberText();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var parsed = InputValidator.TryParseToNumber(userAnswerTextBox.Text, out int userAnswer, out string errorMessage);
            if (!parsed)
            {
                MessageBox.Show(errorMessage);
            }
            else
            {

                game.AcceptAnswer(userAnswer);
                userAnswerTextBox.Text = null;

                
                if (game.End())
                {
                    var message = game.CalculateDiagnose();

                    MessageBox.Show(message);


                }
                else
                {
                    ShowNextQuestion();
                }
            }
            
        }

        private int GetNumber()
        {
            int userAnswer;
            if (!int.TryParse(userAnswerTextBox.Text, out userAnswer))
            {
                
                MessageBox.Show("Введите число");
                userAnswerTextBox.Clear();
                


            }
            return userAnswer;
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void рестартToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void показатьРезультатыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var resultsForm = new ResultsForm();
            resultsForm.ShowDialog();
        }
    }
}
