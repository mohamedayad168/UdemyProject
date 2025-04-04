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
public class CartService(
    IRepositoryManager repository ,
    IMapper mapper) : ICartService
{
    private readonly IRepositoryManager repository = repository;
    private readonly IMapper mapper = mapper;

    public async Task<IEnumerable<CartDto>> GetAllStudentsCartsAsync(
        bool trackChanges , RequestParamter requestParamter
    )
    {
        var studentsCarts = await repository.Cart.GetAllCartsAsync(
            trackChanges , requestParamter ,
            x => x.Include(a => a.Student) ,
            x => x.Include(a => a.CartCourses).ThenInclude(a => a.Course)
        );

        var studentCartDtos = mapper.Map<IEnumerable<CartDto>>(studentsCarts);
        return studentCartDtos;
    }

    public async Task<CartDto> GetStudentCartAsync(
        int studentId , bool trackChanges
    )
    {
        await CheckIfStudentExistsAsync(studentId);
        var cart = await GetStudentCartAndCheckIfExistsAsync(studentId);

        var cartDto = mapper.Map<CartDto>(cart);
        return cartDto;
    }

    public async Task<CartDto> CreateStudentCartAsync(
        CartForCreationDto cartDto , int studentId
    )
    {
        await CheckIfStudentExistsAsync(studentId);

        if (await repository.Cart.CheckIfStudentCartExist(studentId))
        {
            throw new BadRequestException($"Student With Id: {studentId} already have a cart.");
        }

        await CheckIfCartCoursesExistAsync(cartDto.CourseIds);

        var cart = new Cart();
        repository.Cart.CreateCart(cart);
        cart.StudentId = studentId;
        await repository.SaveAsync();

        mapper.Map(cartDto , cart);
        await repository.SaveAsync();

        var cartDtoToReturn = mapper.Map<CartDto>(cart);
        return cartDtoToReturn;
    }

    public async Task UpdateStudentCartAsync(
        CartForUpdatingDto cartDto , int studentId
    )
    {
        await CheckIfStudentExistsAsync(studentId);
        await CheckIfCartCoursesExistAsync(cartDto.CourseIds);

        var cart = await GetStudentCartAndCheckIfExistsAsync(studentId);

        foreach (var cartCourse in cart.CartCourses)
        {
            repository.Cart.DeleteCartCourse(cartCourse);
        }

        foreach (var courseId in cartDto.CourseIds)
        {
            cart.CartCourses.Add(new CartCourse { CourseId = courseId });
        }

        await repository.SaveAsync();
    }

    public async Task DeleteStudentCartAsync(int studentId)
    {
        await CheckIfStudentExistsAsync(studentId);
        var cart = await GetStudentCartAndCheckIfExistsAsync(studentId);

        foreach (var cartCourse in cart.CartCourses)
        {
            repository.Cart.DeleteCartCourse(cartCourse);
        }

        repository.Cart.DeleteCart(cart);

        await repository.SaveAsync();
    }




    private async Task<Cart> GetStudentCartAndCheckIfExistsAsync(int studentId)
    {
        // each student have one cart , so i don't have to use cartId here
        var studentCart = await repository.Cart.GetStudentCartByIdAsync(
            studentId , true ,
            x => x.Include(a => a.Student) ,
            x => x.Include(a => a.CartCourses).ThenInclude(a => a.Course)
        );

        if (studentCart is null)
            throw new NotFoundException($"Student With Id: {studentId} Deosn't Have Cart");
        return studentCart;
    }
    private async Task CheckIfCartCoursesExistAsync(List<int> courseIds)
    {
        foreach (var courseId in courseIds)
        {
            if (!await repository.Courses.CheckIfCourseExistsAsync(courseId))
                throw new BadRequestException($"Course with Id: {courseId} Doesn't Exists.");
        }
    }
    private async Task CheckIfStudentExistsAsync(int id)
    {
        var student = await repository.Student.GetStudentByIdAsync(id , true);

        if (student is null)
            throw new UserNotFoundException($"Student With Id: {id} Deosn't Exist");
    }
}
