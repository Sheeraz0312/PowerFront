using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PowerFront.Models
{
    public class OperatorReportFilterViewModel
    {
        public string DateFilter { get; set; }
        public string PreDefined { get; set; }
        public DateTime  From { get; set; }
        public DateTime  To { get; set; }
        public string Website { get; set; }
        public string Device { get; set; }
    }
}