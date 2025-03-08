namespace Udemy.Service.IService
{
    internal interface IRatingService
    {
        Task CreatReating(int courseId, int studentId);
        Task UpdateRating(int courseId, int studentId);
        Task GetAllRatingAndComments();
    }
}
