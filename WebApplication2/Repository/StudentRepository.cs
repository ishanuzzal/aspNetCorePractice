using WebApplication2.Models;

namespace WebApplication2.Repository
{
    public class StudentRepository : IStudent
    {
        public List<StudentModel> DataSource()
        {
            return  new List<StudentModel>()
            {
                new StudentModel() {Name="ishan",Id=1},
                new StudentModel() {Name="ishan2",Id=2}
            };
        }
        public List<StudentModel> getAllStudent()
        {
            
            return DataSource();
        }

        public StudentModel getStudentById(int id)
        {
            return DataSource().Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
