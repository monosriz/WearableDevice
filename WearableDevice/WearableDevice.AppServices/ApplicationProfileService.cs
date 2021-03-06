using System;
using System.Collections.Generic;
using System.Text;
using WearableDevice.AppServices.Messages;
using WearableDevice.Model;
using WearableDevice.Model.Authentication;
using WearableDevice.Model.Model;

namespace WearableDevice.AppServices
{
    public class ApplicationProfileService
    {

       
        private UserProfileService _userProfileService;
        private Authentication _authentication;

        public ApplicationProfileService( UserProfileService userProfileService, Authentication authentication)
        {
         
            _userProfileService = userProfileService;
            _authentication = authentication;
        }

        /// <summary>
        /// This function used to create a profile
        /// </summary>
        /// <param name="profile"></param>
        /// <returns></returns>
        public UserProfileResponse CreateProfile(UserProfile profile)
        {

            var _reponse = new UserProfileResponse();
            try
            {



                _userProfileService.SaveUserProfile(profile);
                _reponse.Success = _userProfileService.Success;
                _reponse.Message = _userProfileService.Message;
                _reponse.Email = profile.Email;





            }

            catch (Exception ex)
            {
                _reponse.Success = false;
                _reponse.Message = "Failed -  " + ex.Message;
            }


            return _reponse;

        }

        /// <summary>
        /// Get all profile
        /// </summary>
        /// <returns></returns>
        public AllProfileResponse GetProfiles()
        {


            var _reponse = new AllProfileResponse();
            try
            {



                _reponse.profiles = _userProfileService.GetUserProfiles();
                _reponse.Success = _userProfileService.Success;
                _reponse.Message = _userProfileService.Message;


                return _reponse;



            }

            catch (Exception ex)
            {
                _reponse.Success = false;
                _reponse.Message = "Failed -  " + ex.Message;
                return null;

            }




        }

        /// <summary>
        /// Validate authorization of user
        /// </summary>
        /// <param name="email"></param>
        /// <param name="passWord"></param>
        /// <returns></returns>
        public bool IsAuthoriz(string email, string passWord)
        {



            return _authentication.IsAuthorizedUser(email, passWord);




        }
    }
}
