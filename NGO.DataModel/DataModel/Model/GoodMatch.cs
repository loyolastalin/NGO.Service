﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace NGO.Models
{
    public class GoodMatch
    {
        public GoodMatch()
        {
                
        }
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