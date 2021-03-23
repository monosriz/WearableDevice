using System;
using System.Collections.Generic;
using System.Text;
using WearableDevice.AppServices.Messages;
using WearableDevice.Model;
using WearableDevice.Model.Model;

namespace WearableDevice.AppServices
{
    public class ApplicationAccelerationService
    {
        private AccelerationService _accelerationService;


        public ApplicationAccelerationService(AccelerationService accelerationService)
        {
            _accelerationService = accelerationService;

        }

        public ResponseBase SaveAcceleration(List<Acceleration> accelerations)
        {

            var _reponse = new ResponseBase();
            try
            {



                _accelerationService.SaveAcceleration(accelerations);
                _reponse.Success = _accelerationService.Success;
                _reponse.Message = _accelerationService.Message;
                





            }

            catch (Exception ex)
            {
                _reponse.Success = false;
                _reponse.Message = "Failed -  " + ex.Message;
            }


            return _reponse;

        }
    }
}
