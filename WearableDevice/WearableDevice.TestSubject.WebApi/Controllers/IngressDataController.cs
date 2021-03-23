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
using WearableDevice.AppServices.Messages;
using WearableDevice.Model.Model;

namespace WearableDevice.TestSubject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngressDataController : ControllerBase
    {
        ApplicationProfileService _applicationProfileService;
        ApplicationAccelerationService _applicationAccelerationService;
        string _email;
        string _password;
        public IngressDataController(ApplicationProfileService applicationProfileService, ApplicationAccelerationService applicationAccelerationService)
        {
            _applicationProfileService = applicationProfileService;
            _applicationAccelerationService = applicationAccelerationService;
        }

        [HttpPost()]
        [Route("Ingress")]

        public IActionResult Ingress([FromBody] List <Acceleration> Acceleration)

        {

            
            if (!Request.Headers.ContainsKey("Authorization"))
                return BadRequest("Missing Authorization Header");
          

          
            
                GetCredential();
                if (_applicationProfileService.IsAuthoriz(_email, _password))
                {
                    ResponseBase _reponse = _applicationAccelerationService.SaveAcceleration(Acceleration);
                    if (_reponse.Success == true)
                        return Ok(_reponse);
                    else
                        return BadRequest(_reponse.Message);
                }
                else
                    return BadRequest("you are not authorize.");
            
        }

        private void GetCredential()
        {
            var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
            var credentialBytes = Convert.FromBase64String(authHeader.Parameter);
            var credentials = Encoding.UTF8.GetString(credentialBytes).Split(new[] { ':' }, 2);
             _email = credentials[0];
            _password = credentials[1];

        }

    }
}
