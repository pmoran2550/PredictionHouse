using System;
using System.Collections.Generic;
using System.Text;

namespace PTM.PHDomain
{
    public class ResponsesListResponse : ResponseBase
    {
        public IEnumerable<ResponsesListItem> Data { get; set; }
    }
}
