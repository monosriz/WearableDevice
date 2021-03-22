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


        public Activation GetActivationCode(int activationCode)
        {
            Success = true;
           
            try
            {
                if (_context.Activations.Count() > 0)
                {
                    Activation activationItem = _context.Activations.Where(a => a.ActivationCode == activationCode).FirstOrDefault();
                    return activationItem;
                      
                }
                else
                     return null;
            
            }

            catch (Exception ex)
            {
                Message = "Failed :- " + ex.Message;
                Success = false;
                return null;
                
            }

            
        }

        public void SaveActivationCode(int activationCode)
        {
            Success = true;
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
