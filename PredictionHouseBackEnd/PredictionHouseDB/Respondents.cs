using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PTM.PredictionHouseDB
{
    public partial class Respondents
    {
        public Respondents()
        {
            RespondentLogin = new HashSet<RespondentLogin>();
            Responses = new HashSet<Responses>();
        }

        public int RespondentId { get; set; }
        public string RespondentName { get; set; }
        public string RespondentGroup { get; set; }

        public virtual ICollection<RespondentLogin> RespondentLogin { get; set; }
        public virtual ICollection<Responses> Responses { get; set; }
    }
}
