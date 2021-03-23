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
        /// <summary>
        /// This function used Save Acceleration Object one by one in async mode
        /// </summary>
        /// <param name="acceleration"></param>
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

        /// <summary>
        /// This function used Save mutiple Acceleration object 
        /// </summary>
        /// <param name="accelerations"></param>
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
