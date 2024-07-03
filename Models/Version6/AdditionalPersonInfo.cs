using System.Xml.Serialization;

namespace MessageModel.Models
{
    [XmlRoot(ElementName = "AdditionalPersonInfo")]
    public class AdditionalPersonInfo
    {
        [XmlElement(ElementName = "AdditionalInformationAc")]
        public AdditionalInformationAc? AdditionalInformationAc { get; set; }
        public AdditionalInformationUr? AdditionalInformationUr { get; set; }
        public AdditionalInformationIp? AdditionalInformationIp { get; set; }
    }
}
