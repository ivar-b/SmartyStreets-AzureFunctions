using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SmartyStreets.Functions.Models
{
    public class AddressAnalysis
    {
        [JsonPropertyName("enhanced_match")]
        public string EnhancedMatch { get; set; } = string.Empty;

        /// <summary>
        /// Y or N
        /// </summary>
        [JsonPropertyName("active")]
        public string Active { get; set; } = string.Empty;

        [JsonIgnore]
        public bool IsActive => Active.ToLower().Equals("Y");

        [JsonIgnore]
        public bool IsEnhancedMatch
        {
            get
            {
                if (string.IsNullOrEmpty(EnhancedMatch)) return true;

                var matchCodes = EnhancedMatch.Split(',');

                return matchCodes.Any(x => x.Trim().Equals("none", StringComparison.OrdinalIgnoreCase));
            }

        }
    }
}
