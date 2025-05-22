using EmailSender.MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace EmailSender.MVC.Data
{
    public class EmployeeDBContext : DbContext
    {
        public EmployeeDBContext(DbContextOptions<EmployeeDBContext> options) : base (options){ 
           
        }

        public DbSet<User> Users { get; set; }
    }
}
