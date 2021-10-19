using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PTM.PredictionHouseDB
{
    public partial class RespondentLogin
    {
        public int RespondentLoginId { get; set; }
        public int RespondentId { get; set; }
        public string RespondentName { get; set; }
        public string LoginId { get; set; }

        public virtual AspNetUsers Login { get; set; }
        public virtual Respondents Respondent { get; set; }
    }
}
