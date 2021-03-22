using System;
using System.Collections.Generic;
using System.Text;
using WearableDevice.AppServices.Messages;
using WearableDevice.Model;
using WearableDevice.Model.Model;

namespace WearableDevice.AppServices
{
  public  class ApplicationWearableDeviceService
    {

        private ActivationService _activationService;
        private UserProfileService _userProfileService;

        public ApplicationWearableDeviceService(ActivationService activationService, UserProfileService userProfileService)
        {
            _activationService = activationService;
            _userProfileService = userProfileService;
        }

        public ActivationCodeResponse GenerateActivationCode()
        {
            
            var _reponse = new ActivationCodeResponse();
            try
            {
               

                
                int activationCode = _activationService.CreateActivationCode();
                _reponse.Success = _activationService.Success;
                _reponse.Message = _activationService.Message;
                _reponse.ActivationCode = activationCode;





            }

            catch (Exception ex)
            {
                _reponse.Success = false;
                _reponse.Message = "Failed -  " + ex.Message;
            }


            return _reponse;

        }

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
    }
}
