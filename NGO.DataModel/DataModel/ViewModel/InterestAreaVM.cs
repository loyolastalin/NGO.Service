using NGO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NGO.ViewModel
{
    public class InterestAreaVM
    {
       public IList<InterestArea> AvailableInterestAreas { get; set; }
       public IList<InterestArea> SelectedInterestAreas { get; set; }

       public PostedInterestAreas PostedInterestAreas { get; set; }
    }

    public class PostedInterestAreas
    {
       public string[] InterestAreaIds { get; set; }
    }
}