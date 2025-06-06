﻿using Udemy.Core.Entities;
using Udemy.Service.DataTransferObjects.Create;
using Udemy.Service.DataTransferObjects.Read;
using Udemy.Service.DataTransferObjects.Update;

namespace Udemy.Service.IService
{
    public interface ISectionService
    {
        public Task<IEnumerable<SectionRDTO>> GetAllAsync(bool trackChanges);
        public Task<SectionRDTO> GetByIdAsync(int sectionId, bool trackchange);
        Task<Section> CreateSectionAsync(SectionCDTO section);
        Task<bool> UpdateAsync(int id, SectionUDTO section);
        Task<bool> DeleteSectionAsync(int id);
        Task<IEnumerable<SectionRDTO>> GetSectionsByCourseIdAsync(int courseId, bool trackChanges);

    }
}
