using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WearableDevice.Model.Model
{
    public class Acceleration
    {

        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity), Key()]
        public int id { get; set; }


        [Required(ErrorMessage = "Milliseconds is Required")]                  
        public int Milliseconds { get; set; }

        [Required(ErrorMessage = "X-dimension acceleration is Required")]
        public Int32 X { get; set; }

        [Required(ErrorMessage = "Y-dimension acceleration is Required")]
        public Int32 Y { get; set; }

        [Required(ErrorMessage = "Z-dimension acceleration is Required")]
        public Int32 Z { get; set; }

    }
}
