using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
        public static string Path = "userResult.json";


        public static void Append(User user)
        {
            var usersResults = GetUserResult();
            usersResults.Add(user);
            Save(usersResults);
        }

        public static List<User> GetUserResult()
        {
            if (!FileProvider.Exists(Path))
            {
                return new List<User>();
            }
            var value =FileProvider.GetValue(Path);
            var userResults = JsonConvert.DeserializeObject<List<User>>(value);            
            return userResults;
        }

        static void Save(List<User> usersResults)
        {
          var jsonData =  JsonConvert.SerializeObject(usersResults);
          FileProvider.Replase(Path, jsonData);
        }
    }
}
