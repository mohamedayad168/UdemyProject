namespace Udemy.Core.ReadOptions;
public class CourseRequestParameter: RequestParamter
{
    // search courses name and category with same name
    public string SearchTerm { get; set; } = "";
    public string? OrderBy { get; set; } = "title";
}
