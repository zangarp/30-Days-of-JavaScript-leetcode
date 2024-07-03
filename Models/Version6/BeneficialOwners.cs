using System.Xml.Serialization;

namespace MessageModel.Models
{
    [XmlRoot(ElementName = "BeneficialOwners")]
    public class BeneficialOwners
    {
        [XmlElement(ElementName = "BeneficialOwner")]
        public List<BeneficialOwner>? BeneficialOwner { get; set; }
    }
}
