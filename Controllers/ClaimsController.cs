﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PROGFinalPOE.Data;
using PROGFinalPOE.Models;
using System.Linq.Expressions;



namespace PROGFinalPOE.Controllers
{
    public class ClaimsController : Controller
    {
        private readonly AppDBcontext _context;
        private byte[] reportBytes;

        public ClaimsController(AppDBcontext context)
        {
            _context = context;
        }

        // This will return the claim submissions form view
        [HttpGet]
        public IActionResult SubmitClaim()
        {
            return View();
        }

        // Logic it for validating the file submissions and then upload them to the database
        [HttpPost]
        public IActionResult SubmitClaim(Claims claims)
        {
            if (ModelState.IsValid)
            {
                // Automatically calculate total amount
                claims.TotalAmount = claims.hoursWorked * claims.hourlyRate;
                claims.claimDate = DateTime.Now;
                claims.Status = "Pending";

                // Save claim to the database
                _context.claims.Add(claims);
                _context.SaveChanges();

                return RedirectToAction("Success");
            }
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


    }
}

        
           
     

        
  