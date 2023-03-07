using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StudentManagerAPI.Enum;
using StudentManagerAPI.Interfaces;
using StudentManagerAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace StudentManagerAPI.Controllers
{
    [ApiController]
    [Authorize(Roles = "admin")]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly ILogger<StudentController> _logger;
        private readonly IStudentService _studentService;

        public StudentController(ILogger<StudentController> logger, IStudentService studentService)
        {
            _logger = logger;
            _studentService = studentService;
        }

        /// <summary>
        /// Get All students API
        /// </summary>
        /// <returns></returns>
        [HttpGet("get-students")]
        public async Task<IActionResult> GetStudents()
        {
            try
            {
                var data = await _studentService.GetStudents();
                if (data.Count() > 0)
                    return Ok(new HttpResultObject(data));
                else
                    return Ok(new HttpResultObject(HttpStatusCode.NotFound, HttpStatusCode.NotFound.ToString()));

            }
            catch (Exception ex)
            {
                return Ok(new HttpResultObject(HttpStatusCode.InternalServerError, HttpStatusCode.InternalServerError.ToString(), ex.StackTrace, ex.Message));
            }
        }
        /// <summary>
        /// Get student detail by ID API 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("get-student/{id}")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            try
            {
                var data = await _studentService.GetStudentById(id);
                if (data != null && data.Id > 0)
                    return Ok(new HttpResultObject(data));
                else
                    return Ok(new HttpResultObject(HttpStatusCode.NotFound, HttpStatusCode.NotFound.ToString()));

            }
            catch (Exception ex)
            {
                return Ok(new HttpResultObject(HttpStatusCode.InternalServerError, HttpStatusCode.InternalServerError.ToString(), ex.StackTrace, ex.Message));
            }
        }

        /// <summary>
        /// Filter student by name, phone number, ID number API
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("get-student-by-filter/{filter}/{keyword}")]
        public async Task<IActionResult> GetStudentByFiter(FilterEnum filter, string keyword)
        {
            try
            {
                var par = new StudentFilterModel()
                {
                    FilterType = filter,
                    KeyWord = keyword.Trim()
                };
                var data = await _studentService.GetStudentByFiter(par);
                if (data.Count() > 0)
                    return Ok(new HttpResultObject(data));
                else
                    return Ok(new HttpResultObject(HttpStatusCode.NotFound, HttpStatusCode.NotFound.ToString()));

            }
            catch (Exception ex)
            {
                return Ok(new HttpResultObject(HttpStatusCode.InternalServerError, HttpStatusCode.InternalServerError.ToString(), ex.StackTrace, ex.Message));
            }
        }
    }
}
