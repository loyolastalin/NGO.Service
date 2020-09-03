using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace NGO.Service.IntegrationTestHarness.Model
{  
    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://schemas.datacontract.org/2004/07/NEO.App.Domain.ModelView")]
    [XmlRoot(Namespace = "http://schemas.datacontract.org/2004/07/NEO.App.Domain.ModelView", IsNullable = false)]
    public partial class ArrayOfEvent
    {
        [XmlElement("Event")]
        public List<Event> Items
        {
            get;
            set;
        }
    }
}
