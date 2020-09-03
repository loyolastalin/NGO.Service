using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGO.EntityFramework.IntegrationTest
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            NGODBEntities entities = new NGODBEntities();
            var entityItems = entities.Events.ToList();

            System.Console.WriteLine("Envent count " + entityItems.Count.ToString());
            Console.ReadLine();
        }
    }
}
