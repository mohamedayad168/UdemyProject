using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Udemy.Core.Entities;
using Udemy.Core.Exceptions;
using Udemy.Core.IRepository;
using Udemy.Core.ReadOptions;
using Udemy.Service.DataTransferObjects.Create;
using Udemy.Service.DataTransferObjects.Read;
using Udemy.Service.DataTransferObjects.Update;
using Udemy.Service.IService;

namespace Udemy.Service.Service;
public class AskService(
    IRepositoryManager repository ,
    IMapper mapper) : IAskService
{
    private readonly IRepositoryManager repository = repository;
    private readonly IMapper mapper = mapper;

    public async Task<IEnumerable<AskDto>> GetAllUserCourseAsksAsync(
        int userId ,int courseId ,bool trackChanges ,RequestParamter requestParamter
    )
    {
        await CheckIfUserExistsAsync( userId );
        await CheckIfCourseExistsAsync(courseId );

        var asks = await repository.Ask.GetAllUserCourseAsksAsync(userId,courseId,trackChanges,requestParamter);
        var askDtos = mapper.Map<IEnumerable<AskDto>>(asks);

        return askDtos;
    }

    public async Task<AskDto?> GetUserCourseAskByIdAsync(
        int id,int userId ,int courseId ,bool trackChanges
    )
    {
        await CheckIfUserExistsAsync(userId);
        await CheckIfCourseExistsAsync(courseId);
        var ask = await GetUserCourseAskAndCheckIfItExistsAsync(id,userId,courseId,trackChanges);

        var askDto = mapper.Map<AskDto>(ask);

        return askDto;
    }

    public async Task<AskDto> CreateUserCourseAskAsync(
        AskForCreationDto askDto, int courseId, int userId
    )
    {
        await CheckIfUserExistsAsync(userId);
        await CheckIfCourseExistsAsync(courseId);

        var ask = mapper.Map<Ask>(askDto);
        ask.CourseId = courseId;
        ask.UserId = userId;

        repository.Ask.CreateAsk(ask);
        await repository.SaveAsync();

        var askDtoToReturn = mapper.Map<AskDto>(ask);
        return askDtoToReturn;
    }


    public async Task UpdateUserCourseAskAsync(
        AskForUpdatingDto askDto , int courseId , int userId , int askId
    )
    {
        await CheckIfUserExistsAsync(userId);
        await CheckIfCourseExistsAsync(courseId);
        var ask = await GetUserCourseAskAndCheckIfItExistsAsync(askId , userId , courseId , true);

        mapper.Map(askDto,ask);
        await repository.SaveAsync();
    }

    public async Task DeleteUserCourseAskAsync(
        int courseId , int userId , int askId
    )
    {
        await CheckIfUserExistsAsync(userId);
        await CheckIfCourseExistsAsync(courseId);
        var ask = await GetUserCourseAskAndCheckIfItExistsAsync(askId , userId , courseId , true);

        repository.Ask.DeleteAsk(ask);
        await repository.SaveAsync();
    }



    private async Task<Ask> GetUserCourseAskAndCheckIfItExistsAsync(
        int id, int userId, int courseId, bool trackChanges)
    {
        var ask = await repository.Ask.GetUserCourseAskByIdAsync(userId,courseId,id,trackChanges);
        if(ask is null)
            throw new NotFoundException($"Ask with Id: {id} Doesn't Exist.");

        return ask;
    }

    private async Task CheckIfCourseExistsAsync(int id)
    {
        var course = await repository.Courses
                .FindByCondition(c => c.Id == id , true)
                .FirstOrDefaultAsync();

        if (course is null)
            throw new NotFoundException($"Course With Id: {id} Deosn't Exist");
    }

    private async Task CheckIfUserExistsAsync(int id)
    {
        var user = await repository.User.GetUserByIdAsync(id);

        if (user is null)
            throw new UserNotFoundException($"User With Id: {id} Deosn't Exist");
    }
}
