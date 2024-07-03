namespace FinOpsAPI.Models
{
    public class Handbook
    {
        public string Code { get; set; } = null!;
        public string? ShortName { get; set; }
        public string? Name { get; set; }
        public bool IsEnabled { get; set; }
    }
}
