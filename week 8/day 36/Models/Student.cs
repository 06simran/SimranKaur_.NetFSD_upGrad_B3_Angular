namespace StudentCourseSystem.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; } = string.Empty;
        public int CourseId { get; set; }
        public Course? Course { get; set; }
    }
}
