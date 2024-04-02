using Application.Models.Queries.GetOrder.ListOrders;
using MediatR;

namespace Application.Models.Queries.GetOrder.GetListOrders
{
    public class ListOrderModel : IRequest<List<OrderViewModel>>
    {
        
    }
}
