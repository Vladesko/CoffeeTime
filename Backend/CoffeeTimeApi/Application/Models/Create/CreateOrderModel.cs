using MediatR;
using Microsoft.AspNetCore.Http.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Create
{
    public class CreateOrderModel : IRequest<Guid>
    {
        public string Name { get; set; } = string.Empty;
        public string Person { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Phone { get; set; } = string.Empty;
    }
}
