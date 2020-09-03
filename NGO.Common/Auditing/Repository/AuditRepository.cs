using NGO.Common.Core;
using NGO.Common.Core.Extensions;
using NGO.Common.Logging;

namespace NGO.Common.Auditing.Repository
{
    /// <summary>
    /// Provides functionality to add audit entries to the repository.
    /// </summary>
    internal class AuditRepository : IAuditRepository
    {
        public AuditRepository()
        {
        }

        public void WriteAudit(AuditInformation auditInformation)
        {
            Guard.ArgumentNotNull(auditInformation, "auditInformation");

            Logger.Current.LogVerbose("Writing audit: {0}".FormatInvariant(auditInformation));
        }
    }
}
