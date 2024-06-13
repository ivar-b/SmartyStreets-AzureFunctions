using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartyStreets.Functions.Configuration
{
    /// <summary>
    /// Smarty Configuration class
    /// </summary>
    public class SmartyConfiguration : ISmartyConfiguration
    {
        public SmartyConfiguration()
        {
            AuthenticationId = "YOUR_KEY_HERE";
            AuthenticationToken = "YOUR_TOKEN_HERE";
            License = "us-core-cloud";
            AutoCompleteLicense = "us-autocomplete-pro-cloud";
            AutoCompleteSource = "all";
        }

        /// <summary>
        /// AuthenticationId for Smarty API
        /// </summary>
        public string AuthenticationId { get; set; } = string.Empty;

        /// <summary>
        /// Authentication token for Smarty API
        /// </summary>
        public string AuthenticationToken { get; set; } = string.Empty;

        /// <summary>
        /// License for Smarty API
        /// </summary>
        public string License { get; set; } = string.Empty;

        /// <summary>
        /// License to use auto complete for Smarty API
        /// </summary>
        public string AutoCompleteLicense { get; set; } = string.Empty;

        /// <summary>
        /// Source to use for calling auto complete for Smarty API
        /// </summary>
        public string AutoCompleteSource { get; set; } = string.Empty;
    }
}
