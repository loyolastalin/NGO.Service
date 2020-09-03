using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using NGO.Common.Core;

namespace NGO.Common.Auditing.Repository
{
    /// <summary>
    /// Represents an XML fragment containing information about the activity being audited. 
    /// </summary>
    public class AuditMessage : SerializableData, IXmlSerializable
    {
        public SerializableData Payload { get; set; }

        public string OperationName { get; set; }

        public string AssemblyVersion { get; set; }

        public string NetworkAccessPoint { get; set; }

        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
        }

        public void WriteXml(XmlWriter writer)
        {
            Guard.ArgumentNotNull(writer, "writer");
            WritePayloadSection(writer);
            WriteAdditionalInfoSection(writer);
        }

        private void WritePayloadSection(XmlWriter writer)
        {
            Guard.ArgumentNotNull(writer, "writer");
            writer.WriteStartElement("Payload");

            if (Payload != null)
            {
                writer.WriteRaw(Payload.ToXmlString());
            }

            writer.WriteEndElement();
        }

        private void WriteAdditionalInfoSection(XmlWriter writer)
        {
            Guard.ArgumentNotNull(writer, "writer");
            writer.WriteStartElement("AdditionalInfo");
            writer.WriteStartElement("AuditSource");
            writer.WriteAttributeString("OperationName", OperationName);
            writer.WriteAttributeString("AssemblyVersion", AssemblyVersion);
            writer.WriteEndElement();
            writer.WriteElementString("NetworkAddress", NetworkAccessPoint);
            writer.WriteEndElement();
        }
    }
}
