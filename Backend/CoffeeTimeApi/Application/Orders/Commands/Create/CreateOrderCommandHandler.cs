using Application.Interfaces;
using Application.Models.Create;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Orders.Commands.Create
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderModel, Guid>
    {
        private readonly IOrderDbContext context;
        public CreateOrderCommandHandler(IOrderDbContext context)
        {
            this.context = context;
        }
        public async Task<Guid> Handle(CreateOrderModel request, CancellationToken cancellationToken)
        {
            Order order = new Order()
            {
                Id = Guid.NewGuid(),
                Person = request.Person,
                Name = request.Name,
                Price = request.Price,
                Phone = request.Phone,
                Create = DateTime.Now,
                Status = Status.NotReady,
                Update = null,
            };

            await context.Orders.AddAsync(order, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);

            return order.Id;
        }
    }
}
