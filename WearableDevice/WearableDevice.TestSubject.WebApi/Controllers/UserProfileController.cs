using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WearableDevice.AppServices;
using WearableDevice.AppServices.Messages;
using WearableDevice.Model.Model;

namespace WearableDevice.TestSubject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {

        ApplicationProfileService _applicationProfileService;

        public UserProfileController(ApplicationProfileService applicationProfileService)
        {
            _applicationProfileService = applicationProfileService;
        }

        /// <summary>
        /// Create Profile (Test Subject)
        /// </summary>
        /// <param name="Profile"></param>
        /// <returns></returns>
        [HttpPost()]
        [Route("Create")]
        public IActionResult Create([FromBody] UserProfile Profile)

        {




            UserProfileResponse _reponse = _applicationProfileService.CreateProfile(Profile) ;
            if (_reponse.Success == true)
                return Ok(_reponse);
            else
                return BadRequest(_reponse.Message);
        }

        [HttpGet]
        [Route("GetAllProfiles")]

        public IActionResult GetAllProfiles()
        {
            AllProfileResponse _reponse = _applicationProfileService.GetProfiles();

            if (_reponse.Success == true)
                return Ok(_reponse.profiles.Select(u => new { u.Email }));
            else
                return BadRequest(_reponse.Message);

        }


    }
}
