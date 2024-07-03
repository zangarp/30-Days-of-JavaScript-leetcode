namespace FinOpsAPI.Models
{
    public class Data
    {
        public Guid? Id { get; set; } = null;
        public string? RegNum { get; set; } = null;
        public string? Name { get; set; } = null;
        public string? Description { get; set; } = null;
        public string? BusinessOwnerDepCode { get; set; } = null;
        public string? ResponsibleDepCode { get; set; } = null;
        public int? IsBlockDivision { get; set; } = null;
        public DateTime? CreateDate { get; set; } = null;
        public int? Status { get; set; } = null;
    }
}
