using System.Xml.Serialization;

namespace MessageModel.Models
{
    [XmlRoot(ElementName = "Founders")]
    public class Founders
    {
        [XmlElement(ElementName = "Founder")]
        public List<Founder>? Founder { get; set; }
    }
}
