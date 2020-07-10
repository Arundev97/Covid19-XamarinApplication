using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Covid19.Models.ReportData
{
    public class CasesTimeSeries
    {
        [JsonProperty("Dailyconfirmed")]
        public string DailyConfirmed { get; set; }
        [JsonProperty("DailyDeceased")]
        public string DailyDeceased { get; set; }
        [JsonProperty("DailyRecovered")]
        public string DailyRecovered { get; set; }
        [JsonProperty("Date")]
        public string Date { get; set; }
        [JsonProperty("TotalConfirmed")]
        public string TotalConfirmed { get; set; }
        [JsonProperty("TotalDeceased")]
        public string TotalDeceased { get; set; }
        [JsonProperty("TotalRecovered")]
        public string TotalRecovered { get; set; }
    }
}
