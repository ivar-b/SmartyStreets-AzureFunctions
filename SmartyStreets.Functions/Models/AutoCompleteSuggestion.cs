using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SmartyStreets.Functions.Models
{ 
    public class AutoCompleteSuggestion
    {
        /// <summary>
        /// Suggest street
        /// </summary>
        [JsonPropertyName("street_line")]
        public string Street { get; set; } // street_line

        /// <summary>
        /// Suggest street secondary line
        /// </summary>
        [JsonPropertyName("secondary")]
        public string StreetSecondLine { get; set; } // secondary

        /// <summary>
        /// Suggest city
        /// </summary>
        [JsonPropertyName("city")]
        public string City { get; set; } // city

        /// <summary>
        /// Suggested state
        /// </summary>
        [JsonPropertyName("state")]
        public string State { get; set; } // state

        /// <summary>
        /// Suggested zipcode
        /// </summary>
        [JsonPropertyName("zipcode")]
        public string ZipCode { get; set; } // zipcode

        /// <summary>
        /// Number of suggestions
        /// </summary>
        [JsonPropertyName("entries")]
        public int Entries { get; set; } // entries

        /// <summary>
        /// Source of the address
        /// </summary>
        [JsonPropertyName("source")]
        public string Source { get; set; }  // source
    }
}