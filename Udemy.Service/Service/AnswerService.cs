using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Udemy.Core.Entities;
using Udemy.Core.Exceptions;
using Udemy.Core.IRepository;
using Udemy.Core.ReadOptions;
using Udemy.Service.DataTransferObjects.Answer;
using Udemy.Service.IService;

namespace Udemy.Service.Service;
public class AnswerService(
    IRepositoryManager repository,
    IMapper mapper) : IAnswerService
{
    private readonly IRepositoryManager repository = repository;
    private readonly IMapper mapper = mapper;

    public async Task<IEnumerable<AnswerDto>> GetAllUserAskAnswersAsync(
        int userId ,int askId ,int courseId ,bool trackChanges ,RequestParamter requestParamter
    )
    {
        await CheckIfUserExistAsync(userId);
        await CheckIfCourseExistsAsync(courseId);
        await CheckIfAskExistsAsync(courseId , askId , userId);

        var answers = await repository.Answer.GetAllUserAskAnswersAsync(userId,askId,trackChanges,requestParamter);
        var answersDto = mapper.Map<IEnumerable<AnswerDto>>(answers);

        return answersDto;
    }

    public async Task<AnswerDto> GetUserAskAnswerByIdAsync(
        int userId , int askId , int courseId, int answerId
    )
    {
        await CheckIfUserExistAsync(userId);
        await CheckIfCourseExistsAsync(courseId);
        await CheckIfAskExistsAsync(courseId , askId , userId);

        var answer = await GetAnswerAndCheckIfItExistsAsync(userId, askId, courseId, answerId);

        var answerDto = mapper.Map<AnswerDto>(answer);
        return answerDto;
    }

    public async Task<AnswerDto> CreateUserAskAnswerAsync(
        AnswerForCreationDto answerDto, int courseId, int userId, int askId
    )
    {
        await CheckIfUserExistAsync(userId);
        await CheckIfCourseExistsAsync(courseId);
        await CheckIfAskExistsAsync(courseId, askId, userId);
        
        var answer = mapper.Map<Answer>(answerDto);
        answer.UserId = userId;
        answer.AskId = askId;

        repository.Answer.CreateAnswer(answer);
        await repository.SaveAsync();

        var answerDtoToReturn = mapper.Map<AnswerDto>(answer);
        return answerDtoToReturn;
    }

    public async Task UpdateUserAskAnswerAsync(
        AnswerForUpdatingDto answerDto , int courseId , int userId , int askId, int answerId
    )
    {
        await CheckIfUserExistAsync(userId);
        await CheckIfCourseExistsAsync(courseId);
        await CheckIfAskExistsAsync(courseId , askId , userId);

        var answer = await GetAnswerAndCheckIfItExistsAsync(userId, askId, courseId, answerId);

        mapper.Map(answerDto, answer);
        await repository.SaveAsync();
    }

    public async Task DeleteUserAskAnswerAsync(
        int courseId , int userId , int askId , int answerId
    )
    {
        await CheckIfUserExistAsync(userId);
        await CheckIfCourseExistsAsync(courseId);
        await CheckIfAskExistsAsync(courseId , askId , userId);

        var answer = await GetAnswerAndCheckIfItExistsAsync(userId , askId , courseId , answerId);

        repository.Answer.DeleteAnswer(answer);
        await repository.SaveAsync();
    }


    private async Task<Answer> GetAnswerAndCheckIfItExistsAsync(
        int userId , int askId , int courseId , int answerId
    )
    {
        var answer = await repository.Answer.GetUserAskAnswerByIdAsync(userId, askId, answerId, true);
        if(answer is null)
            throw new NotFoundException($"Answer with Id: {answerId} Doesn't Exist");

        return answer;
    }

    private async Task CheckIfUserExistAsync(int userId)
    {
        var user = await repository.User.GetUserByIdAsync(userId);
        if (user is null)
            throw new UserNotFoundException($"User With Id: {userId} Deosn't Exist");
    }

    private async Task CheckIfCourseExistsAsync(int courseId)
    {
        var course = await repository.Courses
            .FindByCondition(c => c.Id == courseId , true)
            .FirstOrDefaultAsync();

        if (course is null)
            throw new NotFoundException($"Course With Id: {courseId} Deosn't Exist");
    }

    private async Task CheckIfAskExistsAsync(
        int courseId , int askId , int userId
    )
    {
        var ask = await repository.Ask.GetUserCourseAskByIdAsync(userId , courseId , askId , true);
        if (ask is null)
            throw new NotFoundException($"Ask with Id: {askId} Doesn't Exist");
    }


    //private async Task CheckIfUserCourseAskExistsAsync(
    //    int courseId, int askId, int userId    
    //)
    //{
    //    //var course = await repository.Courses
    //    //        .FindByCondition(c => c.Id == courseId , true)
    //    //        .FirstOrDefaultAsync();

    //    //if (course is null)
    //    //    throw new NotFoundException($"Course With Id: {courseId} Deosn't Exist");

    //    //var user = await repository.User.GetUserByIdAsync(userId);
    //    //if (user is null)
    //    //    throw new UserNotFoundException($"User With Id: {userId} Deosn't Exist");

    //    //var ask = await repository.Ask.GetUserCourseAskByIdAsync(userId, courseId, askId , true);
    //    //if(ask is null )
    //    //    throw new NotFoundException($"Ask with Id: {askId} Doesn't Exist");
    //}

}
