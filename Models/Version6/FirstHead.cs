using System.Xml.Serialization;

namespace MessageModel.Models
{
    [XmlRoot(ElementName = "FirstHead")]
    public class FirstHead
    {
        [XmlElement(ElementName = "SecondName")]
        public string? SecondName { get; set; }

        [XmlElement(ElementName = "MiddleName")]
        public string? MiddleName { get; set; }

        [XmlElement(ElementName = "FirstName")]
        public string? FirstName { get; set; }
    }
}
