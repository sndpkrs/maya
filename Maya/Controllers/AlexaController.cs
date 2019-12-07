using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alexa.NET.Request;
using Alexa.NET.Response;
using Maya.Handler.Classes;
using Maya.Handler.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Maya.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlexaController : ControllerBase
    {
        private readonly IInitialIntentHandler _initialIntentHandler;
        /// <summary>
        /// Initializes a new instance of the <see cref="AlexaController"/> class.
        /// </summary>
        /// <param name="initialIntentHandler">The intentHandler<see cref="IInitialIntentHandler"/></param>
        public AlexaController(IInitialIntentHandler initialIntentHandler)
        {
            _initialIntentHandler = initialIntentHandler;
        }

        /// <summary>
        /// The Post
        /// </summary>
        /// <param name="request">The request<see cref="SkillRequest"/></param>
        /// <returns>The <see cref="ActionResult{SkillResponse}"/></returns>
        [HttpPost("question")]
        public ActionResult<SkillResponse> Post([FromBody]SkillRequest request)
        {
            var response = _initialIntentHandler.Process(request);
            return Ok(response);
        }
    }
}
