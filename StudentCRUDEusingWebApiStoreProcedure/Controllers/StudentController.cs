using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentCRUDEusingWebApiStoreProcedure.Model;
using StudentCRUDEusingWebApiStoreProcedure.Repository.Interface;

namespace StudentCRUDEusingWebApiStoreProcedure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _studRepo;
        public StudentController(IStudentRepository studRepo)
        {
            _studRepo = studRepo;
        }  
        [HttpGet]   
        public async Task<IActionResult> GetAllStudents()
        {
            var result=await _studRepo.GetAllStudents();
            return Ok(result);

        }
        [HttpGet("/All")]
        public async Task<IActionResult> GetAllStudentesD()
        {
            var result = await _studRepo.GetAllStudentsD();
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> AddNewStudents(Student student)
        {
            var result = await _studRepo.AddNewStudent(student);
            return Ok(result);
        }
        [HttpGet("/Search")]
        public async Task<IActionResult> SearchStudd(string search)
        {
            var result = await _studRepo.SearchStudents(search);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateStudent(Student student)
        {
            var result=await _studRepo.UpdateStudent(student);
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteStudd(Student student,int srNo)
        {
            var result=await _studRepo.DeteteSudent(student,srNo);
            return Ok(result);
        }
    }
}
