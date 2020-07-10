using System;
using System.Collections.Generic;
using System.Text;

namespace Covid19.Models.Dashboard
{
    public class Track
    {
        public string location { get; set; }
        public string confirmed { get; set; }
        public string dead { get; set; }
        public string recovered { get; set; }
        public string updated { get; set; }
    }
}
