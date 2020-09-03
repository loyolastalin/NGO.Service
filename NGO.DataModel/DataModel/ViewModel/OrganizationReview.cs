using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NGO.ViewModel
{
    public class OrganizationReview
    {

        public int Id { get; set; }
        public int ReviewId { get; set; }
        [Required]
        public virtual int? OrganizationId { get; set; }
    }
}