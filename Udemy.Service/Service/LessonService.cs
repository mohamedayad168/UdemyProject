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
  public  class LessonService : ILessonService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public LessonService(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<LessonRDto>> GetAllAsync(bool trackChanges)
        {
            var lessons = await _repository.Lessons.GetAllAsync(trackChanges);
            return _mapper.Map<IEnumerable<LessonRDto>>(lessons);
        }

        public async Task<LessonRDto> GetByIdAsync(int lessonId, bool trackChange)
        {
            var lesson = await _repository.Lessons.GetByIdAsync(lessonId, trackChange);
            return lesson is null ? null : _mapper.Map<LessonRDto>(lesson);
        }

        public async Task<IEnumerable<LessonRDto>> GetLessonsBySectionIdAsync(int sectionId, bool trackChanges)
        {
            var lessons = await _repository.Lessons.GetLessonsBySectionIdAsync(sectionId, trackChanges);
            return _mapper.Map<IEnumerable<LessonRDto>>(lessons);
        }

        public async Task<bool> CreatelessonAsync(LessonCDto lessoncDto)
        {
            var lesson = _mapper.Map<Lesson>(lessoncDto);
            await _repository.Lessons.CreatelessonAsync(lesson);
            await _repository.SaveAsync();
            return (true);
        }

        public async Task<bool> UpdateAsync(int id, LessonUDto lessonDto)
        {
            var lesson = await _repository.Lessons.GetByIdAsync(id, trackchange: true);
            if (lesson is null) return false;

            _mapper.Map(lessonDto, lesson);
            await _repository.SaveAsync();
            return (true);
        }

        public async Task<bool> DeletelesssonAsync(int id)
        {
            var lesson = await _repository.Lessons.GetByIdAsync(id, trackchange: true);
            if (lesson == null)
            {
                return false; 
            }

            _repository.Lessons.Delete(lesson);
            await _repository.SaveAsync(); 
            return true; 
        }

    }
}