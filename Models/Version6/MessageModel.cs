using System.Xml.Serialization;
using MessageModel.Models;

namespace MessageModel
{
    [XmlRoot(ElementName = "Root")]
    public class MessageModel
    {
        [XmlElement(ElementName = "PersonalData")]
        public PersonalData? PersonalData { get; set; }

        [XmlElement(ElementName = "MessageInformation")]
        public MessageInformation? MessageInformation { get; set; }

        [XmlElement(ElementName = "References")]
        public References? References { get; set; }

        [XmlElement(ElementName = "Participants")]
        public Participants? Participants { get; set; }

        [XmlElement(ElementName = "Version")]
        public string? Version { get; set; }

        [XmlElement(ElementName = "DocumentUniqueIdentifier")]
        public string? DocumentUniqueIdentifier { get; set; }
    }
}
