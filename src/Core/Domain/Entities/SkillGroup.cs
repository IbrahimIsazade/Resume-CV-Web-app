using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class SkillGroup : ICreateEntity
    {
        public int Id { get; set; }
        public required int TypeId { get; set; }
        public required string Name { get; set; }
        public required int CreatedBy { get; set; } = 1;
        public required DateTime CreatedAt { get; set; } = DateTime.Now;
        public int? LastModifiedBy { get; set; }
        public DateTime? LastModifieAt { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
