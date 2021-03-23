using System;
using System.Collections.Generic;
using System.Text;
using WearableDevice.AppServices.Messages;
using WearableDevice.Model;
using WearableDevice.Model.Model;

namespace WearableDevice.AppServices
{
  public  class ApplicationActivationService
    {

        private ActivationService _activationService;
       

        public ApplicationActivationService(ActivationService activationService)
        {
            _activationService = activationService;
           
        }
        /// <summary>
        /// This function used to generate activtion code
        /// </summary>
        /// <returns></returns>
        public ActivationCodeResponse GenerateActivationCode()
        {
            
            var _reponse = new ActivationCodeResponse();
            try
            {
               

                
                int activationCode = _activationService.CreateActivationCode();
                _reponse.Success = _activationService.Success;
                _reponse.Message = _activationService.Message;
                _reponse.ActivationCode = activationCode;





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
