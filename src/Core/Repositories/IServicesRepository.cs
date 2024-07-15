using Domain.Entities;
using Repositories.common;

namespace Repositories
{
    public interface IServicesRepository : IAsyncRepository<Service>
    {
    }
}
