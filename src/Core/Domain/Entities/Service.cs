namespace Domain.Entities
{
    public class Service : ICreateEntity
    {
        public int Id { get; set; }
        public string? CssClass { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public required DateTime CreatedAt { get; set; }
        public required int CreatedBy { get; set; }
        public DateTime? LastModifiedAt { get; set; }
        public int? LastModifiedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
        public int? DeletedBy { get; set; }
    }
}
