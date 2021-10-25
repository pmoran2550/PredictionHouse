using System;
using System.Collections.Generic;
using System.Text;

namespace PTM.PHDomain
{
    public class ResponsesListItem
    {
        public int ResponseID { get; set; }
        public int QuestionID { get; set; }
        public int RespondentID { get; set; }
        public string Response { get; set; }
        public bool? Correct { get; set; }
    }
}
