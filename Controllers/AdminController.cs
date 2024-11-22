using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PROGFinalPOE.Data;
using PROGFinalPOE.Models;


namespace PROGFinalPOE.Controllers
{
    public class AdminController : Controller
    {
        private readonly AppDBcontext _context;

        public AdminController(AppDBcontext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Dashboard()
        {
            var claims = _context.claims.ToList();
            return View("AdminDashboard", claims);
        }


       //Approve a claim
        [HttpPost]
        public IActionResult ApproveClaim(int claimId)
        {
            var claim = _context.claims.FirstOrDefault(c => c.ClaimsId == claimId);
            if (claim != null)
            {
                claim.Status = "Approved";
                 _context.SaveChangesAsync();
            }
            return RedirectToAction("AdminDashboard");
        }

        //Reject Claim 
        [HttpPost]
        public IActionResult RejectClaim(int claimId)
        {
            var claim = _context.claims.FirstOrDefault(c => c.ClaimsId == claimId);
            if (claim != null)
            {
                claim.Status = "Rejected";
                _context.SaveChangesAsync();
            }
            return RedirectToAction("AdminDashboard");
        }
    }
}
