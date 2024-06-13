using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SmartyStreets.Functions.Models
{
    public class AutoCompleteResult
    {
        [JsonPropertyName("suggestions")]
        public List<AutoCompleteSuggestion> Suggestions { get; set; } = new();
    }
}
