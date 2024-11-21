using System.ComponentModel.DataAnnotations;

namespace PROGFinalPOE.Models
{
    public class Manager
    {
        [Key]
        public int ManagerId { get; set; }
        public int ManagerName { get; set; }
        public string ManagerPassword { get; set; }
        public string MangerEmail {  get; set; }
    }
}
