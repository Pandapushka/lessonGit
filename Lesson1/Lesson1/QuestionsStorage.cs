using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1
{
    public class QuestionsStorage
    {
        public static List<Question> GetAll()
        {
            var questions = new List<Question>();
            if (FileProvider.Exists("questions.txt"))
            {
                var value = FileProvider.GetValue("questions.txt");
                var lines = value.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var line in lines)
                {

                    string[] values = line.Split('#');
                    string text = values[0];
                    int answer = Convert.ToInt32(values[1]);


                    var question = new Question(text, answer);
                    questions.Add(question);

                }
            }
            else
            {
                questions = new List<Question>();
                questions.Add(new Question("Сколько будет 2 + 2 * 2?", 6));
                questions.Add(new Question("Бревно нужно распилить на 10 частей. Сколько распилов нужно сделать?", 9));
                questions.Add(new Question("На двух руках 10 пальцев. Сколько пальцев на 5 руках?", 25));
                questions.Add(new Question("Укол делают каждые полчаса. Сколько нужно минут, чтобы сделать три укола?", 60));
                questions.Add(new Question("Пять свечей горело, две потухли. Сколько свечей осталось?", 2));
                SaveQestions(questions);
            }
            return questions;

            
        }

        private static void SaveQestions(List<Question> questions)
        {
            foreach (var question in questions)
            {
                Add(question);
            }
        }

        public static void Add(Question newQuesdtion)
        {
            string value = $"{newQuesdtion.Text}#{newQuesdtion.Answer}";
            FileProvider.Append("questions.txt", value);
        }

        public static void Remove(Question removeQuestion)
        {
            var questions = GetAll();
            for (int i = 0; i < questions.Count; i++)
            {
                if (questions[i].Text == removeQuestion.Text)
                {
                    questions.RemoveAt(i);
                    break;
                }
            }
            FileProvider.Clear("questions.txt");
            SaveQestions(questions);
        }
    }
}
