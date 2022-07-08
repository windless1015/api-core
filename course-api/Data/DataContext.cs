using Microsoft.EntityFrameworkCore;
using course_api.Models;

namespace course_api.Data
{
    public class DataContext : DbContext 
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {}

        public DbSet<Course> Courses {get; set;}
        public DbSet<Category> Categories {get; set;}
    }
}
