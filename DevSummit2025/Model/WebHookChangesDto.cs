namespace DevSummit2025.Model
{

    public class WebHookChangesDto 
    {
        public string? Entity { get; set; }
        public string? EntityId { get; set; }
        public string? TenantId { get; set; }
        public string? User { get; set; }
        public string? Host { get; set; }
        public string? SourceApplication { get; set; }
        public List<AttributeChanged>? Changes { get; set; }
    }

    public class AttributeChanged
    {
        public string? Name { get; set; }
        public string? Value { get; set; }
    }
}
