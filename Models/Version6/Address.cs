using System.Xml.Serialization;

namespace MessageModel.Models
{
    [XmlRoot(ElementName = "URAddress")]
    public class Address
    {
        [XmlElement(ElementName = "Country")]
        public string? Country { get; set; }

        [XmlElement(ElementName = "Area")]
        public Area? Area { get; set; }

        [XmlElement(ElementName = "District")]
        public District? District { get; set; }

        [XmlElement(ElementName = "Town")]
        public Town? Town { get; set; }

        [XmlElement(ElementName = "Street")]
        public string? Street { get; set; }

        [XmlElement(ElementName = "HomeNumber")]
        public string? HomeNumber { get; set; }

        [XmlElement(ElementName = "OfficeNumber")]
        public string? OfficeNumber { get; set; }

        [XmlElement(ElementName = "PostalCode")]
        public string? PostalCode { get; set; }
    }
}
