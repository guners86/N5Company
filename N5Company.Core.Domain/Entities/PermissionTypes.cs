namespace N5Company.Core.Domain.Entities
{
    public class PermissionTypes
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public List<Permissions> Permissions { get; set; }
    }
}
