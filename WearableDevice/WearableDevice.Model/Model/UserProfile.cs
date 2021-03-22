using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace WearableDevice.Model.Model
{
   public class UserProfile
    {
       

       
        [Key]
        [Required(ErrorMessage = "Email is Required")]
     


        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        [MinLength(8, ErrorMessage = "Need min 8 character")]
        public string Password { get; set; }


        [Required(ErrorMessage = "Activation Code is Required")]
        public int ActivationCode
        { get; set; }
    }
}
