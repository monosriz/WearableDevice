using System;
using System.Collections.Generic;
using System.Text;
using WearableDevice.Model.Interface;

namespace WearableDevice.Model.Authentication
{
    public class Authentication
    {

        private IUserProfileRepository _userProfileRepository;

      

        public Authentication( IUserProfileRepository userProfileRepository)
        {
          
            _userProfileRepository = userProfileRepository;

        }

        public  bool IsAuthorizedUser(string email, string passWord)
        {
            


            if (_userProfileRepository.GetUserProfile(email, passWord) != null)
                return true;
            else
                return false;

        }
    }
}
