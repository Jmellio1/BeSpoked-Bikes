namespace BeSpoked_Bikes.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public string Style { get; set; }
        public double purchasePrice { get; set; }
        public double SalePrice { get; set; }
        public int inventory { get; set; }
        public int commission { get; set; }
    }
}
