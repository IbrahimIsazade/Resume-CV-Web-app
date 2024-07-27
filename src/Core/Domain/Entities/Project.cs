namespace Domain.Entities
{
    public class Project : ICreateEntity
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string ImagePath { get; set; }
        public required string Url { get; set; }
        public required int CreatedBy { get; set; }
        public required DateTime CreatedAt { get; set; }
        public int? LastModifiedBy { get; set; }
        public DateTime? LastModifieAt { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }

    }
}
