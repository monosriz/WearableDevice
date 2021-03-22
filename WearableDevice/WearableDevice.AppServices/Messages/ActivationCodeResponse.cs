using System;
using System.Collections.Generic;
using System.Text;

namespace WearableDevice.AppServices.Messages
{
   public class ActivationCodeResponse : ResponseBase
    {
        public int ActivationCode { get; set; }
    }
}
