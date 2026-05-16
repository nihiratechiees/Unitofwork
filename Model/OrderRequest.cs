namespace Unitofwork.Model
{
    public class OrderRequest
    {
        public string CustomerId { get; set; }
        public List<Items> Items { get; set; }
    }

    public class Items
    {
        public string ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
