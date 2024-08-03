using Domain.Entities;

namespace Services.Skills
{
    public interface ISkillTypeService
    {
        Task<IEnumerable<SkillTypeGetAllDto>> GetAll(CancellationToken cancellationToken = default);
        Task<SkillType> GetById(int id, CancellationToken cancellationToken = default);
        Task<AddSkillTypeResponseDto> AddSkill(AddSkillTypeRequestDto model, CancellationToken cancellationToken = default);
    }
}
