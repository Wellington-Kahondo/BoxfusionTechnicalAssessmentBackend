using Abp.Domain.Repositories;
using Abp.Domain.Services;
using System;
using System.Threading.Tasks;

namespace Boxfusion.TechnicalAssessment.Domain.Skills
{
    public class SkillManager : DomainService
    {
        private readonly IRepository<Skill, Guid> _skillRepository;
        public SkillManager(IRepository<Skill, Guid> skillRepository)
        {
            _skillRepository = skillRepository;    
        }

        public async Task<Skill> CreateSkillAsync(Skill skill)
        {
            skill = await _skillRepository.InsertAsync(skill);

            return skill;
        }

        public async Task<Skill> UpdateSkillAsync(Skill skill)
        {
            return await _skillRepository.UpdateAsync(skill);
        }

        public async Task DeleteSkillAsync(Guid id)
        {
            await _skillRepository.DeleteAsync(id);
        }
    }
}
