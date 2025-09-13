namespace OrderService.Models
{
    public class Order
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string price { get; set; }
        public int quantity { get; set; }
    }
}
