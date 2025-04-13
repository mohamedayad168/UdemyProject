using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Udemy.Core.Entities;
using Udemy.Core.IRepository;
using Udemy.Service.DataTransferObjects.Create;
using Udemy.Service.DataTransferObjects.Read;
using Udemy.Service.DataTransferObjects.Update;
using Udemy.Service.IService;

namespace Udemy.Service.Service
{
    public class InstructorService(IRepositoryManager repository, IMapper mapper) : IInstructorService
    {
        public async Task<IEnumerable<InstructorRDTO>> GetAllAsync(bool trackChanges)
        {
            var instructors = await repository.Instructors.FindAll(trackChanges).ToArrayAsync();
            return mapper.Map<IEnumerable<InstructorRDTO>>(instructors);
        }

        public async Task<InstructorRDTO?> GetByIdAsync(int id, bool trackChanges)
        {
            var instructor = await repository.Instructors.GetInstructorByIdAsync(id, trackChanges);
            return mapper.Map<InstructorRDTO?>(instructor);
        }

        public async Task<InstructorRDTO?> GetByTitleAsync(string title, bool trackChanges)
        {
            var instructor = await repository.Instructors.GetInstructorByTitleAsync(title, trackChanges);
            return mapper.Map<InstructorRDTO?>(instructor);
        }


        public async Task<InstructorRDTO> CreateAsync(InstructorCDTO dto)
        {
            var instructorEntity = mapper.Map<Instructor>(dto);
            await repository.Instructors.CreateInstructorAsync(instructorEntity);
            return mapper.Map<InstructorRDTO>(instructorEntity);
        }

        public async Task<bool> UpdateAsync(int id, InstructorUTO dto)
        {
            var instructor = await repository.Instructors.GetInstructorByIdAsync(id, true);
            if (instructor == null)
                return false;

            mapper.Map(dto, instructor);
            await repository.SaveAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var instructor = await repository.Instructors.GetInstructorByIdAsync(id, true);
            if (instructor == null)
                return false;

            instructor.IsDeleted = true;
            await repository.SaveAsync();
            return true;
        }

    }
}
