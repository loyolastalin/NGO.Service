using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NGO.DataAccess;
using NGO.Models;
using System.Data;


namespace DataPopulator
{
    class Program
    {
        static void Main(string[] args)
        {
           
                var dbContext = new NGOContext();
                var skills = new List<Skill>{
           
               new Skill(){Title="Drilling",SkillDummy="dummy"}
           };

             try
            {
                skills.ForEach(s => dbContext.Skills.Add(s));
                dbContext.SaveChanges();
            }
            catch(DataException ex)
             {
                 string msg = ex.InnerException.ToString();

                 Console.WriteLine( msg);

             }

        }
    }
}
