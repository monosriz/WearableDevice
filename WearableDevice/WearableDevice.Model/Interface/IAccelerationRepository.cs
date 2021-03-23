using System;
using System.Collections.Generic;
using System.Text;
using WearableDevice.Model.Model;

namespace WearableDevice.Model.Interface
{
    public interface IAccelerationRepository
    {
        bool Success { get; set; }
        string Message { get; set; }
       
        void SaveAccelerationObject(Acceleration Acceleration);
        void SaveAccelerationObjectByRange(List<Acceleration> Accelerations);
    }
}
