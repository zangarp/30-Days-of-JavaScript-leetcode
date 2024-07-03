using System.Xml.Serialization;

namespace MessageModel.Models
{
    [XmlRoot(ElementName = "Area")]
    public class Area
    {
        [XmlAttribute(AttributeName = "Code")]
        public string? Code { get; set; }
    }

    [XmlRoot(ElementName = "District")]
    public class District
    {
        [XmlAttribute(AttributeName = "Code")]
        public string? Code { get; set; }
    }

    [XmlRoot(ElementName = "Town")]
    public class Town
    {
        [XmlAttribute(AttributeName = "Code")]
        public string? Code { get; set; }
    }
}