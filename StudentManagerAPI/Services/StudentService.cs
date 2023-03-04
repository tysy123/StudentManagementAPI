using StudentManagerAPI.Enum;
using StudentManagerAPI.Interfaces;
using StudentManagerAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagerAPI.Services
{
    public class StudentService : IStudentService
    {
        private readonly AppSettings _appSettings;
        private readonly StudentDBcontext _context;
        public StudentService(AppSettings appSettings, StudentDBcontext context)
        {
            _appSettings = appSettings;
            _context = context;
        }

        public Task<List<StudentModel>> GetStudents()
        {
            var rs = _context.Students.ToList();
            return Task.FromResult(rs);
        }

        public Task<StudentModel> GetStudentById(int id)
        {
            var rs = _context.Students.Where(x => x.Id == id).FirstOrDefault();
            return Task.FromResult(rs);
        }
        public Task<List<StudentModel>> GetStudentByFiter(StudentFilterModel filter)
        {
            var rs = new List<StudentModel>();
            switch(filter.FilterType)
            {
                case FilterEnum.Name:
                    rs = _context.Students.Where(x => x.Name == filter.KeyWord).ToList();                    
                    break;
                case FilterEnum.PhoneNumber:
                    rs = _context.Students.Where(x => x.PhoneNumber == filter.KeyWord).ToList();
                    break;
                case FilterEnum.ID:
                    rs = _context.Students.Where(x => x.Id == Convert.ToInt32(filter.KeyWord)).ToList();
                    break;
            };
            return Task.FromResult(rs);
        }
    }
}
