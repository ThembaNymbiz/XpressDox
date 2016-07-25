using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Escrow.Models
{
    public class Party
    {
        [Required, StringLength(20), Display(Name = "Role")]
        public string Party_Role { get; set; }

        [Required, StringLength(20), Display(Name = "Entity Type")]
        public string Party_Entity_Type { get; set; }

        [Required, StringLength(20), Display(Name = "Fullname")]
        public string Party_Fullname { get; set; }

        public string Party_Trading_Option { get; set; }

        [Required, StringLength(20), Display(Name = "Trading Name")]
        public string Party_Trading_Name { get; set; }

        public string Party_Division_Option { get; set; }

        [Required, StringLength(20), Display(Name = "Division Name")]
        public string Party_Division_Name { get; set; }

        [Required, StringLength(20), Display(Name = "Party registration number")]
        public string Party_Registration_Number { get; set; }


        [Required, StringLength(20), Display(Name = "Title")]
        public string Party_Title { get; set; }

        [Required, StringLength(20), Display(Name = "Party contact fullname")]
        public string Party_Contact_Fullname { get; set; }

        [Required, StringLength(20), Display(Name = "Email")]
        public string Party_Email { get; set; }

        [Required, StringLength(20), Display(Name = "Fax")]
        public string Party_Fax { get; set; }

        [Required, StringLength(20), Display(Name = "Telephone")]
        public string Party_Telephone { get; set; }

        [Required, StringLength(20), Display(Name = "Physical Address")]
        public string Party_Physical_Address { get; set; }

        public string Party_Physical_Same_A_Postal_Option { get; set; }

        [Required, StringLength(20), Display(Name = "Postal Address")]
        public string Party_Postal_Address { get; set; }
    }
}