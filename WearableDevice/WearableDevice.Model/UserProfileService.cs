using System;
using System.Collections.Generic;
using System.Text;
using WearableDevice.Model.ExceptionType;
using WearableDevice.Model.Interface;
using WearableDevice.Model.Model;
using System.Linq;

namespace WearableDevice.Model
{
    public class UserProfileService
    {
        private IUserProfileRepository _userProfileRepository;

        private IActivationRepository _activationRepository;

        public UserProfileService(IActivationRepository activationRepository, IUserProfileRepository userProfileRepository)
        {
            _activationRepository = activationRepository;
            _userProfileRepository = userProfileRepository;

        }
        public bool Success { get; set; }
        public string Message { get; set; }

        public void SaveUserProfile(UserProfile userProfile)
        {
            Success = true;
            try
            {
              Activation acctivationCode=  _activationRepository.GetActivationCode(userProfile.ActivationCode);
                if (acctivationCode!=null)
                {
                    if ((DateTime.Now - acctivationCode.DateCreated).TotalHours > 1)
                    {
                        Success = false;
                        Message = "Activation code is expired. ";
                        return;
                    }
                }
                else
                {
                    Success = false;
                    Message = "Activation code is invalid. ";
                    return;
                }

                if (userProfile != null)
                {
                    _userProfileRepository.SaveUserProfile(userProfile);
                    Success = _userProfileRepository.Success;
                    Message = _userProfileRepository.Message;
                    

                }
                else
                    throw new InvalidInputException();


            }
            catch (Exception ex)
            {

                
                Success =false;
                Message = ex.Message;


            }
        }

        public List<UserProfile> GetUserProfiles()
        {
            Success = true;
            try
            {

                
                 List <UserProfile> userProfiles=  _userProfileRepository.GetAllUserProfile();

                if (userProfiles != null)
                {

                    if (userProfiles.Count == 0)
                    {
                        Success = false;
                        Message = "No records found";
                        return null;
                    }
                    return userProfiles; 
                }
                else
                {
                    Success = _userProfileRepository.Success;
                    Message = _userProfileRepository.Message;
                    return null;

                }






            }
            catch (Exception ex)
            {


                Success = false;
                Message = ex.Message;
                return null;


            }
        }
    }
}
