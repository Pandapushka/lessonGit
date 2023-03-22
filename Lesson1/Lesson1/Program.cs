using System;
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
                string userName = Console.ReadLine();
                int countQuestions = 5;
                int countRightAnswes = 0;
                string[] questions = GetQuestions(countQuestions);
                int[] answers = GetAnwers(countQuestions);
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
                    Console.WriteLine("Вопрос номер: " + (i + 1));
                    Console.WriteLine(questions[i]);
                    int userAnswer = GetUserAnswer();

                    int rightAnswer = answers[i];
                    if (userAnswer == rightAnswer)
                    {
                        countRightAnswes++;
                    }
                }


                Console.WriteLine("Количество верных ответов: " + countRightAnswes);
                string diagnose = CalculateDiagnose(countQuestions, countRightAnswes);
                Console.WriteLine(userName + ", Ваш диагноз: " + diagnose);

                SaveUserResult(userName, countRightAnswes, diagnose);

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
            StreamReader reader = new StreamReader("userResult.txt", Encoding.UTF8);
            Console.WriteLine("{0,-20}{1,20}{2,10}", "Имя", "Кол-во верных ответов", "Диагноз");
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] values = line.Split('#');
                string name = values[0];
                int countRightAnswers = Convert.ToInt32(values[1]);
                string diagnose = values[2];
                Console.WriteLine("{0,-20}{1,20}{2,10}", name, countRightAnswers, diagnose);
            }
            reader.Close();
        }
        static void SaveUserResult(string userName, int countRightAnswes, string diagnose)
        {
            string value = $"{userName}#{countRightAnswes}#{diagnose}";
            AppendToFile("userResult.txt", value);
        }

        static void AppendToFile(string fileName, string value)
        {
            StreamWriter writer = new StreamWriter(fileName, true, Encoding.UTF8);
            writer.WriteLine(value);
            writer.Close();
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
