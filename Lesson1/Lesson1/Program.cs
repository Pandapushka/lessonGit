using System;

namespace Lesson1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Коментарий для проверки
            int countQuestions = 5;
            int countRightAnswes = 0;
            string[] questions = GetQuestions(countQuestions);            
            int[] answers = GetAnwers(countQuestions);
            string[] diagnoses = GetDiagnoses(countQuestions+1);
            Random random = new Random();

            for (int i = 0; i < 1000; i++)
            {
                int index1 = random.Next(0, countQuestions);
                int index2 = random.Next(0, countRightAnswes);

                string tempQuestion = questions[index1];
                questions[index1] = questions[index2];
                questions[index2] = tempQuestion;

                int tempAnswer = answers[index1];
                answers[index1] = answers[index2];
                answers[index2] = tempAnswer;
            }

            for (int i = 0; i < countQuestions; i++)
            {
                Console.WriteLine("Вопрос номер: " + (i+1));               
                Console.WriteLine(questions[i]);
                int userAnswer = Convert.ToInt32(Console.ReadLine());
                int rightAnswer = answers[i];
                if (userAnswer == rightAnswer)
                {
                    countRightAnswes++;
                }
            }

            Console.WriteLine("Количество верных ответов: " + countRightAnswes);
            Console.WriteLine("Ваш диагноз: " + diagnoses[countRightAnswes]);
            Console.ReadLine();

        }

        static string[] GetQuestions(int countQuestions)
        {
            string[] questions = new string[countQuestions];
            questions[0] = "Сколько будет 2 + 2 * 2?";
            questions[1] = "Бревно нужно распилить на 10 частей. Сколько распилов нужно сделать?";
            questions[2] = "На двух руках 10 пальцев. Сколько пальцев на 5 руках?";
            questions[3] = "Укол делают каждые полчаса. Сколько нужно минут, чтобы сделать три укола?";
            questions[4] = "Пять свечей горело, две потухли. Сколько свечей осталось?";
            return questions;
        }
        static int[] GetAnwers(int countQuestions)
        {
            int[] answers = new int[countQuestions];
            answers[0] = 6;
            answers[1] = 9;
            answers[2] = 25;
            answers[3] = 60;
            answers[4] = 2;
            return answers;
        }

        static string[] GetDiagnoses(int countQuestions)
        {
            string[] diagnoses = new string[countQuestions+1];
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
