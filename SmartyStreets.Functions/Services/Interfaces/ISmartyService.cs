using SmartyStreets.Functions.Models;

namespace SmartyStreets.Functions.Services.Interfaces
{
    public interface ISmartyService
    {
        Task<AutoCompleteResult> SearchAddressAsync(string addressToSearchFor);
        Task<List<ValidateResult>> ValidateAddress(string streetName, string cityName, string state);
        Task<List<ValidateResult>> ValidateAddress(Address address);
    }
}