using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WearableDevice.Model.ExceptionType;
using WearableDevice.Model.Interface;
using WearableDevice.Model.Model;

namespace WearableDevice.Model
{
   public class AccelerationService
    {
        private IAccelerationRepository _accelerationRepository;

       

        public AccelerationService(IAccelerationRepository accelerationRepository)
        {
            _accelerationRepository = accelerationRepository;
           

        }
        public bool Success { get; set; }
        public string Message { get; set; }

        

        public void SaveAcceleration(List<Acceleration> accelerations)
        {
            Success = true;
            try
            {
              

                if (accelerations != null)
                {

                    if (accelerations.Count > 1)
                    {

                        Parallel.ForEach(accelerations, a =>
                        {
                            _accelerationRepository.SaveAccelerationObject(a);
                        });

                    }
                    else
                    {
                        _accelerationRepository.SaveAccelerationObjectByRange(accelerations);
                    }

                    Message = "Data Processing completed" ;

                }
                else
                    throw new InvalidInputException();


            }
            catch (Exception ex)
            {


                Success = false;
                Message = ex.Message;


            }
        }

    }
}
