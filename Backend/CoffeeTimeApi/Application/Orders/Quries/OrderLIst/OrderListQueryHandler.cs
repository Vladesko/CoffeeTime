using Application.Interfaces;
using Application.Models.Queries.GetOrder.GetListOrders;
using Application.Models.Queries.GetOrder.ListOrders;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Orders.Quries.OrderLIst
{
    public class OrderListQueryHandler : IRequestHandler<ListOrderModel, List<OrderViewModel>>
    {
        private readonly IOrderDbContext context;
        private readonly IMapper mapper;
        public OrderListQueryHandler(IOrderDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<List<OrderViewModel>> Handle(ListOrderModel request, CancellationToken cancellationToken)
        {
            var orders = await context.Orders.
                ProjectTo<OrderViewModel>(mapper.ConfigurationProvider).
                ToListAsync(cancellationToken);

            return orders;
        }
    }
}
