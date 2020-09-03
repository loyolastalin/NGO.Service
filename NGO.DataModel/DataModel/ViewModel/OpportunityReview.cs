using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NGO.ViewModel
{
    public class OpportunityReview
    {

        public int Id { get; set; }
        public int ReviewId { get; set; }
        [Required]
        public virtual int? OpportunityId { get; set; }
    }
}