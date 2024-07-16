using Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Repositories.common
{
    public class AsyncRepository<T>(DbContext db) : IAsyncRepository<T>
        where T : class
    {
        public async Task AddAsync(T entry, CancellationToken cancellationToken = default)
        {
            await db.Set<T>().AddAsync(entry, cancellationToken);
        }

        public void Delete(T entry)
        {
            db.Entry(entry).State = EntityState.Deleted;

            if(db.Entry(entry) is IDeleteEntity)
            {
                db.Entry(entry).State = EntityState.Modified;
                var entity = (IDeleteEntity)db.Entry(entry);
                entity.DeletedAt = DateTime.Now;
            }
        }

        public void Edit(T entry)
        {
            db.Entry(entry).State = EntityState.Modified;
        }

        public IQueryable<T> GetAll()
        {
            return db.Set<T>().AsQueryable();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>>? expression = null, CancellationToken cancellationToken = default)
        {
            var query = db.Set<T>().AsQueryable();

            if (expression is not null)
                query = query.Where(expression);

            var entry = await query.FirstOrDefaultAsync(cancellationToken);

            if (entry is null) 
                throw new ArgumentNullException(nameof(entry));

            return entry;
        }

        public async Task<int> SaveAsync(CancellationToken cancellationToken = default)
        {
            return await db.SaveChangesAsync(cancellationToken);
        }
    }
}
