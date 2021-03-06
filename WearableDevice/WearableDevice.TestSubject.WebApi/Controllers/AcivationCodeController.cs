using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WearableDevice.AppServices;

namespace WearableDevice.TestSubject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcivationCodeController : ControllerBase
    {
        ApplicationActivationService _applicationActivationService;

        public AcivationCodeController(ApplicationActivationService applicationActivationService)
        {
            _applicationActivationService = applicationActivationService;
        }

       /// <summary>
       /// This method used to genearate activation code 
       /// </summary>
       /// <returns></returns>
        [HttpGet()]
        [Route("GenerateActivationCode")]
        public IActionResult GenerateActivationCode()

        {

           

                var _reponse = _applicationActivationService.GenerateActivationCode();
                if (_reponse.Success == true)
                    return Ok(_reponse);
                else
                    return BadRequest(_reponse.Message);
           

        }
    }
}
