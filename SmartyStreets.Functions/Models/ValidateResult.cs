using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SmartyStreets.Functions.Models
{
    public class ValidateResult
    {
        /// <summary>
        /// Suggestion candidate index (max of 10)
        /// </summary>
        [JsonPropertyName("candidate_index")]
        public int CandidateIndex { get; set; }

        /// <summary>
        /// First line of the suggested address
        /// </summary>
        [JsonPropertyName("delivery_line_1")]
        public string FirstLine { get; set; } = string.Empty;

        /// <summary>
        /// Last line of the suggested address
        /// </summary>
        [JsonPropertyName("last_line")]
        public string LastLine { get; set; } = string.Empty;

        /// <summary>
        /// Address components
        /// </summary>
        [JsonPropertyName("components")]
        public AddressComponent Component { get; set; } = new();

        /// <summary>
        /// Address meta data
        /// </summary>
        [JsonPropertyName("metadata")]
        public AddressMetaData MetaData { get; set; } = new();

        /// <summary>
        /// Address analysis
        /// </summary>
        [JsonPropertyName("analysis")]
        public AddressAnalysis Analysis { get; set; } = new();

        /// <summary>
        /// Address object
        /// </summary>
        public Address Address => new(Component);       
    }
}
