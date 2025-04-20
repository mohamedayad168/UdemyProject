using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Core.Entities;
using Udemy.Core.Exceptions;
using Udemy.Core.IRepository;
using Udemy.Core.ReadOptions;
using Udemy.Service.DataTransferObjects.Create;
using Udemy.Service.DataTransferObjects.Read;
using Udemy.Service.IService;

namespace Udemy.Service.Service
{
    class QuizService(IRepositoryManager _repositoryManager,IMapper mapper) : IQuizService
    {
        public async Task<QuizForExamRDTO> GetQuizWithQuestionsByCourseIdAsync(int courseId, bool trackChanges = false)
        {
            //Check Course Exists
            var course = await _repositoryManager.Courses.FindByCondition(c => c.Id == courseId, trackChanges).FirstOrDefaultAsync()
                ?? throw new NotFoundException($"Course with id: {courseId} doesn't exist.");

            var quiz= await _repositoryManager.Quizzes.GetQuizWithQuestionsByCourseIdAsync(courseId, trackChanges)
                ?? throw new NotFoundException($"Quiz with id: {courseId} doesn't exist.");
           
            var quizDto= new QuizForExamRDTO(quiz);

            return quizDto;

        }

       public async Task<StudentGradeRDTO> EvaluateQuizAsync(int studentId,QuizAnswersForEvaluationCDTO quizAnswersForEvaluationCDTO)
       {
            var course = await _repositoryManager.Courses.FindByCondition(c => c.Id == quizAnswersForEvaluationCDTO.CourseId, false).FirstOrDefaultAsync()
                ?? throw new NotFoundException($"Course with id: {quizAnswersForEvaluationCDTO.CourseId} doesn't exist.");

            var quiz = await _repositoryManager.Quizzes.GetQuizWithQuestionsByCourseIdAsync(quizAnswersForEvaluationCDTO.CourseId, false)
                ?? throw new NotFoundException($"Quiz with id: {quizAnswersForEvaluationCDTO.CourseId} doesn't exist.");
            //check if grade exists
            var g = await _repositoryManager.StudentGrades.FindByCondition(sg => sg.StudentId == studentId && sg.QuizId == quiz.Id, false).FirstOrDefaultAsync();
            if (g is not null)
            {
                throw new BadRequestException($"Grade for student with id: {studentId} and quiz with id: {quiz.Id} already exists.");
            }
            //Evaluate Quiz
            var grade = quiz.QuizQuestion.Sum(q => q.AnswerTxt ==
            (quizAnswersForEvaluationCDTO.Answers.FirstOrDefault(a => a.QuestionId == q.Id)?.Answer)
                        ? 1 : 0) * 100 / quiz.QuizQuestion.Count;
            //Create New Grade
            var studentGrade = new StudentGrade()
            {
                QuizId = quiz.Id,
                StudentId = studentId,
                Grade = grade

            };
            _repositoryManager.StudentGrades.Create(studentGrade);
            await _repositoryManager.SaveAsync();
            return new StudentGradeRDTO(studentGrade);


        }

       public async Task<StudentGradeRDTO> GetStudentGradeByCourseIdAsync(int studentId, int courseId)
        {
            var course = await _repositoryManager.Courses.FindByCondition(c => c.Id == courseId, false).FirstOrDefaultAsync()
                ?? throw new NotFoundException($"Course with id: {courseId} doesn't exist.");
            var quiz = await _repositoryManager.Quizzes.FindByCondition(q => q.CourseId == courseId, false).FirstOrDefaultAsync()?? throw new NotFoundException($"Quiz with id: {courseId} doesn't exist.");

            var studentGrade = await _repositoryManager.StudentGrades.FindByCondition(sg => sg.StudentId == studentId && sg.QuizId ==quiz.Id , false).FirstOrDefaultAsync()
                ?? throw new NotFoundException($"Student Grade with id: {studentId} doesn't exist.");
            return new StudentGradeRDTO(studentGrade);
       }

       public async Task<QuizWithAnswersRDTO> GetQuizWithQuestionsAndAnswersByCourseIdAsync(int courseId)
        {
            //Check Course Exists
            var course = await _repositoryManager.Courses.FindByCondition(c => c.Id == courseId, false).FirstOrDefaultAsync()
                ?? throw new NotFoundException($"Course with id: {courseId} doesn't exist.");

            var quiz = await _repositoryManager.Quizzes.GetQuizWithQuestionsByCourseIdAsync(courseId, false)
                ?? throw new NotFoundException($"Quiz with id: {courseId} doesn't exist.");

            var quizDto = new QuizWithAnswersRDTO(quiz);

            return quizDto;
        }

        public async Task<QuizWithAnswersRDTO> CreateQuizAsync(QuizCDTO quizCDTO)
        {
            //check course exists
            var course = await _repositoryManager.Courses.FindByCondition(c => c.Id == quizCDTO.CourseId, false).FirstOrDefaultAsync()
                ?? throw new NotFoundException($"Course with id: {quizCDTO.CourseId} doesn't exist.");
            //check if course has a quiz
            var q =await _repositoryManager.Quizzes.FindByCondition(q => q.CourseId == quizCDTO.CourseId, false).AnyAsync();
            if (q)
            {
                throw new BadRequestException($"Course with id: {quizCDTO.CourseId} already has a quiz.");
            }
            //create new quiz
            var newQuiz = quizCDTO.MapToEntity();


             _repositoryManager.Quizzes.Create(newQuiz);
            await _repositoryManager.SaveAsync();

            return new QuizWithAnswersRDTO(newQuiz);


        }


    }
}
