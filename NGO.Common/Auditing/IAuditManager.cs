using NGO.Common.Auditing.Repository;

namespace Codm.Litebridge.Auditing
{
    /// <summary>
    /// Defines the interface of an AuditManager
    /// </summary>
    public interface IAuditManager
    {
        void WriteAudit(AuditInformation auditInformation);
    }
}