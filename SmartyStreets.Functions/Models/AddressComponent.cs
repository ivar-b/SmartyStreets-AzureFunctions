using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SmartyStreets.Functions.Models
{
    public class AddressComponent
    {
        /// <summary>
        /// Primary house number
        /// </summary>
        [JsonPropertyName("primary_number")]
        public string PrimaryNumber { get; set; } = string.Empty;

        /// <summary>
        /// Street predirection ('S','N','W','E')
        /// </summary>
        [JsonPropertyName("street_predirection")]
        public string StreetPredirection { get; set; } = string.Empty;

        /// <summary>
        /// Name of the street 
        /// </summary>
        [JsonPropertyName("street_name")]
        public string StreetName { get; set; } = string.Empty;

        /// <summary>
        /// Street suffix e.g Rd, Drv etc..
        /// </summary>
        [JsonPropertyName("street_suffix")]
        public string StreetSuffix { get; set; }

        /// <summary>
        /// Street postdirection ('S','N','W','E')
        /// </summary>
        [JsonPropertyName("street_postdirection")]
        public string StreetPostdirection { get; set; } = string.Empty;

        /// <summary>
        /// Secondary  street number (apartment or suite)
        /// </summary>
        [JsonPropertyName("secondary_number")]
        public string StreetSecondaryNumber { get; set; } = string.Empty;

        /// <summary>
        /// Location within a building
        /// </summary>
        [JsonPropertyName("secondary_designator")]
        public string SecondaryDesignator { get;set; } = string.Empty;

        /// <summary>
        /// Extra information about the location within a building 
        /// </summary>
        [JsonPropertyName("extra_secondary_number")]
        public string StreetExtraNumber { get; set; } = string.Empty;

        /// <summary>
        /// Location within a campus
        /// </summary>
        [JsonPropertyName("extra_secondary_designator")]
        public string StreetExtraInformation { get; set; } = string.Empty;  

        /// <summary>
        /// USPS used name of the city
        /// </summary>
        [JsonPropertyName("city_name")]
        public string CityName { get; set; }

        /// <summary>
        /// City name associated with the zip code
        /// </summary>
        [JsonPropertyName("default_city_name")]
        public string DefaultCityName { get; set; }

        /// <summary>
        /// State
        /// </summary>
        [JsonPropertyName("state_abbreviation")]
        public string State { get; set; }

        /// <summary>
        /// Zipcode of the address
        /// </summary>
        [JsonPropertyName("zipcode")]
        public string ZipCode { get; set; }
    }
}
