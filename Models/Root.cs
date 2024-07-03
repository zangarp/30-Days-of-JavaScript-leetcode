using FinOpsAPI.Converters;
using Newtonsoft.Json;

namespace FinOpsAPI.Models;


public class BrokenFileInfo
{
    [JsonProperty("Name")]
    public string? Name { get; set; } = null;

    [JsonProperty("Length")]
    public int? Length { get; set; } = null;

    [JsonProperty("Buffer")]
    public string? Buffer { get; set; } = null;
}
public class BrokenFilesInfo
{
    [JsonProperty("BrokenFileInfo")]
    public List<BrokenFileInfo?>? BrokenFileInfo { get; set; } = null;
}

public class Attachment
{
    [JsonProperty("FileName")]
    public string? FileName { get; set; } = null;

    [JsonProperty("Length")]
    public int? Length { get; set; } = null;

    [JsonProperty("BrokenFilesInfo")]
    public BrokenFilesInfo? BrokenFilesInfo { get; set; } = null;
}

public class Attachments
{
    public List<Attachment?>? Attachment { get; set; } = null;
}

public class Root
{
    [JsonProperty("DocumentUniqueIdentifier")]
    public string? DocumentUniqueIdentifier { get; set; } = null;

    [JsonProperty("OriginalDocumentGuid")]
    public string? OriginalDocumentGuid { get; set; } = null;

    [JsonProperty("Comment")]
    public string? Comment { get; set; } = null;

    [JsonProperty("Attachments")]
    public Attachments? Attachments { get; set; } = null ;

    [JsonProperty("Version")]
    public string? Version { get; set; } = null;

    [JsonProperty("ResponseDateTime")]
    public string? ResponseDateTime { get; set; } = null;
}