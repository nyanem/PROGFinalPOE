using Microsoft.EntityFrameworkCore;
using PROGFinalPOE.Models;
namespace PROGFinalPOE.Data
{
    public class AppDBcontext : DbContext
    {
        public AppDBcontext(DbContextOptions<AppDBcontext> options) : base(options) { }
        public DbSet <Claims> claims { get; set; }
        public  DbSet<Lecturer> Lecturers { get; set; }
        public  DbSet<Manager> Managers { get; set; }
    }
}
