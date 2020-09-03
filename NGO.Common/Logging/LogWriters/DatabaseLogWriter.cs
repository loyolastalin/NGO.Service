using AutoMapper;
using NGO.EntityFramework;

namespace NGO.Common.Logging.LogWriters
{
    /// <summary>
    /// Represents for creating a database log writer.
    /// </summary>
    public sealed class DatabaseLogWriter : ILogWriter
    {
        public DatabaseLogWriter()
        {
            Mapper.CreateMap<LogInformation, Log>();
        }

        public void WriteLog(LogInformation logInformation)
        {
            var log = Mapper.Map<LogInformation, Log>(logInformation);
          
            using (NGODBEntities entities = new NGODBEntities())
            {
                entities.Logs.Add(log);
                entities.SaveChanges();
            }
        }
    }
}
