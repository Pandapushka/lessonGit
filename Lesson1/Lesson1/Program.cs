using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Lesson1
{
    public class Program
    {
        static void Main(string[] args)
        {

            while (true)
            {
                Console.WriteLine("Введите свое имя: ");
                var userName = Console.ReadLine();
                var user = new User(userName);
                
                               
                var questions =  QuestionsStorage.GetAll();
                var countQuestions = questions.Count;
                Random random = new Random();

                

                for (int i = 0; i < countQuestions; i++)
                {
                    Console.WriteLine("Вопрос номер: " + (i + 1));
                    
                    var randomQuestionsIndex = random.Next(0, questions.Count);
                    Console.WriteLine(questions[randomQuestionsIndex].Text);
                    
                    int userAnswer = GetNumber();

                    int rightAnswer = questions[randomQuestionsIndex].Answer;
                    if (userAnswer == rightAnswer)
                    {
                        user.AcceptRightAnswer();
                    }
                    questions.RemoveAt(randomQuestionsIndex);
                    
                }


                Console.WriteLine("Количество верных ответов: " + user.CountRightAnswers);
                var diagnose = DiagnoseCalcul.CalculateDiagnose(countQuestions, user.CountRightAnswers);
                user.Diagnose = diagnose;
                Console.WriteLine(userName + ", Ваш диагноз: " + diagnose);

                UserResultsStorage.Save(user);

                bool userChoice = GetUserChoise("Вы хотите посмотреть предыдущие результаты?");
                if (userChoice)
                {
                    ShowUserResult();
                }

                userChoice = GetUserChoise("Хотите добавить новый вопрос?");
                if (userChoice)
                {
                    AddNewQuestion();
                }

                userChoice = GetUserChoise("Хотите удалить вопрос?");
                if (userChoice)
                {
                    RemoveQestion();
                }


                userChoice = GetUserChoise("Вы хотите начать сначала?");
                if (userChoice == false)
                {
                    break;
                }
                
            }
        }

        private static void RemoveQestion()
        {
            Console.WriteLine("Введите номер удаляемого вопроса");
            var questions = QuestionsStorage.GetAll();
            for (int i = 0; i < questions.Count; i++)
            {
                Console.WriteLine((i+1) + ". " + questions[i].Text);
            }
            var removeQuestionNumber = GetNumber();
            while (removeQuestionNumber < 1 || removeQuestionNumber > questions.Count)
            {
                Console.WriteLine("Введите число от 1 до " + questions.Count);
                removeQuestionNumber = GetNumber();
            }

            var removeQuestion = questions[removeQuestionNumber - 1];
            QuestionsStorage.Remove(removeQuestion);


        }

        private static void AddNewQuestion()
        {
            Console.WriteLine("Введите текст вопроса?");
            var text = Console.ReadLine();
            Console.WriteLine("Введите ответ на вопрос:?");
            var answer = GetNumber();

            var newQuesdtion = new Question(text, answer);
            QuestionsStorage.Add(newQuesdtion);


        }

        static void ShowUserResult()
        {
            var result = UserResultsStorage.GetUserResult();
            Console.WriteLine("{0,-20}{1,20}{2,10}", "Имя", "Кол-во верных ответов", "Диагноз");
            foreach(var user in result)
            {
                
                Console.WriteLine("{0,-20}{1,20}{2,10}", user.Name, user.CountRightAnswers, user.Diagnose);
            }
            
        }
        

        static bool GetUserChoise(string v)
        {
            while (true)
            {
                Console.WriteLine(v);
                string choise = Console.ReadLine();
                if (choise == "Да" || choise == "да" || choise == "ДА")
                {
                    return true;
                }
                else if (choise == "Нет" || choise == "НЕТ" || choise == "нет")
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("Введите: Да или Нет");
                }
            }
        }

        static int GetNumber()
        {
            
            while (true)
            {
                try
                {
                    return Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Введите число");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Введите число от -2*10^9 до 2*10^9");
                }
                

            }

            
        }

       

        
    }
}
