using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PROGFinalPOE.Models;
namespace PROGFinalPOE.Data
{
    public class AppDBcontext : IdentityDbContext<IdentityUser>
    {
        public AppDBcontext(DbContextOptions<AppDBcontext> options) : base(options) { }
        public DbSet <Claims> claims { get; set; }
        public  DbSet<Lecturer> Lecturers { get; set; }
        public  DbSet<Manager> Managers { get; set; }
    }
}
