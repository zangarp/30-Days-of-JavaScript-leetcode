using System.Xml.Serialization;

namespace MessageModel.Models
{
    [XmlRoot(ElementName = "OrganisationCity")]
    public class OrganisationCity
    {
        [XmlAttribute(AttributeName = "Code")]
        public string? Code { get; set; }
    }
}
