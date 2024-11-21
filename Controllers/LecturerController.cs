using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PROGFinalPOE.Data;
using PROGFinalPOE.Models;



namespace ST10026525.PROG62112.POE.part1.Controllers
{
    public class LecturerController : Controller
    {
        private readonly AppDBcontext _context;

        public LecturerController(AppDBcontext context)
        {
            _context = context;
        }

        // Logic it for validating the file submissions and then upload them to the database
        [HttpPost]
        public async Task<IActionResult> SubmitClaim(int hoursWorked, decimal hourlyRate, string notes, IFormFile supportingDoc)
        {
            if (supportingDoc != null && supportingDoc.Length > 0)
            {
                if (supportingDoc.Length > 10485760) // 10MB limit
                {
                    ModelState.AddModelError("", "File size should be less than 10MB");
                }

                var allowedExtensions = new[] { ".pdf", ".docx", ".xlsx" };
                var fileExtension = Path.GetExtension(supportingDoc.FileName).ToLower();
                if (!allowedExtensions.Contains(fileExtension))
                {
                    ModelState.AddModelError("", "Invalid file type. Only .pdf, .docx, and .xlsx are allowed.");
                }

                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwwroot/uploads", supportingDoc.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await supportingDoc.CopyToAsync(stream);
                }
                var totalAmount = hoursWorked * hourlyRate;

                var claim = new Claims
                {
                    hoursWorked = hoursWorked,
                    hourlyRate = (int)hourlyRate,
                    TotalAmount = totalAmount,
                    supportingDocument = supportingDoc.FileName,
                    Status = "Pending",
                    claimDate = DateTime.Now
                };

                _context.claims.Add(claim);
                await _context.SaveChangesAsync();
            }

            //Add code to  Save the claim details to the databse 

            return RedirectToAction("Privacy");
        }
        public IActionResult Privacy()
        {
            var claims = _context.claims.ToList();
            return View(claims);
        }
    }
}