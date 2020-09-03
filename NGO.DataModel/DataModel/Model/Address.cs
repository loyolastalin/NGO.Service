using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NGO.Models
{
    public class Address
    {
        public int Id { get; set; }

        [Required]
        [StringLength(75)]
        [Display(Name = "Address Line1")]
        public string AddressLine1 { get; set; }

        [Display(Name = "Address Line2")]
        public string AddressLine2 { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Display(Name = "Pin code")]
        // [RegularExpression("^([0-9]{6})$")]
        public string ZipCode { get; set; }

        public string Country
        {
            get
            {
                return "India";
            }
            set
            {
                value = this.Country;
            }

        }

        public string Latitude { get; set; }
        public string Longitude { get; set; }

        [NotMapped]
        public string FullAddress
        {
            get {return this.AddressLine1 + " " + this.AddressLine2 + "," + this.City +","+this.State+","+this.Country;}
        }

    }
}