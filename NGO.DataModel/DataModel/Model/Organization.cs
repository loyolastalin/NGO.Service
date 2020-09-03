using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace NGO.Models
{

    //public class BasicFields
    //{
    //  internal   DateTime? CreateDate { get; set; }
    //  internal DateTime? ModifiedDate { get; set; }

    //  internal string CreatedBy { get; set; }
    //  internal string ModifiedBy { get; set; }

    //}

    public class Organization 
    {
        public Organization()
        {
            this.InterestAreas = new List<InterestArea>();
            this.Opportunities = new List<Opportunity>();
        }
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        // [Required]
        [StringLength(300)]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        //[Required]
        [StringLength(300)]
        [Display(Name = "Mission Statement")]
        public string MissionStatement { get; set; }

        [Url]
        [Display(Name = "Website URL")]
        public string Website { get; set; }

        [Display(Name = "Website Logo")]
        [DataType(DataType.ImageUrl)]
        public byte[] WebsiteImage { get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        [StringLength(60)]
        [Display(Name = "Contact Name")]
        // [Required]
        public string ContactName { get; set; }

        [Phone]
        [Display(Name = "Contact Number")]
        public string ContactNumber { get; set; }
        public virtual ICollection<InterestArea> InterestAreas { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<Opportunity> Opportunities { get; set; }
        public virtual Address Address { get; set; }
    }
}