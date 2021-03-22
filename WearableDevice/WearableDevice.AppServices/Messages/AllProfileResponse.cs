using System;
using System.Collections.Generic;
using System.Text;
using WearableDevice.Model.Model;

namespace WearableDevice.AppServices.Messages
{
   public class AllProfileResponse: ResponseBase
    {
       public List<UserProfile> profiles { get; set; }
    }
}
