namespace Domain
{
    public class Order
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Person { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Phone { get; set; } = string.Empty;
        public DateTime Create { get; set; }
        public DateTime? Update { get; set; }
        public Status Status { get; set; }
    }
    
}
