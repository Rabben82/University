namespace University.Web.Models.ViewModels
{
#nullable disable
    public class StudentIndexViewModel
    {
        public int Id { get; set; }
        public string Avatar { get; set; }

        public string FullName { get; set; }
        public string Street { get; set; }

       // public IEnumerable<CourseInfo> CourseInfos { get; set; }
        

    }

    public record StudentIndexViewModel2(int Id, string Avatar, string FullName, string Street);

    //public class CourseInfo
    //{
    //    public int Grade { get; set; }
    //    public string CourseName { get; set; }
    //}
}
