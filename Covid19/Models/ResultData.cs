using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace Covid19.Models
{
    class ResultData
    {
        [DataMember]
        public string Status { get; set; }
        [DataMember]
        public string SlotId { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Latitude { get; set; }
        [DataMember]
        public string Longitude { get; set; }
        [DataMember]
        public string Address { get; set; }
        [DataMember]
        public string PersonId { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string MobileNumber { get; set; }
        [DataMember]
        public string DateOfBirth { get; set; }
        [DataMember]
        public string BloodGroup { get; set; }
        [DataMember]
        public int IsSystem { get; set; }
        
    }
}
