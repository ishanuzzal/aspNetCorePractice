using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace WebApplication2.Models
{
    public class StudentDbContexts:DbContext
    {
        public StudentDbContexts()
        {
            
        }
        public StudentDbContexts(DbContextOptions op) : base(op)
        {
            
        }

        public DbSet<StudentModel> Students { get; set; }
        /* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
         {
             optionsBuilder.UseSqlServer("Server=127.0.0.1;Database=SchoolDB;Trusted_Connection=True;");
         }*/

    }
}
