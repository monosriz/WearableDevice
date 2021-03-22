using System;
using System.Collections.Generic;
using System.Text;
using WearableDevice.Model.Model;

namespace WearableDevice.Model.Interface
{
   public interface IActivationRepository
    {
        bool GetByActivationCode(int ActivationCode);
    }
}
