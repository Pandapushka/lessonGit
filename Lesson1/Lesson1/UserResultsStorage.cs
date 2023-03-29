using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1
{
    public class UserResultsStorage
    {
        public static void AppendToFile(string fileName, string value)
        {
            StreamWriter writer = new StreamWriter(fileName, true, Encoding.UTF8);
            writer.WriteLine(value);
            writer.Close();
        }
        public static void Save(User user)
        {
            string value = $"{user.Name}#{user.CountRightAnswers}#{user.Diagnose}";
            AppendToFile("userResult.txt", value);
        }

        public static List<User> GetUserResult()
        {
            var reader = new StreamReader("userResult.txt", Encoding.UTF8);
            var results = new List<User>();
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] values = line.Split('#');
                string name = values[0];
                int countRightAnswers = Convert.ToInt32(values[1]);
                string diagnose = values[2];

                var user = new User(name);
                user.CountRightAnswers = countRightAnswers;
                user.Diagnose = diagnose;
                results.Add(user);

            }
            reader.Close();
            return results;
        }
    }
}
