using System.Xml.Serialization;

namespace MessageModel.Models
{
    [XmlRoot(ElementName = "AdditionalAcData")]
    public class AdditionalAcData
    {
        [XmlElement(ElementName = "FirstName")]
        public string? FirstName { get; set; }

        [XmlElement(ElementName = "LastName")]
        public string? LastName { get; set; }

        [XmlElement(ElementName = "MiddleName")]
        public string? MiddleName { get; set; }

        [XmlElement(ElementName = "DocumentIdentity")]
        public string? DocumentIdentity { get; set; }

        [XmlElement(ElementName = "SeriesDocIdentity")]
        public string? SeriesDocIdentity { get; set; }

        [XmlElement(ElementName = "NumberDocIdentity")]
        public string? NumberDocIdentity { get; set; }

        [XmlElement(ElementName = "DocumentIssued")]
        public string? DocumentIssued { get; set; }

        [XmlElement(ElementName = "DateIssuance")]
        public string? DateIssuance { get; set; }

        [XmlAttribute(AttributeName = "IsAc")]
        public bool IsAc { get; set; }
    }
}
