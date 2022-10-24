namespace BeSpoked_Bikes.Models
{
    public class Sales
    {
        public int Id { get; set; }
        public Product product { get; set; }
        public SalesPerson person { get; set; }
        public Customer customer { get  ; set; }
        public DateTime SaleDate { get; set; }
    }
}
