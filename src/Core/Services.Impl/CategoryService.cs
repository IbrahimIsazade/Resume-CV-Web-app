using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Services.Categories;

namespace Services.Impl
{
    public class CategoryService(ICategoryRepository categoryRepository) : ICategoryService
    {
        public async Task<AddCategoryResponseDto> AddAsync(AddCategoryRequestDto model, CancellationToken cancellationToken = default)
        {
            var entity = new Category { Name = model.Name, CreatedAt = DateTime.Now, CreatedBy = 1 };

            await categoryRepository.AddAsync(entity, cancellationToken);
            await categoryRepository.SaveAsync(cancellationToken);

            return new AddCategoryResponseDto { Id = entity.Id, Name = entity.Name };
        }

        public async Task<EditCategoryDto> Edit(EditCategoryDto model, CancellationToken cancellationToken = default)
        {
            var entity = await categoryRepository.GetAsync(m => m.Id == model.Id, cancellationToken);

            entity.Name = model.Name;

            categoryRepository.Edit(entity);
            await categoryRepository.SaveAsync(cancellationToken);

            return model;
        }

        public async Task<IEnumerable<CategoryGetAllDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var data = await categoryRepository.GetAll()
                .Select(m => new CategoryGetAllDto
                {
                    Id = m.Id,
                    Name = m.Name,
                    CreatedAt = m.CreatedAt
                })
                .ToListAsync(cancellationToken);

            return data;
        }

        public async Task<bool> Remove(int id, CancellationToken cancellationToken = default)
        {
            var entity = await categoryRepository.GetAsync(m => m.Id == id, cancellationToken);

            if (entity is null)
            {
                return false;
            }

            categoryRepository.Delete(entity);
            await categoryRepository.SaveAsync(cancellationToken);

            return true;
        }
    }
}
