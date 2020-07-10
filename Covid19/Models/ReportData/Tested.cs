using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Covid19.Models.ReportData
{
    public class Tested
    {
        [JsonProperty("individualstestedperconfirmedcase")]
        public string individualstestedperconfirmedcase { get; set; }
        [JsonProperty("positivecasesfromsamplesreported")]
        public string positivecasesfromsamplesreported { get; set; }
        [JsonProperty("testsperconfirmedcase")]
        public string testsperconfirmedcase { get; set; }
        [JsonProperty("totalindividualstested")]
        public string totalindividualstested { get; set; }
        [JsonProperty("totalpositivecases")]
        public string totalpositivecases { get; set; }
        [JsonProperty("totalsamplestested")]
        public string totalsamplestested { get; set; }
        [JsonProperty("updatetimestamp")]
        public string updatetimestamp { get; set; }
    }
}
