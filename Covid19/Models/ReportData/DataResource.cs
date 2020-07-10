using System;
using System.Collections.Generic;
using System.Text;

namespace Covid19.Models.ReportData
{
    public class DataResource
    {
        public List<CasesTimeSeries> cases_time_series { get; set; }
        public List<StatewiseData> statewise { get; set; }
        public List<Tested> tested { get; set; }
    }
}
