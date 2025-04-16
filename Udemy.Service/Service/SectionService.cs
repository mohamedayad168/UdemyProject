using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Core.Entities;
using Udemy.Core.IRepository;
using Udemy.Service.DataTransferObjects.Create;
using Udemy.Service.DataTransferObjects.Read;
using Udemy.Service.DataTransferObjects.Update;
using Udemy.Service.IService;

namespace Udemy.Service.Service
{
    public class SectionService : ISectionService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public SectionService(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<SectionRDTO>> GetSectionsByCourseIdAsync(int courseId, bool trackChanges)
        {
            var sections = await _repository.Section.GetSectionsByCourseIdAsync(courseId, trackChanges);
            return _mapper.Map<IEnumerable<SectionRDTO>>(sections);
        }

        public async Task<bool> CreateSectionAsync(SectionCDTO sectionCDto)
        {
            var section = _mapper.Map<Section>(sectionCDto);
            await _repository.Section.CreatesectionAsync(section);
            await _repository.SaveAsync();
            return true;
        }

        public async Task<bool> DeleteSectionAsync(int id)
        {
            var section = await _repository.Section.GetByIdAsync(id, true);
            if (section == null)
                return false;
            await _repository.Section.DeletesectionAsync(section);
            await _repository.SaveAsync();
            return true;
        }

        public async Task<IEnumerable<SectionRDTO>> GetAllAsync(bool trackChanges)
        {
            var sections = await _repository.Section.GetAllAsync(trackChanges);
            return _mapper.Map<IEnumerable<SectionRDTO>>(sections);
        }

        public async Task<SectionRDTO> GetByIdAsync(int sectionId, bool trackchange)
        {
            var section = await _repository.Section.GetByIdAsync(sectionId, trackchange);
            if (section == null)
                return null;

            return _mapper.Map<SectionRDTO>(section);
        }

        public async Task<bool> UpdateAsync(int id, SectionUDTO sectionDto)
        {
         
            var existingSection = await _repository.Section.GetByIdAsync(id, trackchange: true);
            if (existingSection == null) return false;

            _mapper.Map(sectionDto, existingSection);

            _repository.Section.Update(existingSection);
            await _repository.SaveAsync();
            return true;
        }
    }
}
