using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NGO.ViewModel
{
    public class OrganizationOwnerDetail
    {
        public OrganizationOwnerDetail()
        {

        }

        public int Id { get; set; }
        public string EmailId { get; set; }
        [Required]
        public virtual int? OrganizationId { get; set; }
    }
}