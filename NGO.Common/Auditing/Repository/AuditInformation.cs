using NGO.Common.Core.Extensions;

namespace NGO.Common.Auditing.Repository
{
    /// <summary>
    /// Represents the information of an Audit
    /// </summary>
    public class AuditInformation
    {
        public string SourceId { get; set; }

        public string SourceType { get; set; }

        public string AuditType { get; set; }

        public AuditMessage AuditMessage { get; set; }

        public string ParticipantId { get; set; }

        public string ParticipantType { get; set; }

        public override string ToString()
        {
            return "AuditInformation (SourceId: {0}, SourceType: {1}, AuditType: {2}, ParticipantType: {3}, ParticipantId: {4})"
                    .FormatInvariant(SourceId, SourceType, AuditType, ParticipantType, ParticipantId);
        }
    }
}
