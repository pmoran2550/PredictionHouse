using System;
using System.Collections.Generic;
using System.Text;

namespace PTM.PHDomain
{
    public class QuestionListResponse : ResponseBase
    {
        public IEnumerable<QuestionListItem> Data { get; set; }

    }
}
