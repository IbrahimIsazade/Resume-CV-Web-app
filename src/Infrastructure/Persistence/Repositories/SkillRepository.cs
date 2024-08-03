using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.common;

namespace Persistence.Repositories
{
    public class SkillRepository : AsyncRepository<Skill>, ISkillTypeRepository
    {
        public SkillRepository(DbContext db) : base(db) { }
    }
}
