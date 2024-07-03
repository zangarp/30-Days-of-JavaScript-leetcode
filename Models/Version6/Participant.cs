using System.Xml.Serialization;

namespace MessageModel.Models
{
    [XmlRoot(ElementName = "Participant")]
    public class Participant
    {
        [XmlElement(ElementName = "MemberId")]
        public string? MemberId { get; set; }

        [XmlElement(ElementName = "ParticipantsView")]
        public string? ParticipantsView { get; set; }

        [XmlElement(ElementName = "ParticipantsType")]
        public string? ParticipantsType { get; set; }

        [XmlElement(ElementName = "IsClientSubject")]
        public string? IsClientSubject { get; set; }

        [XmlElement(ElementName = "Residence")]
        public string? Residence { get; set; }

        [XmlElement(ElementName = "CorrespondentBank")]
        public CorrespondentBank? CorrespondentBank { get; set; }

        [XmlElement(ElementName = "ForeignPerson")]
        public string? ForeignPerson { get; set; }

        [XmlElement(ElementName = "OKED")]
        public string? Oked { get; set; }

        [XmlElement(ElementName = "IndividualIssue")]
        public string? IndividualIssue { get; set; }

        [XmlElement(ElementName = "PhoneNumber")]
        public string? PhoneNumber { get; set; }

        [XmlElement(ElementName = "Email")]
        public string? Email { get; set; }

        [XmlElement(ElementName = "AdditionalInformation")]
        public string? AdditionalInformation { get; set; }

        [XmlElement(ElementName = "MoneyTransSys")]
        public string? MoneyTransSys { get; set; }

        [XmlElement(ElementName = "Founders")]
        public Founders? Founders { get; set; }

        [XmlElement(ElementName = "ParticipantNationality")]
        public string? ParticipantNationality { get; set; }

        [XmlElement(ElementName = "PublicOfficialStatus")]
        public string? PublicOfficialStatus { get; set; }

        [XmlElement(ElementName = "ParticipantSubaccount")]
        public string? ParticipantSubaccount { get; set; }

        [XmlElement(ElementName = "BeneficialOwners")]
        public BeneficialOwners? BeneficialOwners { get; set; }

        [XmlElement(ElementName = "AdditionalPersonInfo")]
        public AdditionalPersonInfo? AdditionalPersonInfo { get; set; }
    }
}
