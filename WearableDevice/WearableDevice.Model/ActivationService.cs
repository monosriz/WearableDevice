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
        public ActivationService(IActivationRepository activationRepository)
        {

            _activationRepository = activationRepository;

        }
        private string CreateActivationCode()
        {
            Random generator = new Random();
            string result = generator.Next(0, 1000000).ToString("D6");

            bool existingActivationCode = _activationRepository.GetByActivationCode(int.Parse(result));

            if (existingActivationCode)
                CreateActivationCode();

            return result;
        }
    }
}
