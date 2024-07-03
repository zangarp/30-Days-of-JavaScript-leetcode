using System.Xml.Serialization;

namespace MessageModel.Models
{
    [XmlRoot(ElementName = "TransactionAddress")]
    public class TransactionAddress
    {
        [XmlElement(ElementName = "Region")]
        public string? Region { get; set; }

        [XmlElement(ElementName = "District")]
        public string? District { get; set; }

        [XmlElement(ElementName = "City")]
        public string? City { get; set; }

        [XmlElement(ElementName = "Street")]
        public string? Street { get; set; }

        [XmlElement(ElementName = "HouseNumber")]
        public string? HouseNumber { get; set; }
    }
}
