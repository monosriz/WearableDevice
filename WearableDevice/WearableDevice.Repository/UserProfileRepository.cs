using System;
using System.Collections.Generic;
using System.Text;
using WearableDevice.Model.Interface;
using WearableDevice.Model.Model;
using WearableDevice.Repository.Context;
using System.Linq;

namespace WearableDevice.Repository
{
   public class UserProfileRepository: IUserProfileRepository
    {
        private readonly WearableDeviceDBContext _context;
        public bool Success { get; set; }
        public string Message { get; set; }
        public UserProfileRepository(WearableDeviceDBContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Save User Profile
        /// </summary>
        /// <param name="userProfile"></param>
      public void  SaveUserProfile(UserProfile userProfile)
        {
            Success = true;
            try
            {
                userProfile.Password=EncryptPassword.textToEncrypt(userProfile.Password);
                _context.UserProfiles.Add(userProfile);
                _context.SaveChanges();

                Message = "User profile created Successfully.";
                

            }
            catch(Exception ex)
            {
                Message = "Failed :- " + ex.Message;
                Success = false;


            }
        }

        /// <summary>
        /// Get User Profile
        /// </summary>
        /// <param name="email"></param>
        /// <param name="passWord"></param>
        /// <returns></returns>
        public UserProfile GetUserProfile(string email, string passWord)
        {
            Success = true;
            

            try
            {
                
                    UserProfile _profile = _context.UserProfiles.Where(u => u.Email == email && u.Password== EncryptPassword.textToEncrypt(passWord)).FirstOrDefault();
                    return _profile;

                

            }

            catch (Exception ex)
            {
                Message = "Failed :- " + ex.Message;
                Success = false;
                return null;

            }


        }
        /// <summary>
        /// Get All user profile
        /// </summary>
        /// <returns></returns>
        public List<UserProfile> GetAllUserProfile()
        {
            Success = true;
            try
            {
                return _context.UserProfiles.ToList();
            }
            catch (Exception ex)
            {
                Message = "Failed :- " + ex.Message;
                Success = false;
                return null;

            }
        }
    }
}
