using Microsoft.AspNetCore.Routing.Matching;
using Microsoft.Extensions.Logging;
using SmartyStreets.Functions.Configuration;
using SmartyStreets.Functions.Models;
using SmartyStreets.Functions.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SmartyStreets.Functions.Services
{
    public class SmartyService : ISmartyService
    {
        private readonly ISmartyConfiguration _smartyConfiguration;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<SmartyService> _logger;

        public SmartyService(ISmartyConfiguration smartyConfiguration, IHttpClientFactory httpClientFactory, ILogger<SmartyService> logger)
        {
            _smartyConfiguration = smartyConfiguration;
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        public async Task<AutoCompleteResult> SearchAddressAsync(string addressToSearchFor)
        {
            if (addressToSearchFor.Contains('#')) throw new ArgumentException("Invalid address format, cannot contain, '#'");
            
            addressToSearchFor = Uri.EscapeDataString(addressToSearchFor);

            var requestUrl = $"https://us-autocomplete-pro.api.smartystreets.com/lookup?auth-id={_smartyConfiguration.AuthenticationId}"+
                                $"&auth-token={_smartyConfiguration.AuthenticationToken}"+
                                $"&license={_smartyConfiguration.AutoCompleteLicense}"+
                                $"&source={_smartyConfiguration.AutoCompleteSource}"+
                                $"&search={addressToSearchFor}"+
                                $"&selected=";

            var response = await GetResponseFromHttpGetRequestAsync(requestUrl);

            if (!string.IsNullOrEmpty(response))
            {
                return JsonSerializer.Deserialize<AutoCompleteResult>(response);
            }

            return new AutoCompleteResult();
        }

        public async Task<List<ValidateResult>> ValidateAddress(string streetName, string cityName, string state)
        {
            return await ValidateAddress(new Address
            {
                StreetName = streetName,
                City = cityName,
                State = state
            });
        }

        public async Task<List<ValidateResult>> ValidateAddress(Address address)
        {
            var requestUrl = $"https://us-street.api.smartystreets.com/street-address?auth-id={_smartyConfiguration.AuthenticationId}"+
                $"&auth-token={_smartyConfiguration.AuthenticationToken}&license={_smartyConfiguration.License}"+
                $"&street={address.StreetName}&city={address.City}&state={address.State}&candidates=10'";

            var response = await GetResponseFromHttpGetRequestAsync(requestUrl);

            if (!string.IsNullOrEmpty(response))
            {
                return JsonSerializer.Deserialize<List<ValidateResult>>(response);
            }

            return new List<ValidateResult>();
        }

        private async Task<string> GetResponseFromHttpGetRequestAsync(string requestUrl) 
        {           
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, requestUrl);

            string responseContent = string.Empty;

            using HttpClient client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");

            HttpResponseMessage httpResponseMessage = await client.SendAsync(httpRequestMessage);
            responseContent = await httpResponseMessage.Content.ReadAsStringAsync();

            if (!httpResponseMessage.IsSuccessStatusCode)
            {
                _logger.LogError($"Request to {requestUrl} return status code {(int)httpResponseMessage.StatusCode}");
                _logger.LogError($"Response content: {responseContent}");
                throw new Exception("Did not receive 200 status from Smarty API");
            }

            return responseContent;
        }
    }
}
