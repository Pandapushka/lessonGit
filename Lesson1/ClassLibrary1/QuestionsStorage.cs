using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class QuestionsStorage
    {
        public static string Path = "questions.json";
        public static List<Question> GetAll()
        {
            var questions = new List<Question>();
            if (FileProvider.Exists(Path))
            {
                var value = FileProvider.GetValue(Path);
                questions = JsonConvert.DeserializeObject<List<Question>>(value);
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
            var jsonData = JsonConvert.SerializeObject(questions);
            FileProvider.Replase(Path, jsonData);
        }

        public static void Add(Question newQuesdtion)
        {
            var questions = GetAll();
            questions.Add(newQuesdtion);
            SaveQestions(questions);
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
           
            SaveQestions(questions);
        }
        public static void Remove(string text)
        {
            var questions = GetAll();
            for (int i = 0; i < questions.Count; i++)
            {
                if (questions[i].Text == text)
                {
                    questions.RemoveAt(i);
                    break;
                }
            }

            SaveQestions(questions);
        }
    }
}
