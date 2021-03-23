using System;
using System.Collections.Generic;
using System.Text;
using WearableDevice.Model.Interface;
using WearableDevice.Model.Model;
using WearableDevice.Repository.Context;

namespace WearableDevice.Repository
{
   public class AccelerationRepository : IAccelerationRepository
    {
        private readonly WearableDeviceDBContext _context;
        public bool Success { get; set; }
        public string Message { get; set; }
        public AccelerationRepository(WearableDeviceDBContext context)
        {
            _context = context;
        }

        public void SaveAccelerationObject(Acceleration acceleration)
        {
            Success = true;
            try
            {
                
                _context.Accelerations.Add(acceleration);
                _context.SaveChangesAsync();

                


            }
            catch (Exception ex)
            {
                Message =  "Failed :- " + ex.Message;
                Success = false;


            }
        }

        public void SaveAccelerationObjectByRange(List<Acceleration> accelerations)
        {
            Success = true;
            try
            {
                
                _context.Accelerations.AddRange(accelerations);
                _context.SaveChanges();
                Message = "Data Saved Successfully.";



            }
            catch (Exception ex)
            {
                Message = "Failed :- " + ex.Message;
                Success = false;


            }
        }
    }
}
