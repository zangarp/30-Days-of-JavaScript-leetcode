using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MessageModel.Models
{
    [XmlRoot("FullName")]
    public class FullName
    {
        [XmlAttribute]
        public bool IsFullNameSetup { get; set; }

        [XmlText]
        public string? Text { get; set; }
    }
}
