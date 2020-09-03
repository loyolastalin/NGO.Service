using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NGO.Models;
using System.ComponentModel.DataAnnotations;

namespace NGO.ViewModel
{
    public class OpportunitySignup
    {
        public OpportunitySignup()
        {
            
        }

        public int Id { get; set; }
        [Required]
        
        public string EmailID { get; set; }

        [Required]
        public virtual int? OpportunityID { get; set; }
    }
}