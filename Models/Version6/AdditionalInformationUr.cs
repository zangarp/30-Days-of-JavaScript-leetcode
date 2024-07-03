using System.Xml.Serialization;

namespace MessageModel.Models
{
    [XmlRoot(ElementName = "AdditionalInformationUr")]
    public class AdditionalInformationUr
    {
        [XmlElement(ElementName = "URAddress")]
        public Address? UrAddress { get; set; }

        [XmlElement(ElementName = "ParticipantOPF")]
        public string? ParticipantOPF { get; set; }

        [XmlElement(ElementName = "FullName")]
        public FullName? FullName { get; set; }

        [XmlElement(ElementName = "FirstHead")]
        public FirstHead? FirstHead { get; set; }

        [XmlElement(ElementName = "ACAddress")]
        public Address? AcAddress { get; set; }
    }
}
