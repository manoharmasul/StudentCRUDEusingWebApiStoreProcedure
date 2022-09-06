using StudentCRUDEusingWebApiStoreProcedure.Model;

namespace StudentCRUDEusingWebApiStoreProcedure.Repository.Interface
{
    public interface IStudentRepository
    {
        public Task<IEnumerable<Student>> GetAllStudents();
        public Task<List<Student>> GetAllStudentsD();
        public Task<List<Student>> SearchStudents(string search);
        public Task<int> AddNewStudent(Student student);   
        public Task<int> UpdateStudent(Student student);    
        public Task<int> DeteteSudent(Student student , int srNO); 

    }
}
