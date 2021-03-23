using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WearableDevice.Model.Interface;
using WearableDevice.Model.Model;

namespace WearableDevice.Model
{
   public class ActivationService
    {

        private IActivationRepository _activationRepository;

        public bool Success { get; set; }
        public string Message { get; set; }
        public ActivationService(IActivationRepository activationRepository)
        {

            _activationRepository = activationRepository;

        }

        /// <summary>
        /// This function used for Creating a new activation code
        /// </summary>
        /// <returns></returns>
        public int CreateActivationCode()
        {
            Success = true;
            try
            {
                Random generator = new Random();
                string result = generator.Next(0, 1000000).ToString("D6");

                Activation existingActivationCode = _activationRepository.GetActivationCode(int.Parse(result));
                if (_activationRepository.Success)
                {

                    if (existingActivationCode!=null)
                        CreateActivationCode();

                    _activationRepository.SaveActivationCode(int.Parse(result));
                    Success = _activationRepository.Success;
                    Message = _activationRepository.Message;

                    return int.Parse(result);


                }
                else
                {
                    Success = _activationRepository.Success;
                    Message = _activationRepository.Message;
                    return 0;
                }
               
            }
            catch (Exception ex)
            {
                Message = "Failed :- " + ex.Message;
                Success = false;
                return 0;
            }
        }
    }
}
