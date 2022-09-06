using Dapper;
using StudentCRUDEusingWebApiStoreProcedure.Context;
using StudentCRUDEusingWebApiStoreProcedure.Model;
using StudentCRUDEusingWebApiStoreProcedure.Repository.Interface;
using System.Data;

namespace StudentCRUDEusingWebApiStoreProcedure.Repository
{
    public class StudentRepository: IStudentRepository

    {
        private readonly DapperContext _context;
        public StudentRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<int> AddNewStudent(Student student)
        {
            var procName = "spaddnewStudnts";
            using(var connection=_context.CreateConnection())
            {
                var parameter = new DynamicParameters();
                //sName,smobileNo,batch,marks,grade
                parameter.Add("sName", student.sName, DbType.String);
                parameter.Add("smobileNo", student.smobileNo, DbType.String);
                parameter.Add("batch", student.batch, DbType.String);
                parameter.Add("marks", student.marks, DbType.Double);
                parameter.Add("grade", student.grade, DbType.String);

                var newstudd = await connection.ExecuteAsync(procName, parameter, commandType: CommandType.StoredProcedure);
                return newstudd;

            }
        }

        public async Task<int> DeteteSudent(Student student ,int srNo)
        {
            
            var procName = "spdeleteStudd";
            var parameter = new DynamicParameters();
            parameter.Add("srNo",student.srNo=srNo, DbType.Int32);
            parameter.Add("isDeleted",student.isDeleted=1, DbType.Int32); 
            using(var connection=_context.CreateConnection())
            {
                var delstudd = await connection.ExecuteAsync(procName, parameter, commandType: CommandType.StoredProcedure);
                return delstudd;
            }
        }

        public async Task<IEnumerable<Student>> GetAllStudents()
        {
            var procName = "spSelect";
            //var parameters = new DynamicParameters();
            // parameter.Add("flag")
            using (var connection=_context.CreateConnection())
            {
                var students = await connection.QueryAsync<Student>(procName, commandType: CommandType.StoredProcedure);
                return students.ToList();
            }
        }

        public async Task<List<Student>> GetAllStudentsD()
        {
            var procName = "spselectAll";
            using(var connection=_context.CreateConnection())
            {
                var allstude = await connection.QueryAsync<Student>(procName, commandType: CommandType.StoredProcedure);
                return allstude.ToList();    
            }
        }

        public async Task<List<Student>> SearchStudents(string search)
        {
           

            var procName = "spsearchStudd";
            var parameter = new DynamicParameters();
            parameter.Add("searchTextt", search, DbType.String);
           parameter.Add("searchTextt", search, DbType.String);
            using (var connection=_context.CreateConnection())
            {
                var studd = await connection.QueryAsync<Student>(procName, parameter, commandType: CommandType.StoredProcedure);
                return studd.ToList();
            }
        }

        public async Task<int> UpdateStudent(Student student)
        {
            var procName = "spupdateStudd";
            var parameter=new DynamicParameters();
            parameter.Add("srNo", student.srNo, DbType.Int32);
            parameter.Add("sName",student.sName,DbType.String);
            parameter.Add("smobileNo", student.smobileNo, DbType.String);
            parameter.Add("batch", student.batch, DbType.String);
            parameter.Add("marks",student.marks,DbType.Double);
            parameter.Add("grade", student.grade, DbType.String);
            using(var connection=_context.CreateConnection())
            {
                var studentt=await connection.ExecuteAsync(procName, parameter, commandType: CommandType.StoredProcedure);
                return studentt;

            }

        }
        
    }
}
