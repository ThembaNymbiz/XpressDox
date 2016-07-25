using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Escrow.Models
{
    public class Agreement
    {
        [Required, StringLength(80), Display(Name = "Agreement Type")]
        public string Agreement_Type { get; set; }

        [Required, StringLength(80), Display(Name = "Main agreement option")]
        public string Agreement_Main_Agreement_Option { get; set; }

        [Required, StringLength(200), Display(Name = "Main agreement name")]
        public string Agreement_Main_Agreement_Name { get; set; }

        [Required, StringLength(2), Display(Name = "Agreement effective date")]
        public string Agreement_Effective_Date_Option { get; set; }

        [Required, StringLength(2), Display(Name = "Agreement effective date")]
        public string Agreement_Effective_Date { get; set; }

        //Release events
        [Required, StringLength(80), Display(Name = "Ceases to trade release event")]
        public string Agreement_Release_Event_Ceases_To_Trade { get; set; }

        [Required, StringLength(80), Display(Name = "Transfer without agreeing release event")]
        public string Agreement_Release_Event_Transfer_Without_Agreeing { get; set; }

        [Required, StringLength(200), Display(Name = "Disposal of assets release event")]
        public string Agreement_Release_Event_Disposal_Assets { get; set; }

        [Required, StringLength(2), Display(Name = "Change in control release event")]
        public string Agreement_Release_Event_Change_Control { get; set; }

        [Required, StringLength(2), Display(Name = "Transfer to competitor release event")]
        public string Agreement_Release_Event_Transfer_To_Competitor { get; set; }

        [Required, StringLength(80), Display(Name = "Breach of escrow agreement release event")]
        public string Agreement_Release_Event_Breach_Escrow { get; set; }

        [Required, StringLength(80), Display(Name = "Business is under finacial distress release event")]
        public string Agreement_Release_Event_Financial_Distress { get; set; }

        [Required, StringLength(200), Display(Name = "Recieves a notice from the council release event")]
        public string Agreement_Release_Event_Recieve_Notice { get; set; }

        [Required, StringLength(2), Display(Name = "The owner is unable to provide maintenance release event")]
        public string Agreement_Release_Event_Owner_Maintenance { get; set; }

        [Required, StringLength(2), Display(Name = "Other release event option")]
        public string Agreement_Release_Other_Option { get; set; }

        [Required, StringLength(2), Display(Name = "Other release event")]
        public string Agreement_Release_Event_Other { get; set; }

    }
}