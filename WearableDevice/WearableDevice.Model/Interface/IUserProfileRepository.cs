using System;
using System.Collections.Generic;
using System.Text;
using WearableDevice.Model.Model;

namespace WearableDevice.Model.Interface
{
    public interface IUserProfileRepository
    {

        bool Success { get; set; }
        string Message { get; set; }
        List<UserProfile> GetAllUserProfile();
        UserProfile GetUserProfile(string email, string passWord);
        void SaveUserProfile(UserProfile UserProfile);

    }
}
