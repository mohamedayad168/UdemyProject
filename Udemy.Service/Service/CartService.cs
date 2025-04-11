using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Udemy.Core.Entities;
using Udemy.Core.Exceptions;
using Udemy.Core.IRepository;
using Udemy.Core.ReadOptions;
using Udemy.Service.DataTransferObjects.Read;
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
        var cart = await GetStudentCartAndCreateIfDoesntExistAsync(studentId);

        var cartDto = mapper.Map<CartDto>(cart);
        return cartDto;
    }

    public async Task AddCourseToStudentCartAsync(
        int courseId , int studentId
    )
    {
        await CheckIfStudentExistsAsync(studentId);
        await CheckIfCourseExistAsync(courseId);

        var cart = await GetStudentCartAndCreateIfDoesntExistAsync(studentId);

        cart.CartCourses.Add(new CartCourse() { CartId = cart.Id , CourseId = courseId });

        await repository.SaveAsync();
    }

    public async Task DeleteCart(int studentId)
    {
        await CheckIfStudentExistsAsync(studentId);

        var cart = await GetStudentCartAndCreateIfDoesntExistAsync(studentId);
        cart.ClientSecret = null;
        cart.PaymentIntentId = null;
        foreach(var cartCourse in cart.CartCourses)
        {
            await CheckIfCourseExistAsync(cartCourse.CourseId);
            repository.CartCourse.DeleteCartCourse(cartCourse);
        }

        await repository.SaveAsync();
    }

    public async Task DeleteCourseFromStudentCartAsync(int courseId , int studentId)
    {
        await CheckIfStudentExistsAsync(studentId);
        await CheckIfCourseExistAsync(courseId);

        var cart = await GetStudentCartAndCheckIfExistsAsync(studentId);

        var cartCourse = cart.CartCourses.FirstOrDefault(x => x.CartId == cart.Id && x.CourseId == courseId);

        if(cartCourse is null)
        {
            throw new NotFoundException($"Student with Id: {studentId} doens't have course with id: {courseId} in the cart");
        }

        repository.CartCourse.DeleteCartCourse(cartCourse);

        await repository.SaveAsync();
    }

    private async Task<Cart> GetStudentCartAndCreateIfDoesntExistAsync(int studentId)
    {
        var cart = await repository.Cart.GetStudentCartByIdAsync(
            studentId , true ,
            x => x.Include(a => a.Student) ,
            x => x.Include(a => a.CartCourses).ThenInclude(a => a.Course)
        );

        if (cart is null)
        {
            cart = new Cart();
            repository.Cart.CreateCart(cart);

            cart.StudentId = studentId;

            await repository.SaveAsync();
        }

        return cart;
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
    private async Task CheckIfCourseExistAsync(int courseId)
    {
        if (!await repository.Courses.CheckIfCourseExistsAsync(courseId))
            throw new BadRequestException($"Course with Id: {courseId} Doesn't Exists.");
    }
    private async Task CheckIfStudentExistsAsync(int id)
    {
        var student = await repository.Student.GetStudentByIdAsync(id , true);

        if (student is null)
            throw new UserNotFoundException($"Student With Id: {id} Deosn't Exist");
    }
}
