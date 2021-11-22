using System;
using System.Collections.Generic;
using System.Text;

namespace PTM.PHDomain
{
    public class StringListResponse : ResponseBase
    {
        public IEnumerable<string> Data { get; set; }
    }
}
