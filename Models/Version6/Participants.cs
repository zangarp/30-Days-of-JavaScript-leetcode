using System.Xml.Serialization;

namespace MessageModel.Models
{
    [XmlRoot(ElementName = "Participants")]
    public class Participants
    {
        [XmlElement(ElementName = "Participant")]
        public List<Participant>? Participant { get; set; }
    }
}
