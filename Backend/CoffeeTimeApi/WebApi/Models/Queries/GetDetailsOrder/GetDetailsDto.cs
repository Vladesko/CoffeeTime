using Application.Models.Queries.GetOrder.GetOrder;
using Domain;

namespace WebApi.Models.Queries.GetDetailsOrder
{
    public class GetDetailsDto
    {
        public string Name { get; set; } = string.Empty;
        public string Person { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Phone { get; set; } = string.Empty;
        public Status Status { get; set; }

        public DateTime Create { get; set; }
        public DateTime? Update { get; set; }

    }
}
