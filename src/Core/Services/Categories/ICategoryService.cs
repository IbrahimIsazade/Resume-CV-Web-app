using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Categories
{
    public interface ICategoryService
    {
        Task<AddCategoryResponseDto> AddAsync(AddCategoryRequestDto model, CancellationToken cancellationToken = default);
        Task<EditCategoryDto> Edit(EditCategoryDto model, CancellationToken cancellationToken = default);
        Task<IEnumerable<CategoryGetAllDto>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<bool> Remove(int id, CancellationToken cancellationToken = default);
    }
}
