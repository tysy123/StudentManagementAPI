using StudentManagerAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagerAPI
{
    public static class DataSeeds
    {
        public static void Initialize(StudentDBcontext context)
        {
            context.Database.EnsureCreated();
            
            if (context.Students.Any())
            {
                return; 
            }

            var students = new StudentModel[]
            {
            new StudentModel{Name ="test1", PhoneNumber = "09135568467"},
            new StudentModel{Name ="test2", PhoneNumber = "09135568467"},
            new StudentModel{Name ="test3", PhoneNumber = "09135568467"},
            new StudentModel{Name ="test4", PhoneNumber = "09135568467"},
            new StudentModel{Name ="test5", PhoneNumber = "09135568467"},
            new StudentModel{Name ="test6", PhoneNumber = "09135568467"},
            new StudentModel{Name ="test7", PhoneNumber = "09135568467"},
            new StudentModel{Name ="test8", PhoneNumber = "09135568467"},
            new StudentModel{Name ="test9", PhoneNumber = "09135568467"},
            new StudentModel{Name ="test10", PhoneNumber = "09135568467"},
            new StudentModel{Name ="test11", PhoneNumber = "09135568467"},
          
            };
            foreach (StudentModel s in students)
            {
                context.Students.Add(s);
            }
            context.SaveChanges();

        }
    }
}
