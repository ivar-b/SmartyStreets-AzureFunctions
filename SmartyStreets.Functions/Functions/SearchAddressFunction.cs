using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using SmartyStreets.Functions.Services.Interfaces;

namespace SmartyStreets.Functions
{
    /// <summary>
    /// Search for address
    /// </summary>
    public class SearchAddressFunction
    {
        private readonly ISmartyService _smartyService;
        private readonly ILogger<SearchAddressFunction> _logger;

        /// <summary>
        /// New <see cref="SearchAddressFunction"/>
        /// </summary>
        /// <param name="smartyService">Smarty Service implementation</param>
        /// <param name="logger">Logger implementation</param>
        public SearchAddressFunction(ISmartyService smartyService, ILogger<SearchAddressFunction> logger)
        {
            _smartyService = smartyService;
            _logger = logger;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="req"></param>
        /// <param name="address"></param>
        /// <returns></returns>
        [Function("SearchAddress")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequest req, [FromQuery] string address)
        {
            _logger.LogInformation("SearchAddress function processed a request.");

            if (string.IsNullOrEmpty(address)) 
            {
                return new BadRequestObjectResult("Address is null or empty.");
            }

            try
            {
                var result = await _smartyService.SearchAddressAsync(address);

                return new OkObjectResult(result);
            }
            catch (ArgumentException ex)
            {
                return new BadRequestObjectResult(ex.ToString());
            }
            catch(Exception ex)
            {
                return new ConflictObjectResult(ex.ToString());
            }
        }
    }
}
