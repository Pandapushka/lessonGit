using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class UserResultsStorage
    {
        
        public static void Save(User user)
        {
            string value = $"{user.Name}#{user.CountRightAnswers}#{user.Diagnose}";
            FileProvider.Append("userResult.txt", value);
        }

        public static List<User> GetUserResult()
        {
            var value =FileProvider.GetValue("userResult.txt");
            var lines = value.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            var results = new List<User>();
            foreach(var line in lines)
            {
                
                var values = line.Split('#');
                var name = values[0];
                var countRightAnswers = Convert.ToInt32(values[1]);
                var diagnose = values[2];

                var user = new User(name);
                user.CountRightAnswers = countRightAnswers;
                user.Diagnose = diagnose;
                results.Add(user);

            }
            
            return results;
        }
    }
}
