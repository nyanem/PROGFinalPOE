namespace PROGFinalPOE.Models
{
    public class Claims
    {
        public int ClaimsId { get; set; }
        public int LecturerID { get; set; }
        public DateTime LecturerDescription { get; set;}
        public decimal hoursWorked { get; set; }
        public decimal hourlyRate { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; }

        public string supportingDocument { get; internal set; }

    }
}
