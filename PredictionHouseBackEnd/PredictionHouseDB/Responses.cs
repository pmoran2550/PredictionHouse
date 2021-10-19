using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PTM.PredictionHouseDB
{
    public partial class Responses
    {
        public int ResponseId { get; set; }
        public int QuestionId { get; set; }
        public int RespondentId { get; set; }
        public string Response { get; set; }
        public bool? Correct { get; set; }

        public virtual Questions Question { get; set; }
        public virtual Respondents Respondent { get; set; }
    }
}
