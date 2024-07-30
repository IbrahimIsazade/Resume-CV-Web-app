using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.common;

namespace Persistence.Repositories
{
    public class CategoriesRepository : AsyncRepository<Category>, ICategoryRepository
    {
        public CategoriesRepository(DbContext db) : base(db) { }

    }
}
