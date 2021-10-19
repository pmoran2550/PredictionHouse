using System;
using System.Collections.Generic;
using System.Text;

namespace PTM.PHDomain.API_Data_Model
{
    public class PatchInstructions
    {
        public string op { get; set; }
        public string path { get; set; }
        public string value { get; set; }
    }
}
