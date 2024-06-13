using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SmartyStreets.Functions.Models
{
    /// <summary>
    /// Address model
    /// </summary>
    public class Address
    {
        public Address() { }

        public Address(AddressComponent component) 
        {
            StreetNumber = component.PrimaryNumber;
            StreetName = FormatPrimaryStreetLine(component);
            StreetSecondLine = FormatSecondaryStreetLine(component);
            City = component.CityName;
            ZipCode = component.ZipCode;    
            State = component.State;    
        }

        [JsonPropertyName("street_number")]
        public string StreetNumber { get; set; } = string.Empty;

        /// <summary>
        /// First line of the street
        /// </summary>
        [JsonPropertyName("street")]
        public string StreetName { get; set; } = string.Empty;

        [JsonIgnore]
        public string FormattedStreetName => $"{StreetNumber} {StreetName}";

        /// <summary>
        /// Second line of the street
        /// </summary>
        [JsonPropertyName("secondary")]
        public string StreetSecondLine { get; set; } = string.Empty;

        /// <summary>
        /// City
        /// </summary>
        [JsonPropertyName("city")]
        public string City { get; set; } = string.Empty;

        /// <summary>
        /// US State
        /// </summary>
        [JsonPropertyName("state")]
        public string State { get; set; } = string.Empty;

        /// <summary>
        /// US zip code
        /// </summary>
        [JsonPropertyName("zipcode")]
        public string ZipCode { get; set; } = string.Empty;

        private static string FormatPrimaryStreetLine(AddressComponent component)
        {
            return $"{component.StreetPredirection} {component.StreetName} {component.StreetPostdirection}".Trim();
        }

        private static string FormatSecondaryStreetLine(AddressComponent component) 
        {
            return $"{component.StreetSecondaryNumber} {component.SecondaryDesignator} {component.StreetExtraNumber} {component.StreetExtraInformation}".Trim();
        }
    }
}
