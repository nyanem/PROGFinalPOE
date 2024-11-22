using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PROGFinalPOE.Data;
using PROGFinalPOE.Models;
using System.Linq.Expressions;



namespace PROGFinalPOE.Controllers
{
    public class LecturerController : Controller
    {
        private readonly AppDBcontext _context;

        public LecturerController(AppDBcontext context)
        {
            _context = context;
        }

        // This will return the claim submissions form view
        [HttpGet]
        public IActionResult SubmitClaim() {
            return View();
        }

        // Logic it for validating the file submissions and then upload them to the database
        [HttpPost]
        public IActionResult SubmitClaim(Claims claims, IFormFile supportingDoc)
        {
            // this will calculate the total amount that is owed to the lecturers
            claims.TotalAmount = claims.hoursWorked * claims.hourlyRate;
            claims.claimDate = DateTime.Now;
            claims.Status = "Pending";

            //Handle Document upload

            if (supportingDoc != null && supportingDoc.Length > 0)
            {
                var filePath = Path.Combine("wwwroot/documents", supportingDoc.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    supportingDoc.CopyTo(stream);
                }
                claims.supportingDocument = filePath;
            }

            //Saving the claim to the database
            _context.claims.Add(claims);
            _context.SaveChanges();

            return RedirectToAction("Success");
        }

        
    }
}
        
           
     

        
  