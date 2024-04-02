using Application.Common.Exceptions;
using Application.Interfaces;
using Application.Models.Delete;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Orders.Commands.Delete
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderModel>
    {
        private readonly IOrderDbContext context;
        public DeleteOrderCommandHandler(IOrderDbContext context)
        {
            this.context = context;
        }
        public async Task Handle(DeleteOrderModel request, CancellationToken cancellationToken)
        {
            var entity = await context.Orders.FirstOrDefaultAsync(o => o.Id == request.Id, cancellationToken);

            if (entity == null)
                throw new OrderNotFoundException("Order is not found.");

            context.Orders.Remove(entity);
            await context.SaveChangesAsync(cancellationToken);
        }
    }
}
