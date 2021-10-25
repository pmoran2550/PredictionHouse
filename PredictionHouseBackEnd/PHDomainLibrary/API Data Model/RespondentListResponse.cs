using System;
using System.Collections.Generic;
using System.Text;

namespace PTM.PHDomain
{
    public class RespondentListResponse : ResponseBase
    {
        public IEnumerable<RespondentListItem> Data { get; set; }
    }
}
