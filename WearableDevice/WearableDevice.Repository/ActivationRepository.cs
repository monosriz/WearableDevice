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


        public bool GetSaveActivationCode(int activationCode)
        {
            Success = true;
           
            try
            {
                if (_context.Activations.Count() > 0)
                {
                    Activation activationItem = _context.Activations.Where(a => a.ActivationCode == activationCode).FirstOrDefault();
                    if (activationItem != null)
                        return true;
                    else
                    {
                        SaveActivationCode(activationCode);
                        Message = "Activation Code Generated successfully";
                        return false;
                    }
                      
                }
                else
                {
                    SaveActivationCode(activationCode);
                    Message = "Activation Code Generated successfully";
                    return false;
                }
            }

            catch (Exception ex)
            {
                Message = "Failed :- " + ex.Message;
                Success = false;
                return false;
                
            }

            
        }

        public void SaveActivationCode(int activationCode)
        {

            try
            {
                _context.Activations.Add(new Activation (activationCode,  DateTime.Now )); 
                _context.SaveChanges();
              
            }
            catch (Exception ex)


            {
                Message = "Failed :- " + ex.Message;
                Success = false;
               
            }


        }
    }
}
