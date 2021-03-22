using System;
using System.Collections.Generic;
using System.Text;
using WearableDevice.AppServices.Messages;
using WearableDevice.Model;

namespace WearableDevice.AppServices
{
  public  class ApplicationWearableDeviceService
    {

        private ActivationService _activationService;

        public ApplicationWearableDeviceService(ActivationService activationService)
        {
            _activationService = activationService;
        }

        public ActivationCodeResponse GenerateActivationCode()
        {
            
            var _reponse = new ActivationCodeResponse();
            try
            {
               

                
                int strResult = _activationService.CreateActivationCode();
                _reponse.Success = _activationService.Success;
                _reponse.Message = _activationService.Message;






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
