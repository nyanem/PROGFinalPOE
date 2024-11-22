using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace PROGFinalPOE.Models
{
    public class Claims
    {
        public int ClaimsId { get; set; }
        public int LecturerID { get; set; }
        public DateTime claimDate { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Hours Worked must be greater than 0.")]
        public int HoursWorked { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Hourly Rate must be greater than 0.")]
        public decimal HourlyRate { get; set; }

        public decimal TotalAmount { get; set; }
        public string Status { get; set; }

        public string supportingDocument { get; internal set; }
  
    }
}
