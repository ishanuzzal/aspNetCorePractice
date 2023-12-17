using WebApplication2.Models;

namespace WebApplication2.Repository
{
    public interface IStudent
    {
        List<StudentModel> getAllStudent();
        StudentModel getStudentById(int id);
    }
}
