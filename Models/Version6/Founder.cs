using System.Xml.Serialization;

namespace MessageModel.Models
{
    [XmlRoot(ElementName = "Participant")]
    public class Founder
    {
        [XmlElement(ElementName = "SecondName")]
        public string? SecondName { get; set; }

        [XmlElement(ElementName = "Residence")]
        public string? Residence { get; set; }

        [XmlElement(ElementName = "Name")]
        public string? Name { get; set; }

        [XmlElement(ElementName = "MiddleName")]
        public string? MiddleName { get; set; }

        [XmlElement(ElementName = "FirstName")]
        public string? FirstName { get; set; }

        [XmlElement(ElementName = "FounderType")]
        public string? FounderType { get; set; }

        [XmlElement(ElementName = "FounderOPF")]
        public string? FounderOPF { get; set; }
    }
}