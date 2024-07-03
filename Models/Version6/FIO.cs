using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MessageModel.Models
{
    [XmlRoot(ElementName = "FIO")]
    public class FIO
    {
        [XmlElement(ElementName = "FirstName")]
        public string? FirstName { get; set; }

        [XmlElement(ElementName = "SecondName")]
        public string? SecondName { get; set; }

        [XmlElement(ElementName = "MiddleName")]
        public string? MiddleName { get; set; }

        [XmlAttribute(AttributeName = "IsFioNotSetup")]
        public bool IsFioNotSetup { get; set; }

        [XmlText]
        public string? Text { get; set; }
    }
}
