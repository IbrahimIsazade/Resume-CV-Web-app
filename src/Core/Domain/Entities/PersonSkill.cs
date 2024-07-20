using Domain.Concretes;

namespace Domain.Entities
{
    public class PersonSkill
    {
        public required int PersonId { get; set; }
        public required int SkillId { get; set; }
        public required DisplayMode Mode { get; set; }
        public required byte Percentage { get; set; }
        public DateTime? LastModifiedAt { get; set; }
        public int? LastModifiedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
        public int? DeletedBy { get; set; }
    }
}
