using System.Xml.Serialization;

namespace MessageModel.Models
{
    [XmlRoot(ElementName = "Reference")]
    public class Reference
    {
        [XmlElement(ElementName = "ReferenceId")]
        public string? ReferenceId { get; set; }

        [XmlElement(ElementName = "ReferenceOperationNumber")]
        public string? ReferenceOperationNumber { get; set; }

        [XmlElement(ElementName = "ReferenceDocOperationDate")]
        public string? ReferenceDocOperationDate { get; set; }

        [XmlElement(ElementName = "ReferenceDocOperationNumber")]
        public string? ReferenceDocOperationNumber { get; set; }
    }
}