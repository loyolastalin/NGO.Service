using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NGO.Models;

namespace NGO.ViewModel
{
    public class RegisterOrganization
    {
        Organization Organization { get; set; }
        ApplicationUser User { get; set; }

        public RegisterOrganization()
        {

        }
    }
}