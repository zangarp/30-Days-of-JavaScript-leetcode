namespace FinOpsAPI.Models;

public class MessageHistory
{
    public string? MessCfmId { get; set; } = null;
    public string? ReceiveDate { get; set; } = null;
    public string? MessDate { get; set; } = null;
    public string? MessType { get; set; } = null;
    public string? ParentMessId { get; set; } = null;
    public string? Level { get; set; } = null;

}
