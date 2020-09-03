using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using NGO.Models;
using NGO.ViewModel;

namespace NGO.DataAccess
{
    public class NGOContext : DbContext
    {
        public NGOContext()
            : base("NGOStageDBConnectionString")
        {
            Database.SetInitializer<NGOContext>(new NGODBInitializer());
                            
        }

        public DbSet<InterestArea> InterestAreas { get; set; }
        public DbSet<Opportunity> Opportunities { get; set; }

        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Requirement> Requirements { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<GoodMatch> GoodMatches { get; set; }

        public DbSet<Address> Addresses{get;set;}
        public DbSet<OpportunityType> OpportunityTypes {get;set;}

        public DbSet<OpportunitySignup> OpportunitySignups { get; set; }

        public DbSet<OpportunityOwnerDetail> OpportunityOwnerDetails { get; set; }

        public DbSet<OrganizationOwnerDetail> OrganizationOwnerDetails { get; set; }

        public DbSet<VolunteerInterest> VolunteerInterest { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }

    public class NGODBConfig : DbConfiguration
    {
        public NGODBConfig()
        {
            this.SetDatabaseInitializer<NGOContext>(new NGODBInitializer());
        }
    }
}