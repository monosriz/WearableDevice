using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using WearableDevice.AppServices;

namespace WearableDevice.TestSubject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngressDataController : ControllerBase
    {
        ApplicationProfileService _applicationProfileService;

        public IngressDataController(ApplicationProfileService applicationProfileService)
        {
            _applicationProfileService = applicationProfileService;
        }

        [HttpGet()]
        [Route("Ingress")]

      
        public IActionResult Ingress()

        {

            
            if (!Request.Headers.ContainsKey("Authorization"))
                return BadRequest("Missing Authorization Header");
          

          
            try
            {
                var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
                var credentialBytes = Convert.FromBase64String(authHeader.Parameter);
                var credentials = Encoding.UTF8.GetString(credentialBytes).Split(new[] { ':' }, 2);
                var email = credentials[0];
                var password = credentials[1];
                if (_applicationProfileService.IsAuthoriz(email, password))
                {
                }
                else
                    return BadRequest("User is not exist.");
            }
            catch
            {
                
            }

           


            return Ok("Mono");


        }

    }
}
