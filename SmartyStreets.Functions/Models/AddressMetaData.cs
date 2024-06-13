using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SmartyStreets.Functions.Models
{
    public class AddressMetaData
    {
        [JsonPropertyName("record_type")]
        public string RecordType { get; set; } = string.Empty;

        [JsonIgnore]
        public bool IsPoBoxOrPostOffice
        {
            get
            {
                return !string.IsNullOrEmpty(RecordType) &&
                    (RecordType.Equals("g", StringComparison.OrdinalIgnoreCase) || RecordType.Equals("p", StringComparison.OrdinalIgnoreCase));
            }
        }

        /// <summary>
        /// Type of zip code, 'Unique', 'Military', 'PO Box', 'Standard'
        /// </summary>
        [JsonPropertyName("zip_type")]
        public string ZipCodeType { get; set; } = string.Empty;

        /// <summary>
        /// Name of the county
        /// </summary>
        [JsonPropertyName("county_name")]
        public string CountyName { get; set; } = string.Empty;

        /// <summary>
        /// Carrier route, 'C' City, 'R' Rural', 'H' Highway, 'B' Post Office, 'G' General
        /// </summary>
        public string CarrierRoute { get; set; } = string.Empty;

        [JsonPropertyName("congressional_district")]
        public string CongressionalDistrict { get; set; } = string.Empty;

        [JsonPropertyName("longitude")]
        public double Longitude { get; set; }

        [JsonPropertyName("latitude")]
        public double Latitude { get; set; } 

        /// <summary>
        /// Time zone of the address
        /// </summary>
        [JsonPropertyName("time_zone")]
        public string TimeZone { get;set; } = string.Empty;

        /// <summary>
        /// How many hours the time zone is offset against UTC
        /// </summary>
        [JsonPropertyName("utc_offset")]
        public int UTCOffSet { get; set; } 

        /// <summary>
        /// If area observes day light savings
        /// </summary>
        [JsonPropertyName("dst")]
        public bool DayLightSavings { get; set; }
    }
}
