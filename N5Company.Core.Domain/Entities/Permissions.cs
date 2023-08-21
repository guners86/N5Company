namespace N5Company.Core.Domain.Entities
{
    public class Permissions
    {
        public int Id { get; set; }
        public string EmployeName { get; set; } = string.Empty;
        public string EmpolyeLastname { get; set; } = string.Empty;
        public int PermissionType { get; set; }
        public DateTime PermissionDate { get; set; }
        public List<PermissionTypes> PermissionTypes { get; set; } = new List<PermissionTypes>();
    }
}
