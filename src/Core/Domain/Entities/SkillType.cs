using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class SkillType : ICreateEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public required DateTime CreatedAt { get; set; }
        public required int CreatedBy { get; set; }
        public DateTime LastModifiedAt { get; set; }
        public int? LastModifiedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
        public int? DeletedBy { get; set; }
    }
}
