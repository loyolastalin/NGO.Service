using System;
using System.Xml.Serialization;

namespace NGO.Service.IntegrationTestHarness.Model
{
    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://schemas.datacontract.org/2004/07/NEO.App.Domain.ModelView")]
    public partial class Event
    {
        public string Name
        {
            get;
            set;
        }
    }
}