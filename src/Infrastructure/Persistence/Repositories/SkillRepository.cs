using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.common;

namespace Persistence.Repositories
{
    public class SkillTypeRepository : AsyncRepository<SkillType>, ISkillTypeRepository
    {
        public SkillTypeRepository(DbContext db) : base(db) { }
    }
}
