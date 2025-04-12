namespace Udemy.Core.ReadOptions;
public class CourseRequestParameter: RequestParamter
{
    // search courses name and category with same name
    public string SrarchTerm { get; set; } = "";
}
