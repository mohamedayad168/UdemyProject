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

        public async Task<bool> CreateSectionAsync(SectionCDTO sectionCDto)
        {
            var section = _mapper.Map<Section>(sectionCDto);
            await _repository.sectionrepo.CreatesectionAsync(section);
            await _repository.SaveAsync();
            return true;
        }

        public async Task<bool> DeleteSectionAsync(int id)
        {
            var section = await _repository.sectionrepo.GetByIdAsync(id, true);
            if (section == null)
                return false;
            await _repository.sectionrepo.DeletesectionAsync(section);
            await _repository.SaveAsync();
            return true;
        }

        public async Task<IEnumerable<SectionRDTO>> GetAllAsync(bool trackChanges)
        {
            var sections = await _repository.sectionrepo.GetAllAsync(trackChanges);
            return _mapper.Map<IEnumerable<SectionRDTO>>(sections);
        }

        public async Task<SectionRDTO> GetByIdAsync(int sectionId, bool trackchange)
        {
            var section = await _repository.sectionrepo.GetByIdAsync(sectionId, trackchange);
            if (section == null)
                return null;

            return _mapper.Map<SectionRDTO>(section);
        }

        public async Task<bool> UpdateAsync(int id, SectionUDTO sectionDto)
        {
         
            var existingSection = await _repository.sectionrepo.GetByIdAsync(id, trackchange: true);
            if (existingSection == null) return false;

            _mapper.Map(sectionDto, existingSection);

            _repository.sectionrepo.Update(existingSection);
            await _repository.SaveAsync();
            return true;
        }
    }
}
