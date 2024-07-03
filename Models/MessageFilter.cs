namespace FinOpsAPI.Models
{
    public class MessageFilter
    {
        public int ListId { get; set; }
        public int MessNumberBegin { get; set; }
        public int MessNumberEnd { get; set; }
        public bool ForLastDays { get; set; }
        public int LastDays { get; set; }
        public DateTime ReceiveDateBegin { get; set; }
        public DateTime ReceiveDateEnd { get; set; }
        public DateTime SendDateBegin { get; set; }
        public DateTime SendDateEnd { get; set; }
        public Handbook Reason { get; set; }
        public Handbook OperationStatus { get; set; }
        public Handbook Currency { get; set; }
        public int AmountCurrencyBegin { get; set; }
        public int AmountCurrencyEnd { get; set; }
        public int AmountCurrencyTengeBegin { get; set; }
        public int AmountCurrencyTengeEnd { get; set; }
        public Handbook OperationNumber { get; set; }
        public Handbook OperationType { get; set; }
        public Handbook ViewOperation { get; set; }
    }
}
