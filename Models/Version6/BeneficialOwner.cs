using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MessageModel.Models
{
    [XmlRoot(ElementName = "BeneficialOwner")]
    public class BeneficialOwner
    {
        [XmlElement(ElementName = "BeneficialOwnerInformation")]
        public BeneficialOwnerInformation? BeneficialOwnerInformation { get; set; }

        [XmlElement(ElementName = "BeneficialOwnerResidency")]
        public string? BeneficialOwnerResidency { get; set; }

        [XmlElement(ElementName = "BeneficialOwnerID")]
        public string? BeneficialOwnerID { get; set; }
    }
}
