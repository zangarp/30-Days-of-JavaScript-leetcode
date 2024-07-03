using System.Xml.Serialization;

namespace MessageModel.Models
{
    [XmlRoot(ElementName = "References")]
    public class References
    {
        [XmlElement(ElementName = "Reference")]
        public List<Reference>? Reference { get; set; }
    }
}
