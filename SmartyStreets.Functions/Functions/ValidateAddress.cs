using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using SmartyStreets.Functions.Models;
using SmartyStreets.Functions.Services.Interfaces;

namespace SmartyStreets.Functions
{
    public class ValidateAddress
    {
        private readonly ILogger<ValidateAddress> _logger;
        private readonly ISmartyService _smartyService;

        /// <summary>
        /// New <see cref="SearchAddressFunction"/>
        /// </summary>
        /// <param name="smartyService">Smarty Service implementation</param>
        /// <param name="logger">Logger implementation</param>
        public ValidateAddress(ISmartyService smartyService, ILogger<ValidateAddress> logger)
        {
            _logger = logger;
            _smartyService = smartyService;
        }

        [Function("ValidateAddress")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req, [FromBody] Address address)
        {
            _logger.LogInformation("ValidateAddress function processed a request.");
            try
            {
                var result = await _smartyService.ValidateAddress(address);

                return new OkObjectResult(result);
            }
            catch (Exception ex)
            {
                return new ConflictObjectResult(ex.ToString());
            }
        }
    }
}
