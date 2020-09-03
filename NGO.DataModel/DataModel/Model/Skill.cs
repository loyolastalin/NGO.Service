using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace NGO.Models
{
    public class Skill
    {
        public Skill()
        {
                
        }
        public int Id { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        //[Required]
        [StringLength(350)]
        public string Description { get; set; }

        public string SkillDummy { get; set; }

        public virtual ICollection<Opportunity> Opportunities {get;set;}

        

    }
}