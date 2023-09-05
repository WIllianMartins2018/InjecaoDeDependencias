namespace DemoInjecaoDependencias.Models
{
    public class Order
    {
        public Order(
            decimal deliveryFee,
            decimal discount,
            decimal subTotal)
        {
            Code = Guid.NewGuid().ToString().ToUpper();
            Date = DateTime.Now;
            DeliveryFee = deliveryFee;
            SubTotal = subTotal;
            Discount = discount;
        }
        public string? Code { get; set; }
        public DateTime Date { get; set; }
        public decimal DeliveryFee { get; set; }
        public decimal Discount { get; set; }
        public List<Product>? Products { get; set; }
        public decimal SubTotal { get; set; }   
        public decimal Total => SubTotal - Discount + DeliveryFee;
    }
}
