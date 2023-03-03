namespace DevJJGRCore.Common.Models
{
    public class ItemDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string EmployeeId { get; set; }
        public long Supervisor { get; set; }
        public bool IsGroup { get; set; }
    }
}
