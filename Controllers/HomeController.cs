using Microsoft.AspNetCore.Mvc;
using PROGFinalPOE.Models;
using PROGFinalPOE.Data;
using System.Diagnostics;

namespace PROGFinalPOE.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDBcontext _context;
        private byte[] reportBytes;

        public HomeController(ILogger<HomeController> logger, AppDBcontext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            int lecturerID = 1;
            var claims = _context.claims.Where (c => c.LecturerID == lecturerID).ToList();
            return View();
        }

        //Inserting admin dashboard to home controller
        public IActionResult AdminDashboard() 
        { 
            var claims= _context.claims.Where(c=> c.Status == "Pending").ToList();
            return View(claims);
        }
        public IActionResult ApprovedClaims()
        {
            var claims = _context.claims.Where(c => c.Status == "Approved").ToList();
            return View(claims);
        }

        public IActionResult GenerateReport()
        {
            var claims = _context.claims.Where(c => c.Status == "Approved").ToList();
            // Logic to generate a report (e.g., export to PDF or Excel)
            return File(reportBytes, "application/pdf", "ApprovedClaimsReport.pdf");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
