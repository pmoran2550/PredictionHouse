using System;

namespace PTM.PHDomain
{
    public class QuestionListItem
    {
        public int QuestionID { get; set; }
        public string Question { get; set; }
        public int Year { get; set; }
        public string Answer { get; set; }
        public QuestionListItem() { }
        public QuestionListItem(int questionId, string question, int year, string answer)
        {
            QuestionID = questionId;
            Question = question;
            Year = year;
            Answer = answer;
        }
    }
}
