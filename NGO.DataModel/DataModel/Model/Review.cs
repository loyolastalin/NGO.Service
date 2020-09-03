using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;


namespace NGO.Models
{
   public class Review
    {
       public Review()
       {
            
       }
       public int Id {get;set;}
       
       [Required]
       [StringLength(50)]
       public string Title { get; set; }
       
       //[Required]
       [StringLength(300)]
       public string Description { get; set; }
       
       [Range(0,5)] 
       public int Rating { get; set; }

        
    }
}
