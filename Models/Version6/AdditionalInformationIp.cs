using System.Net;
using System.Xml.Serialization;

namespace MessageModel.Models
{
    [XmlRoot("AdditionalInformationIp")]
    public class AdditionalInformationIp
    {
        [XmlElement(ElementName = "URAddress")]
        public Address? UrAddress { get; set; }

        [XmlElement(ElementName = "ACAddress")]
        public Address? AcAddress { get; set; }

        [XmlElement(ElementName = "FIO")]
        public FIO? FIO { get; set; }

        [XmlElement(ElementName = "DocumentIdentity")]
        public string? DocumentIdentity { get; set; }

        [XmlElement(ElementName = "NumberDocIdentity")]
        public string? NumberDocIdentity { get; set; }

        [XmlElement(ElementName = "SeriesDocIdentity")]
        public string? SeriesDocIdentity { get; set; }

        [XmlElement(ElementName = "DocumentIssued")]
        public string? DocumentIssued { get; set; }

        [XmlElement(ElementName = "DateIssuance")]
        public string? DateIssuance { get; set; }

        [XmlElement(ElementName = "DateBirth")]
        public string? DateBirth { get; set; }

        [XmlElement(ElementName = "PlaceBirth")]
        public string? PlaceBirth { get; set; }
    }
}
