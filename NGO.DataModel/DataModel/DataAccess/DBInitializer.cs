using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using NGO.Models;


namespace NGO.DataAccess
{
    public class NGODBInitializer : System.Data.Entity.DropCreateDatabaseAlways<NGOContext>
    {
        protected override void Seed(NGOContext context)
        {

            var skills = new List<Skill>{
           
               new Skill(){Title="Computer Programming"},
               new Skill(){Title="Sewing"},
               new Skill(){Title="Sowing"},
               new Skill(){Title="Crafting"},
               new Skill(){Title="Carpenting"},
               new Skill(){Title="Drilling"}
           };

            skills.ForEach(s => context.Skills.Add(s));
            context.SaveChanges();

            var GoodMatches = new List<GoodMatch>{
               new GoodMatch(){Title="Children"},
               new GoodMatch(){Title="Girls"},
               new GoodMatch(){Title="Young"},
               new GoodMatch(){Title="Adults"},
               new GoodMatch(){Title="55+"}

           };

            GoodMatches.ForEach(g => context.GoodMatches.Add(g));
            context.SaveChanges();

            var InterestAreas = new List<InterestArea>(){
               new InterestArea(){Title="Education"},
               new InterestArea(){Title="Disabled"},
               new InterestArea(){Title="Seniors"},
               new InterestArea(){Title="Health"},
               new InterestArea(){Title="Medicine"},
               new InterestArea(){Title="Community"}
           };


            InterestAreas.ForEach(i => context.InterestAreas.Add(i));
            context.SaveChanges();

            var Reviews = new List<Review>(){
               new Review(){Title="Review1"},
               new Review(){Title="Review2"},
               
               new Review(){Title="Review3"},
               
               new Review(){Title="Review4"},
               new Review(){Title="Review5"}
           };

            Reviews.ForEach(x => context.Reviews.Add(x));
            context.SaveChanges();

            //Requirements

            for (int i = 1; i < 11; i++)
            {
                context.Requirements.Add(new Requirement()
                {

                    Title = "Requirement " + i,
                    Description = "Requirement Description " + i
                });

            }

            context.SaveChanges();
           

            var Addresses = new List<Address>()
            {
                new Address(){City="Seattle",AddressLine1="8835 166th AVE NE",State="WA",ZipCode="98052",Country="USA"},
                //new Address(){City="Bellevue"},
                //new Address(){City="Bothell"},
                //new Address(){City="Seattle"},
                //new Address(){City="Redmond"},
                //new Address(){City="Redmond"},

            };

            Addresses.ForEach(a => context.Addresses.Add(a));

            var OpportunityTypes = new List<OpportunityType>()
            {
                new OpportunityType(){Title="Local", Description="You would need to visit the place"},
                new OpportunityType(){Title="Virtual",Description="This work can be done remotely"}

            };
            OpportunityTypes.ForEach(o => context.OpportunityTypes.Add(o));

            //organization

            var Organizations = new List<Organization>(){

                new Organization{ Address= context.Addresses.Take(1).SingleOrDefault(), 
                    InterestAreas=context.InterestAreas.Take(3).ToList<InterestArea>(),Name="Singh Charity",Website="http://www.singhcharity.com",Description="Description1",MissionStatement="My mission statement"},
                new Organization{
                    Address= context.Addresses.Take(1).SingleOrDefault(),
                    InterestAreas=context.InterestAreas.Take(3).ToList<InterestArea>(),Name="Gupta Charity",Website="http://www.gupta.com",Description="Description1",MissionStatement="My mission statement"},
                new Organization{
                    
                    Address= context.Addresses.Take(1).SingleOrDefault(),
                    InterestAreas=context.InterestAreas.Take(3).ToList<InterestArea>(),Name="Srivastava Charity",Website="http://www.srivastava.com",Description="Description1",MissionStatement="My mission statement"},
                new Organization{
                     Address= context.Addresses.Take(1).SingleOrDefault(),
                         InterestAreas=context.InterestAreas.Take(3).ToList<InterestArea>(),Name="Bhagat Singh Charity",Website="http://www.bharat.com",Description="Description1",MissionStatement="My mission statement"},
                new Organization{
                    Address= context.Addresses.Take(1).SingleOrDefault(),
                    InterestAreas=context.InterestAreas.Take(3).ToList<InterestArea>(),Name="Gandhi Charity",Website="http://www.gandhi.com",Description="Description1",MissionStatement="My mission statement"},
                new Organization{
                    Address= context.Addresses.Take(1).SingleOrDefault(),
                    InterestAreas=context.InterestAreas.Take(3).ToList<InterestArea>(),Name="Mishra Charity",Website="http://www.mishra.com",Description="Description1",MissionStatement="My mission statement"}

            };

            Organizations.ForEach(x => context.Organizations.Add(x));
            context.SaveChanges();

            //opportunity

            for (int i = 1; i < 11; i++)
            {
                context.Opportunities.Add(new Opportunity()
                {
                    Title = "Opportunity " + i.ToString(),
                    Description = "Description details " + i.ToString(),
                    GoodMatches = context.GoodMatches.Take(3).ToList<GoodMatch>(),
                    Organization = context.Organizations.Where(x => x.Id == i % context.Organizations.Count() +1).SingleOrDefault(),
                    Requirements = context.Requirements.Take(3).ToList<Requirement>(),
                    Skills = context.Skills.Take(4).ToList<Skill>(),
                    Address = context.Addresses.Take(1).SingleOrDefault(),
                    OpportunityType = context.OpportunityTypes.Take(1).SingleOrDefault(),
                    EndDate = new DateTime(2013,11,15),
                    StartDate = new DateTime(2013,12,15)

                });
            }

            context.SaveChanges();


            //Add InterestAreas to each Organization

            
            base.Seed(context);

            
        }

      
    }
}
