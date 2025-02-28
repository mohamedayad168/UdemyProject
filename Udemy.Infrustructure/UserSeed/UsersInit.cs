using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Core.Entities;

namespace Udemy.Infrastructure.UserSeed
{
    public class UsersInit
    {
        public ApplicationUser Admin;
        public Student Student;
        public Instructor Instructor;


        public UsersInit()
        {
            Admin = new ApplicationUser
            {
                Id = 1,
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@gmail.com",
                NormalizedEmail = "ADMIN@gmail.com",
                EmailConfirmed = true,
                SecurityStamp = string.Empty,
                FirstName = "Admin",
                LastName = "Admin",
                Age = 30,
                CountryName = "United States",
                City = "New York",
                State = "New York",
                Gender = "M"

            };
            Admin.EmailConfirmed = true;
            Admin.PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(Admin, "Admin123");
            Admin.SecurityStamp = Guid.NewGuid().ToString();

            Instructor = new Instructor
            {
                Id = 2,
                UserName = "instructor",
                NormalizedUserName = "INSTRUCTOR",
                Email = "instructor@gmail.com",
                NormalizedEmail = "INSTRUCTOR@gmail.com",
                EmailConfirmed = true,
                SecurityStamp = string.Empty,
                CountryName = "United States",
                City = "New York",
                State = "New York",
                FirstName = "Admin",
                LastName = "Admin",
                Age = 30,
                Gender = "M"
            }
           ;
            Instructor.EmailConfirmed = true;
            Instructor.PasswordHash = new PasswordHasher<Instructor>().HashPassword(Instructor, "Instructor123");
            Instructor.SecurityStamp = Guid.NewGuid().ToString();

            Student = new Student
            {
                Id = 3,
                UserName = "student",
                NormalizedUserName = "STUDENT",
                Email = "student@gmail.com",
                NormalizedEmail = "STUDENT@gmail.com",
                EmailConfirmed = true,
                SecurityStamp = string.Empty,
                CountryName = "United States",
                City = "New York",
                State = "New York",
                FirstName = "Admin",
                LastName = "Admin",
                Age = 30,
                Gender = "M",
                Title = "Student"
            };
            Student.EmailConfirmed = true;
            Student.PasswordHash = new PasswordHasher<Student>().HashPassword(Student, "Student123");
            Student.SecurityStamp = Guid.NewGuid().ToString();
        }

    }



}
