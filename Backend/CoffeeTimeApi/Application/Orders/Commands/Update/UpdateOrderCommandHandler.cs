using Application.Common.Exceptions;
using Application.Interfaces;
using Application.Models.Update;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Orders.Commands.Update
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderModel>
    {
        private readonly IOrderDbContext context;
        public UpdateOrderCommandHandler(IOrderDbContext context)
        {
            this.context = context;
        }

        public async Task Handle(UpdateOrderModel request, CancellationToken cancellationToken)
        {
            var entity = await context.Orders.FirstOrDefaultAsync(o => o.Id == request.Id, cancellationToken);

            if (entity == null)
                throw new OrderNotFoundException("Order is not found.");

            entity.Update = DateTime.Now;
            entity.Status = request.Status;

            await context.SaveChangesAsync(cancellationToken);
        }
    }
}
