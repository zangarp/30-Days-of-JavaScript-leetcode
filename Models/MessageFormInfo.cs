namespace FinOpsAPI.Models;

public class MessageFormInfo
{
    public string? MessCfmId { get; set; } = null;
    public string? ReceiveDate { get; set; } = null;
    public string? MessDate { get; set; } = null;
    public string? MessType { get; set; } = null;
    public string? ParentMessId { get; set; } = null;
    public string? MessVersion { get; set; } = null;
    public string? MessDocId { get; set; } = null;
    public string? ParentMessDocId { get; set; } = null;
    public string? NMessNumber { get; set; } = null;
    public string? NLastModifyDate { get; set; } = null;
    public string? Ncomment { get; set; } = null;
    public string? NResponseDateTime { get; set; } = null;
    public string? NRequestDateTime { get; set; } = null;
}
