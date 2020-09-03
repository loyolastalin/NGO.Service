using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace NGO.Common.Core
{
    /// <summary>
    /// Represents the base class for serializing an object to a Xml string
    /// </summary>
   public abstract class SerializableData
    {
        public string ToXmlString()
        {
            return TrySerialize(this);
        }

        private static string TrySerialize(object mc)
        {
            XmlSerializer xs = new XmlSerializer(mc.GetType());
            var builder = new StringBuilder();

            using (var writer = XmlWriter.Create(builder, new XmlWriterSettings() { OmitXmlDeclaration = true, Indent = false }))
            {
                var ns = new XmlSerializerNamespaces();
                ns.Add(string.Empty, string.Empty);
                xs.Serialize(writer, mc, ns);
                writer.Flush();
                return builder.ToString();
            }
        }
    }
}
