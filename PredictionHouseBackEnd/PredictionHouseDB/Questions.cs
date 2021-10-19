using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PTM.PredictionHouseDB
{
    public partial class Questions
    {
        public Questions()
        {
            Responses = new HashSet<Responses>();
        }
        public Questions(string question, int? year, string answer = "")
        {
            Question = question;
            Year = year;            
            Answer = (answer == "") ? null: answer;
        }


        public int QuestionId { get; set; }
        public string Question { get; set; }
        public int? Year { get; set; }
        public string Answer { get; set; }

        public virtual ICollection<Responses> Responses { get; set; }
    }
}
