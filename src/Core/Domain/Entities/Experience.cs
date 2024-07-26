namespace Domain.Entities
{
    public class Experience
    {
        public int Id { get; set; }
        public required int ResumeId { get; set; }
        public required string Duration { get; set; }
        public required string JobTitle { get; set; }
        public required string CompanyName { get; set; }
        public required string Location { get; set; }
        public required string Details { get; set; }
        public required string ImagePath { get; set; }

    }
}
