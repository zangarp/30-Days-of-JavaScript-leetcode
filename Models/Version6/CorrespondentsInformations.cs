using System.Xml.Serialization;

namespace MessageModel.Models
{
    [XmlRoot(ElementName = "CorrespondentsInformations")]
    public class CorrespondentsInformations
    {
        [XmlElement(ElementName = "CorrespondentsInformation")]
        public List<CorrespondentsInformation>? CorrespondentsInformation;
    }
}
