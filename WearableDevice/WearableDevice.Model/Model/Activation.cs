using System;
using System.Collections.Generic;
using System.Text;

namespace WearableDevice.Model.Model
{
   public class Activation
    {
        public Activation(int  activationCode, DateTime dateCreated)
        {
            this.ActivationCode = ActivationCode;
            this.DateCreated = dateCreated;
        }


     

        public int ActivationCode
        { get; set; }
        

        public DateTime DateCreated
        { get; set; }

    }
}
