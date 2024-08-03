using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Services.Skills;

namespace Services.Impl
{
    public class SkillTypeService(ISkillTypeRepository skillTypeRepository) : ISkillTypeService
    {
        public async Task<AddSkillTypeResponseDto> AddSkill(AddSkillTypeRequestDto model, CancellationToken cancellationToken = default)
        {
            var skillType = new SkillType 
            {
                Name = model.Name,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = 1
            };

            try
            {
                await skillTypeRepository.AddAsync(skillType);
                await skillTypeRepository.SaveAsync(cancellationToken);
            }
            catch (Exception ex) 
            {
                return new AddSkillTypeResponseDto { Error = true };
            }

            return new AddSkillTypeResponseDto { Error = false };
        }

        public async Task<IEnumerable<SkillTypeGetAllDto>> GetAll(CancellationToken cancellationToken = default)
        {
            return await skillTypeRepository.GetAll()
                .Select(m => new SkillTypeGetAllDto
                {
                    Id = m.Id,
                    Name = m.Name,
                    CreatedAt = m.CreatedAt
                }).ToListAsync(cancellationToken);
        }

        public async Task<SkillType> GetById(int id, CancellationToken cancellationToken = default)
        {
            return await skillTypeRepository.GetAsync(m => m.Id == id, cancellationToken);
        }
    }
}
