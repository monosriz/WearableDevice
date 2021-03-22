using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WearableDevice.Model.Interface;
using WearableDevice.Model.Model;
using WearableDevice.Repository.Context;

namespace WearableDevice.Repository
{
   public class ActivationRepository : IActivationRepository
    {

        private readonly WearableDeviceDBContext _context;
        public bool Success { get; set; }
        public string Message { get; set; }
        public ActivationRepository(WearableDeviceDBContext context)
        {
            _context = context;
        }

        public bool GetByActivationCode(int ActivationCode)
        {

            try
            {

                Activation activationItem = _context.Activations.Where(a => a.ActivationCode == ActivationCode).FirstOrDefault();
                if (activationItem != null)
                    return true;
                else
                    return false;

            }

            catch (Exception ex)
            {
                Message = "Failed :- " + ex.Message;
                Success = false;
                return false;
                
            }

            
        }
    }
}
