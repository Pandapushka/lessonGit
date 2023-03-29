using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Lesson1
{
    internal class Program
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
                    
                    int userAnswer = GetUserAnswer();

                    int rightAnswer = questions[randomQuestionsIndex].Answer;
                    if (userAnswer == rightAnswer)
                    {
                        user.AcceptRightAnswer();
                    }
                    questions.RemoveAt(randomQuestionsIndex);
                    
                }


                Console.WriteLine("Количество верных ответов: " + user.CountRightAnswers);
                var diagnose = CalculateDiagnose(countQuestions, user.CountRightAnswers);
                user.Diagnose = diagnose;
                Console.WriteLine(userName + ", Ваш диагноз: " + diagnose);

                UserResultsStorage.Save(user);

                bool userChoice = GetUserChoise("Вы хотите посмотреть предыдущие результаты?");
                if (userChoice)
                {
                    ShowUserResult();
                }    


                userChoice = GetUserChoise("Вы хотите начать сначала?");
                if (userChoice == false)
                {
                    break;
                }
                
            }
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

        static string CalculateDiagnose(int countQuestions, int countRightAnswes)
        {
            string[] diagnoses = GetDiagnoses();
            int percentRightAnswers = countRightAnswes * 100 / countQuestions;
            return diagnoses[percentRightAnswers / 20];
        }

        static int GetUserAnswer()
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

       

        static string[] GetDiagnoses()
        {
            string[] diagnoses = new string[6];
            diagnoses[0] = "Идиот";
            diagnoses[1] = "Кретин";
            diagnoses[2] = "Дурак";
            diagnoses[3] = "Нормальный";
            diagnoses[4] = "Талант";
            diagnoses[5] = "Гений";
            return diagnoses;
        }
    }
}
