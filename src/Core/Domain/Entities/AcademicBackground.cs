using Domain.Concretes;

namespace Domain.Entities
{
    public class AcademicBackground
    {
        public int Id { get; set; }
        public required int ResumeId { get; set; }
        public required string Qualification { get; set; }
        public required Degrees Degree { get; set; }
        public required string EducationName { get; set; }
        public required int Obtention { get; set; }
        public required string Details { get; set; }
    }
}
