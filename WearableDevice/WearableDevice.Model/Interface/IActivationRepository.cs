using System;
using System.Collections.Generic;
using System.Text;
using WearableDevice.Model.Model;

namespace WearableDevice.Model.Interface
{
   public interface IActivationRepository
    {
        bool Success { get; set; }
        string Message { get; set; }
        Activation GetActivationCode(int ActivationCode);

        void SaveActivationCode(int ActivationCode);
    }
}
