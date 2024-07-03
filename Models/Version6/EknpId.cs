using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MessageModel.Models
{
    [XmlRoot(ElementName = "EknpId")]
    public class EknpId
    {
        [XmlAttribute(AttributeName = "IsEknpNotSetup")]
        public bool IsEknpNotSetup { get; set; }

        [XmlText]
        public string? Text { get; set; }
    }
}
