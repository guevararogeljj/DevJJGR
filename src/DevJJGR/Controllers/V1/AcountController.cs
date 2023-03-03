
using Microsoft.AspNetCore.Mvc;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DevJJGR.Controllers.V1
{
    [ApiVersion("1.0")]
    public class AcountController : BaseApiController
    {
        private readonly IConfiguration _config;

        public AcountController(IConfiguration config)
        {
            this._config = config;
        }

    }
}


