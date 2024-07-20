
namespace Domain.Entities
{
    public class SkillGroup : ICreateEntity
    {
        public int Id { get; set; }
        public int TypeId { get; set; }
        public string Name { get; set; }
        public required DateTime CreatedAt { get; set; }
        public required int CreatedBy { get; set; }
        public DateTime? LastModifiedAt { get; set; }
        public int? LastModifiedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
        public int? DeletedBy { get; set; }

    }
}
