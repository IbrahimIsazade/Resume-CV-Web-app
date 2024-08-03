using Domain.Entities;

namespace Services.Skills
{
    public class SkillTypeGetAllDto
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required DateTime CreatedAt { get; set; }
    }
}
