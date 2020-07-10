using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Covid19.Models.ReportData
{
    public class StatewiseData
    {
        [JsonProperty("active")]
        public string active { get; set; }
        [JsonProperty("confirmed")]
        public string confirmed { get; set; }
        [JsonProperty("deaths")]
        public string deaths { get; set; }
        [JsonProperty("deltaconfirmed")]
        public string deltaconfirmed { get; set; }
        [JsonProperty("deltadeath")]
        public string deltadeath { get; set; }
        [JsonProperty("deltarecovered")]
        public string deltarecovered { get; set; }
        [JsonProperty("lastupdatedtime")]
        public string lastupdatedtime { get; set; }
        [JsonProperty("migratedother")]
        public string migratedother { get; set; }
        [JsonProperty("recovered")]
        public string recovered { get; set; }
        [JsonProperty("state")]
        public string state { get; set; }
        [JsonProperty("statecode")]
        public string statecode { get; set; }
    }
}
