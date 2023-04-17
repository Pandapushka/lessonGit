using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Game
    {
        User user;
        private List<Question> questions;
        private Question currentQuestion;
        private int countQuestions;
        private int questionNumber = 0;
        public Game(User user)
        {
            this.user = user;
            questions = QuestionsStorage.GetAll();
            countQuestions = questions.Count;
        }
        public Question GetNextQuestion()
        {
            var random = new Random();
            var randomIndex = random.Next(0, questions.Count);
            currentQuestion = questions[randomIndex];
            questionNumber++;
            return currentQuestion;
        }
        public void AcceptAnswer(int userAnswer)
        {
            var rightAnswer = currentQuestion.Answer;
            if (userAnswer == rightAnswer)
            {
                user.AcceptRightAnswer();
            }
            questions.Remove(currentQuestion);
        }
        public string GetQuestionNumberText()
        {
            return "Вопрос №  " + questionNumber;
        }
        public bool End()
        {
            return questions.Count == 0;
        }
        public string CalculateDiagnose()
        {
            var diagnose = DiagnoseCalcul.CalculateDiagnose(countQuestions, user.CountRightAnswers);
            user.Diagnose = diagnose;
            UserResultsStorage.Append(user);
            return user.Name + ", Ваш диагноз: " + diagnose;
        }


    }
}
