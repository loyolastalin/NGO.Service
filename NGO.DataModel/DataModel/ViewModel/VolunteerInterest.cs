using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NGO.Models;

namespace NGO.ViewModel
{
    public class VolunteerInterest
    {
        public int Id { get; set; }
        public string UserName { get; set; }

        public virtual ICollection<InterestArea> InterestArea { get; set; }
    }
}