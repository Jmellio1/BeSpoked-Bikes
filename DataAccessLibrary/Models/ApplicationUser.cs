using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace BeSpoked_Bikes.Models
{
    public class ApplicationUser : IdentityUser
    {

        [Required]
        [StringLength(25, ErrorMessage = "First name is too long")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(25, ErrorMessage = "Last name is too long")]
        public string LastName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [Phone]
        [StringLength(14, ErrorMessage = "enter number in X-XXX-XXX-XXXX format")]
        [MinLength(14, ErrorMessage = "enter number in X-XXX-XXX-XXXX format")]
        public string phone { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        [Required]
        public bool Manager { get; set; }

    }
    
}
