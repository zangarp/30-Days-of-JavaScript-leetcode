using System.Xml.Serialization;

namespace MessageModel.Models
{
    [XmlRoot(ElementName = "OrganisationDistrict")]
    public class OrganisationDistrict
    {
        [XmlAttribute(AttributeName = "Code")]
        public string? Code { get; set; }
    }
}
