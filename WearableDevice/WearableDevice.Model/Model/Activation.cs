using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WearableDevice.Model.Model
{
   public class Activation
    {
        public Activation(int  activationCode, DateTime dateCreated)
        {
            this.ActivationCode = activationCode;
            this.DateCreated = dateCreated;
        }



        [Key]
        public int ActivationCode
        { get; set; }
        

        public DateTime DateCreated
        { get; set; }

    }
}
