using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NGO.Models
{
    public class OpportunityType
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        //[Required]
        [StringLength(300)]
        public string Description { get; set; }


        public virtual ICollection<Opportunity> Opportunities { get; set; }
    }
}