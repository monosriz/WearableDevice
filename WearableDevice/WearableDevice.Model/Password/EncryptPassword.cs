using System;
using System.Collections.Generic;
using System.Text;

namespace WearableDevice.Model.Model
{
   

    public static class EncryptPassword
    {
        public static string textToEncrypt(string paasWord)
        {
            return Convert.ToBase64String(System.Security.Cryptography.SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(paasWord)));
        }
    }
}
