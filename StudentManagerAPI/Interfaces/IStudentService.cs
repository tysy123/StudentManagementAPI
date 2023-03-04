using StudentManagerAPI.Enum;
using StudentManagerAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagerAPI.Interfaces
{
    public interface IStudentService
    {
        Task<List<StudentModel>> GetStudents();
        Task<StudentModel> GetStudentById(int id);  
        Task<List<StudentModel>> GetStudentByFiter(StudentFilterModel model);
    }
}
