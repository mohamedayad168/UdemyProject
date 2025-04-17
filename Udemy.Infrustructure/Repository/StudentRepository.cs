using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using Udemy.Core.Entities;
using Udemy.Core.IRepository;
using Udemy.Core.ReadOptions;
using Udemy.Service.DataTransferObjects;
using Udemy.Infrastructure.Extensions;
using Udemy.Core.Enums;

namespace Udemy.Infrastructure.Repository;
public class StudentRepository(ApplicationDbContext context)
    : RepositoryBase<Student>(context), IStudentRepository
{
    private readonly ApplicationDbContext dbContext = context;

    public async Task<PaginatedRes<Student>> GetAllStudentsAsync(bool trackChanges, PaginatedSearchReq paginatedReq)
    {
        var query = FindAll(trackChanges)
            .Where(x => x.IsDeleted != true &&
                        x.Title.ToLower().Contains(paginatedReq.SearchTerm.Trim().ToLower()));

        var students = await query.Skip((paginatedReq.PageNumber - 1) * paginatedReq.PageSize)
            .Take(paginatedReq.PageSize)
            .ToListAsync();

        var paginatedRes = new PaginatedRes<Student>
        {
            CurrentPage = paginatedReq.PageNumber,
            Data = students,
            PageSize = paginatedReq.PageSize,
            TotalItems = await query.CountAsync()
        };

        return paginatedRes;
    }



    public async Task<PaginatedRes<Student>> GetPageAsync(PaginatedSearchReq searchReq, DeletionType deletionType, bool trackChanges)
    {

        IQueryable<Student> query;

        if (searchReq.SearchTerm!.Length > 0)
        {
            query = FindAll(trackChanges, deletionType)
            .Where(x =>
                x.FirstName.ToLower().Contains(searchReq.SearchTerm!.Trim().ToLower()) ||
                x.LastName.ToLower().Contains(searchReq.SearchTerm.Trim().ToLower()) ||
                x.Title.ToLower().Contains(searchReq.SearchTerm.Trim().ToLower())
             );
        }
        else
        {
            query = FindAll(trackChanges, deletionType);
        }


        var courses = await query
            .Sort(searchReq.OrderBy!)
            .Skip((searchReq.PageNumber - 1) * searchReq.PageSize)
            .Take(searchReq.PageSize)
             .ToListAsync();

        var response = new PaginatedRes<Student>
        {
            CurrentPage = searchReq.PageNumber,
            PageSize = searchReq.PageSize,
            TotalItems = await query.CountAsync(),
            Data = courses,
        };
        return response;
    }




    public async Task<Student?> GetStudentByIdAsync(int id, bool trackChanges)
    {
        return await FindByCondition(c => c.Id == id && c.IsDeleted != true, trackChanges)
            .FirstOrDefaultAsync();
    }
    public async Task CreateStudent(Student student)
    {
        Create(student);
    }
    public void DeleteStudent(Student student)
    {
        student.IsDeleted = true;
    }

    public async Task<int> GetStudentCount(IQueryable<Student> query)
    {
        return await query.CountAsync();
    }
}
