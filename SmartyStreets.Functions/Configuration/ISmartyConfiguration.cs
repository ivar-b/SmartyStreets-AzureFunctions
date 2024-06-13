namespace SmartyStreets.Functions.Configuration
{
    public interface ISmartyConfiguration
    {
        /// <summary>
        /// AuthenticationId for Smarty API
        /// </summary>
        string AuthenticationId { get; set; }

        /// <summary>
        /// Authentication token for Smarty API
        /// </summary>
        string AuthenticationToken { get; set; }

        /// <summary>
        /// License for Smarty API
        /// </summary>
        string AutoCompleteLicense { get; set; }

        /// <summary>
        /// License to use auto complete for Smarty API
        /// </summary>
        string AutoCompleteSource { get; set; }

        /// <summary>
        /// Source to use for calling auto complete for Smarty API
        /// </summary>
        string License { get; set; }
    }
}