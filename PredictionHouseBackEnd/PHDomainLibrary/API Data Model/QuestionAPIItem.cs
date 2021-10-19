using System;
using System.Collections.Generic;
using System.Text;

namespace PTM.PHDomain
{
    public class QuestionAPIItem
    {
        public int QuestionID { get; set; }
        public string Question { get; set; }
        public int Year { get; set; }
        public string Answer { get; set; }
        public QuestionAPIItem() { }
        public QuestionAPIItem(int questionId, string question, int year, string answer)
        {
            QuestionID = questionId;
            Question = question;
            Year = year;
            Answer = answer;
        }
    }
}
