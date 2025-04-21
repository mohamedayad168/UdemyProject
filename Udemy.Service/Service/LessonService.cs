using AutoMapper;
using Udemy.Core.Entities;
using Udemy.Core.IRepository;
using Udemy.Service.DataTransferObjects.Create;
using Udemy.Service.DataTransferObjects.Read;
using Udemy.Service.DataTransferObjects.Update;
using Udemy.Service.IService;

namespace Udemy.Service.Service
{
    public class LessonService : ILessonService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        private readonly ICloudService cloudService;

        public LessonService(IRepositoryManager repository, IMapper mapper, ICloudService cloudService)
        {
            _repository = repository;
            _mapper = mapper;
            this.cloudService = cloudService;
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

        public async Task<Lesson> CreatelessonAsync(LessonCDto lessoncDto)
        {

            string? videoUrl = null;


            if (lessoncDto.VideoUrl != null)
                videoUrl = await cloudService.UploadVideoAsync(lessoncDto.VideoUrl);
            var lesson = _mapper.Map<Lesson>(lessoncDto);
            lesson.VideoUrl = videoUrl;
            await _repository.Lessons.CreatelessonAsync(lesson);
            await _repository.SaveAsync();
            return (lesson);
        }

        public async Task<bool> UpdateAsync(int id, LessonUDto lessonDto)
        {
            var lesson = await _repository.Lessons.GetByIdAsync(id, false);
            if (lesson is null) return false;
            string? videoUrl = null;


            if (lessonDto.VideoUrl != null)
                videoUrl = await cloudService.UploadVideoAsync(lessonDto.VideoUrl);
            var updatedLesson = _mapper.Map<Lesson>(lessonDto);
            updatedLesson.VideoUrl = videoUrl;

            _repository.Lessons.Update(updatedLesson);
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

        public async Task<int> GetLessonInstructorId(int lessonId)
        {
            return await _repository.Lessons.GetLessonInstructorId(lessonId);
        }

    }
}