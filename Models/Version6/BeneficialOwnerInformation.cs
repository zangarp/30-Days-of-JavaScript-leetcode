using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MessageModel.Models
{
    [XmlRoot(ElementName = "BeneficialOwnerInformation")]
    public class BeneficialOwnerInformation
    {
        [XmlElement(ElementName = "LastName")]
        public string? LastName { get; set; }

        [XmlElement(ElementName = "FirstName")]
        public string? FirstName { get; set; }

        [XmlElement(ElementName = "MiddleName")]
        public string? MiddleName { get; set; }

        [XmlElement(ElementName = "Citizenship")]
        public string? Citizenship { get; set; }

        [XmlElement(ElementName = "DateOfBirth")]
        public string? DateOfBirth { get; set; }

        [XmlElement(ElementName = "IdentityDocument")]
        public string? IdentityDocument { get; set; }

        [XmlElement(ElementName = "DocumentNumberAndSeries")]
        public string? DocumentNumberAndSeries { get; set; }
    }
}
