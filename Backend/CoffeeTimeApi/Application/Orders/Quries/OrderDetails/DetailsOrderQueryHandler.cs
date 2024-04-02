using Application.Common.Exceptions;
using Application.Interfaces;
using Application.Models.Queries.GetOrder.GetOrder;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Orders.Quries.OrderDetails
{
    public class DetailsOrderQueryHandler : IRequestHandler<OrderDetailsModel, OrderDetailsViewModel>
    {
        private readonly IOrderDbContext context;
        private readonly IMapper mapper;
        public DetailsOrderQueryHandler(IOrderDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<OrderDetailsViewModel> Handle(OrderDetailsModel request, CancellationToken cancellationToken)
        {
            var order = await context.Orders.FirstOrDefaultAsync(o => o.Id == request.Id, cancellationToken);

            if (order == null)
                throw new OrderNotFoundException(@$"Order with Id ""{request.Id}"" not found");

            return mapper.Map<OrderDetailsViewModel>(order);
        }
    }
}
