using System.Xml.Serialization;

namespace MessageModel.Models
{
    [XmlRoot(ElementName = "OrganisationArea")]
    public class OrganisationArea
    {
        [XmlAttribute(AttributeName = "Code")]
        public string? Code { get; set; }
    }
}