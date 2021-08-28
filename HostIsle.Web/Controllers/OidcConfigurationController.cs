using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HostIsle.Web.Controllers
{
    public class OidcConfigurationController : Controller
    {
        private readonly ILogger<OidcConfigurationController> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="OidcConfigurationController"/> class.
        /// </summary>
        /// <param name="clientRequestParametersProvider"></param>
        /// <param name="logger"></param>
        public OidcConfigurationController(IClientRequestParametersProvider clientRequestParametersProvider, ILogger<OidcConfigurationController> logger)
        {
            ClientRequestParametersProvider = clientRequestParametersProvider;
            _logger = logger;
        }

        public IClientRequestParametersProvider ClientRequestParametersProvider { get; }

        [HttpGet("_configuration/{clientId}")]
        public IActionResult GetClientRequestParameters([FromRoute] string clientId)
        {
            var parameters = ClientRequestParametersProvider.GetClientParameters(HttpContext, clientId);
            return Ok(parameters);
        }
    }
}
