using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Escrow.Models
{
    public class Software
    {
        [Required, StringLength(80), Display(Name = "Software Name")]
        public string Software_Name { get; set; }

        [Required, StringLength(80), Display(Name = "Software Version")]
        public string Software_Version { get; set; }

        [Required, StringLength(200), Display(Name = "Software Description")]
        public string Software_Description { get; set; }

        [Required, StringLength(2), Display(Name = "Software Owner Payment Percentage")]
        public string Software_Owner_Payment_Percentage { get; set; }

        [Required, StringLength(2), Display(Name = "Software Beneficiary Payment Percentage")]
        public string Software_Beneficiary_Payment_Percentage { get; set; }

    }
}