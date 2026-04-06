using WebApplication11.Models;

namespace WebApplication11.Services
{
    public interface IStudentService
    {
        List<Student> GetAllStudents();
        Student GetStudentById(int id);
        void AddStudent(Student student);
    }
}
