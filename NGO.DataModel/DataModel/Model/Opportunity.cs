using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace NGO.Models
{
    public class Opportunity
    {
        public Opportunity()
        {
            this.Requirements = new List<Requirement>();
            this.Skills = new List<Skill>();
            this.GoodMatches = new List<GoodMatch>();
                
        }
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        //[Required]
        [StringLength(300)]
        public string Description { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }

        public virtual ICollection<Requirement> Requirements { get; set; }
        public virtual ICollection<Skill> Skills { get; set; }

        public virtual ICollection<GoodMatch> GoodMatches { get; set; }

        
        public int OrganizationId { get; set; }
        public virtual Organization Organization {get;set;}

        public virtual Address Address { get; set; }

        public int OpportunityTypeId { get; set; }
        public virtual OpportunityType OpportunityType { get; set; }
    
    }
}