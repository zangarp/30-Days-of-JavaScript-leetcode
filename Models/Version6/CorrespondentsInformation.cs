using System.Xml.Serialization;

namespace MessageModel.Models
{
    [XmlRoot(ElementName = "CorrespondentsInformation")]
    public class CorrespondentsInformation
    {
        [XmlElement(ElementName = "BankName")]
        public string? BankName { get; set; }

        [XmlElement(ElementName = "BankCountry")]
        public string? BankCountry { get; set; }
    }
}
