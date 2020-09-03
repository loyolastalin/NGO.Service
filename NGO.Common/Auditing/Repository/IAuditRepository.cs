namespace NGO.Common.Auditing.Repository
{
    /// <summary>
    /// Interface for AuditDataAccess class to write audit entries to the repository.
    /// </summary>
    internal interface IAuditRepository
    {
        void WriteAudit(AuditInformation auditInformation);
    }
}