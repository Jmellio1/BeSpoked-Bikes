using System.ComponentModel.DataAnnotations;

namespace BeSpoked_Bikes.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string fName { get; set; }
        public string  lname { get; set; }
        public string address { get; set; }
        public DateTime sdate { get; set; }
        [Phone]
        [StringLength(14, ErrorMessage = "enter number in X-XXX-XXX-XXXX format")]
        [MinLength(14, ErrorMessage = "enter number in X-XXX-XXX-XXXX format")]
        public string number { get; set; }
    }
}
