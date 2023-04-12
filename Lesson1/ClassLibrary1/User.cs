using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class User
    {
        public string Name;
        public int CountRightAnswers;
        public string Diagnose;

        public User(string name)
        {
            Name = name;
            Diagnose = "Не известно";
        }
        public void AcceptRightAnswer()
        {
            CountRightAnswers++;
        }
    }
}
