using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Queries.GetOrder.GetOrder
{
    public class OrderDetailsModel : IRequest<OrderDetailsViewModel>
    {
        public Guid Id { get; set; }
    }
}
