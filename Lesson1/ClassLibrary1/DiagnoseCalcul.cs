using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class DiagnoseCalcul
    {
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
        public static string CalculateDiagnose(int countQuestions, int countRightAnswes)
        {
            string[] diagnoses = GetDiagnoses();
            int percentRightAnswers = countRightAnswes * 100 / countQuestions;
            return diagnoses[percentRightAnswers / 20];
        }
    }
}
