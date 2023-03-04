using Microsoft.EntityFrameworkCore;
using StudentManagerAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagerAPI
{
    public class StudentDBcontext : DbContext
    {
        public StudentDBcontext(DbContextOptions<StudentDBcontext> options) : base(options)
        {
        }

        public DbSet<StudentModel> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentModel>().ToTable("Students");           
        }
    }
}
