using System.Xml.Serialization;

namespace MessageModel.Models
{
    [XmlRoot(ElementName = "CorrespondentBank")]
    public class CorrespondentBank
    {
        [XmlElement(ElementName = "AccountNumber")]
        public string? AccountNumber { get; set; }

        [XmlElement(ElementName = "Name")]
        public string? Name { get; set; }

        [XmlElement(ElementName = "Code")]
        public string? Code { get; set; }

        [XmlElement(ElementName = "BankCity")]
        public string? BankCity { get; set; }

        [XmlElement(ElementName = "BankCountry")]
        public string? BankCountry { get; set; }

        [XmlElement(ElementName = "BankOffshoreAddr")]
        public string? BankOffshoreAddr { get; set; }

        [XmlElement(ElementName = "CorrespondentsInformations")]
        public CorrespondentsInformations? CorrespondentsInformations { get; set; }

        [XmlAttribute]
        public bool IsOffshore { get; set; }
    }
}
