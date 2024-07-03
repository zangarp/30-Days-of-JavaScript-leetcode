using System.Xml.Serialization;

namespace MessageModel.Models
{
    [XmlRoot(ElementName = "PersonalData")]
    public class PersonalData
    {
        [XmlElement(ElementName = "FirstName")]
        public string? FirstName { get; set; }

        [XmlElement(ElementName = "SecondName")]
        public string? SecondName { get; set; }

        [XmlElement(ElementName = "MiddleName")]
        public string? MiddleName { get; set; }

        [XmlElement(ElementName = "JobName")]
        public string? JobName { get; set; }

        [XmlElement(ElementName = "Phone")]
        public string? Phone { get; set; }

        [XmlElement(ElementName = "Email")]
        public string? Email { get; set; }

        [XmlElement(ElementName = "OrganisationCode")]
        public string? OrganisationCode { get; set; }

        [XmlElement(ElementName = "Organisation")]
        public string? Organisation { get; set; }

        [XmlElement(ElementName = "OrganisationOPF")]
        public string? OrganisationOPF { get; set; }

        [XmlElement(ElementName = "OrganisationArea")]
        public OrganisationArea? OrganisationArea { get; set; }

        [XmlElement(ElementName = "OrganisationDistrict")]
        public OrganisationDistrict? OrganisationDistrict { get; set; }

        [XmlElement(ElementName = "OrganisationCity")]
        public OrganisationCity? OrganisationCity { get; set; }

        [XmlElement(ElementName = "OrganisationStreet")]
        public string? OrganisationStreet { get; set; }

        [XmlElement(ElementName = "OrganisationHouse")]
        public string? OrganisationHouse { get; set; }

        [XmlElement(ElementName = "OrganisationOffice")]
        public string? OrganisationOffice { get; set; }

        [XmlElement(ElementName = "OrganisationPostalIndex")]
        public string? OrganisationPostalIndex { get; set; }

        [XmlElement(ElementName = "IINBIN")]
        public string? IINBIN { get; set; }

        [XmlElement(ElementName = "AdditionalAcData")]
        public AdditionalAcData? AdditionalAcData { get; set; }
    }
}
