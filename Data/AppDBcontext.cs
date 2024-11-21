using Microsoft.EntityFrameworkCore;
using PROGFinalPOE.Models;
namespace PROGFinalPOE.Data
{
    public class AppDBcontext : DbContext
    {
        public AppDBcontext(DbContextOptions<AppDBcontext> options) : base(options) { }
        DbSet <Claims> claims { get; set; }
        DbSet<Lecturer> Lecturers { get; set; }
        DbSet<Manager> Managers { get; set; }
    }
}
