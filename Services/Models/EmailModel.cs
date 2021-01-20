using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Models
{
    public class EmailModel
    {
        public string To { get; set; }
        public string From { get; set; }
        public string Subject { get; set; }        
        public string Body { get; set; }
        public string CC { get; set; }
    }
}
