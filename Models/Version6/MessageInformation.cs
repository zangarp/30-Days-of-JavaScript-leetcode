using System.Globalization;
using System.Xml.Serialization;

namespace MessageModel.Models
{
    [XmlRoot(ElementName = "MessageInformation")]
    public class MessageInformation
    {
        [XmlElement(ElementName = "DocumentType")]
        public string? DocumentType { get; set; }

        [XmlElement(ElementName = "MessageNumber")]
        public string? MessageNumber { get; set; }

        [XmlElement(ElementName = "LastModifyDate")]
        public string? LastModifyDate { get; set; }

        [XmlElement(ElementName = "TransactionDate")]
        public string TransactionDate { get; set; }

        [XmlElement(ElementName = "ViewOperationId")]
        public string? ViewOperationId { get; set; }

        [XmlElement(ElementName = "OperationNumber")]
        public string? OperationNumber { get; set; }

        [XmlElement(ElementName = "DocOperationReason")]
        public string? DocOperationReason { get; set; }

        [XmlElement(ElementName = "DocOperationNumber")]
        public string? DocOperationNumber { get; set; }

        [XmlElement(ElementName = "DocOperationDate")]
        public string? DocOperationDate { get; set; }

        [XmlElement(ElementName = "CurrencyCodeId")]
        public string? CurrencyCodeId { get; set; }

        [XmlElement(ElementName = "AmountCurrency")]
        public string? AmountCurrency { get; set; }

        [XmlElement(ElementName = "AmountCurrencyTenge")]
        public string? AmountCurrencyTenge { get; set; }

        [XmlElement(ElementName = "OperationStatusId")]
        public string? OperationStatusId { get; set; }

        [XmlElement(ElementName = "ReasonFilingId")]
        public string? ReasonFilingId { get; set; }

        [XmlElement(ElementName = "CounterMeasure")]
        public string? CounterMeasure { get; set; }

        [XmlElement(ElementName = "SuspicionFirst")]
        public string? SuspicionFirst { get; set; }

        [XmlElement(ElementName = "SuspicionSecond")]
        public string? SuspicionSecond { get; set; }

        [XmlElement(ElementName = "SuspicionThird")]
        public string? SuspicionThird { get; set; }

        [XmlElement(ElementName = "DescriptionDifficulties")]
        public string? DescriptionDifficulties { get; set; }

        [XmlElement(ElementName = "MoreInformation")]
        public string? MoreInformation { get; set; }

        [XmlElement(ElementName = "ParticipantCount")]
        public string? ParticipantCount { get; set; }

        [XmlElement(ElementName = "FirstAdditionalOperationTypeCode")]
        public string? FirstAdditionalOperationTypeCode { get; set; }

        [XmlElement(ElementName = "SecondAdditionalOperationTypeCode")]
        public string? SecondAdditionalOperationTypeCode { get; set; }

        [XmlElement(ElementName = "ISIN")]
        public string? Isin { get; set; }

        [XmlElement(ElementName = "CFI")]
        public string? Cfi { get; set; }

        [XmlElement(ElementName = "ContractAmountInSettlementCurrency")]
        public string? ContractAmountInSettlementCurrency { get; set; }

        [XmlElement(ElementName = "ContractAmountInTenge")]
        public string? ContractAmountInTenge { get; set; }

        [XmlElement(ElementName = "GrossPricePerUnitInTransactionCurrency")]
        public string? GrossPricePerUnitInTransactionCurrency { get; set; }

        [XmlElement(ElementName = "GrossPricePerUnitInTenge")]
        public string? GrossPricePerUnitInTenge { get; set; }

        [XmlElement(ElementName = "TransactionLocation")]
        public string? TransactionLocation { get; set; }

        [XmlElement(ElementName = "TransactionAddress")]
        public TransactionAddress? TransactionAddress { get; set; }

        [XmlElement(ElementName = "TransactionVenue")]
        public string? TransactionVenue { get; set; }

        [XmlElement(ElementName = "NumberOfSecurities")]
        public string? NumberOfSecurities { get; set; }

        [XmlElement(ElementName = "MerchTypes")]
        public string? MerchTypes { get; set; }

        [XmlElement(ElementName = "MerchReginfo")]
        public string? MerchReginfo { get; set; }

        [XmlElement(ElementName = "EknpId")]
        public EknpId? EknpId { get; set; }

        [XmlElement(ElementName = "ReferCount")]
        public string? ReferCount { get; set; }
    }
}
