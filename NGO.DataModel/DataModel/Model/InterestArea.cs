using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using NGO.ViewModel;

namespace NGO.Models
{
    public class InterestArea
    {
        public InterestArea()
        {
            this.Organizations = new List<Organization>();
        }
        public int Id { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        //[Required]
        [StringLength(300)]
        public string Description { get; set; }

        public virtual ICollection<Organization> Organizations { get; set; }

        public virtual ICollection<VolunteerInterest> VolunteerInterests { get; set; }

    }
}