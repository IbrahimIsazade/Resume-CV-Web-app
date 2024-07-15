using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.common;

namespace Persistence.Repositories
{
    class ServicesRepository : AsyncRepository<Service>, IServicesRepository
    {
        public ServicesRepository(DbContext db) : base(db) { }

        //
    }
}
