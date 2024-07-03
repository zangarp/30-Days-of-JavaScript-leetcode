using System.Runtime.CompilerServices;

namespace FinOpsAPI.Models
{
    public class Message
    {
        public int? RowNumber { get; set; }
        public string? Id { get; set; }
        public DateTime? ReceiveDate { get; set; }
        public string? CFMCode { get; set; }
        public string? OperationTypeID { get; set; }
        public string? OperationViewID { get; set; }
        public string OperationNumber { get; set; } // ?????
        public string? CurrencyCode { get; set; }
        public string CurrencyName { get; set; }
        public decimal? AmountCurrency { get; set; }
        public decimal? AmountCurrencyTenge { get; set; }
        public string DocOperationName { get; set; }
        public string DocOperationNumber { get; set; }
        public DateTime? MessageDate { get; set; }
        public string? Status { get; set; }
        public string MessageVersion { get; set; }
        public string MessageDocumentID { get; set; }
        public string? WorkStage { get; set; }
        public string? MessageType { get; set; }
        public string? MessageTypeName { get; set; }
        public string UpdateVersion { get; set; }
        public DateTime? DateRelease { get; set; }
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public string? MessageNumber { get; set; }
        public string? MessageDocumentType { get; set; }
        public string? MessageDocumentName { get; set; }
        public string? MessageReason { get; set; }
        public string StatusName { get; set; }
        public string? OperationStatus { get; set; }

    }
}
