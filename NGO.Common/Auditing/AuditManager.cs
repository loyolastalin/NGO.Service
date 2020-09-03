using System;
using Codm.Litebridge.Auditing;
using NGO.Common.Auditing.Repository;
using NGO.Common.Core;
using NGO.Common.Core.Extensions;
using NGO.Common.Logging;

namespace NGO.Common.Auditing
{
    /// <summary>
    /// Entry point to the Auditing system which provides functionality to write audit information
    /// </summary>
    public class AuditManager : IAuditManager
    {  
        private static IAuditManager _instance = new AuditManager();
        private IAuditRepository _auditDataAccess = new AuditRepository();

        internal AuditManager(IAuditRepository auditDataAccess)
        {
            _auditDataAccess = auditDataAccess;
        }

        private AuditManager()
        {
        }

        public static IAuditManager Current
        {
            get { return _instance; } 
        }

        public void WriteAudit(AuditInformation auditInformation)
        {
            Guard.ArgumentNotNull(auditInformation, "auditInformation");
            if (auditInformation.AuditMessage == null)
            {
                throw new ArgumentException("auditInformation.AuditMessage cannot be null", "auditInformation");
            }

            Logger.Current.LogVerbose("Received {0}".FormatInvariant(auditInformation));

            _auditDataAccess.WriteAudit(auditInformation);
        }
    }
}
