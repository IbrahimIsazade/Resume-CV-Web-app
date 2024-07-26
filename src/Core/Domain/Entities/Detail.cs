namespace Domain.Entities
{
    public class Detail
    {
        public int Id { get; set; }
        public required int ResumeId { get; set; }
        public required string Title { get; set; }
        public required string Content { get; set; }
    }
}
