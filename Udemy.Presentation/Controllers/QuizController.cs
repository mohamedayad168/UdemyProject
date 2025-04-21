using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Core.Entities;
using Udemy.Core.ReadOptions;
using Udemy.Service.DataTransferObjects.Create;
using Udemy.Service.DataTransferObjects.Read;
using Udemy.Service.IService;

namespace Udemy.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
   public class QuizController(IServiceManager service,UserManager<ApplicationUser> userManager): ControllerBase
    {


        [HttpGet("{courseId:int}")]
        public async Task<IActionResult> GetCourseQuizzes(int courseId)
        {
          var quizzes = await service.QuizService.GetQuizWithQuestionsByCourseIdAsync(courseId);
            return Ok(quizzes);
        }

        [HttpGet("{courseId:int}/Answers")]
        public async Task<IActionResult> GetCourseQuizWithAnswers(int courseId)
        {
            var quizzes = await service.QuizService.GetQuizWithQuestionsAndAnswersByCourseIdAsync(courseId);
            return Ok(quizzes);
        }




        [HttpPost("Evaluate/{quizId:int}")]
        public async Task<IActionResult> EvaluateQuiz(int quizId, QuizAnswersForEvaluationCDTO answers)
        {
            if(quizId != answers.QuizId)
            {
                return BadRequest();
            }
            bool v = int.TryParse(userManager.GetUserId(User), out int studentId);
            if(!v) {
                return BadRequest();
            }
            var result = await service.QuizService.EvaluateQuizAsync(studentId,answers);
            return CreatedAtAction(nameof(GetStudentGrade), new { courseId = answers.CourseId,  studentId }, result);
        }
        [HttpGet("{courseId:int}/StudentGrade/{studentId:int}")]
        public async Task<IActionResult> GetStudentGrade(int courseId, int studentId)
        {

            bool v = int.TryParse(userManager.GetUserId(User), out int studentID);
            if (!v || studentID != studentId)
            {
                return BadRequest();
            }
            var quizzes = await service.QuizService.GetStudentGradeByCourseIdAsync(studentId,courseId);
            return Ok(quizzes);
        }

        [HttpPost()]

        public async Task<IActionResult> CreateQuiz([FromBody] QuizCDTO quizCDTO)
        {
            var result = await service.QuizService.CreateQuizAsync(quizCDTO);
            return CreatedAtAction(nameof(GetCourseQuizzes), new { courseId = quizCDTO.CourseId }, result);
        }
        //delete quiz
        [HttpDelete("{courseId:int}")]
        public async Task<IActionResult> DeleteQuiz(int courseId)
        {
            await service.QuizService.DeleteQuizAsync(courseId);
            return NoContent();
        }


    }
}
