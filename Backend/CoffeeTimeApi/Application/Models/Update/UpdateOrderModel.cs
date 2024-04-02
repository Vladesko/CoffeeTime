using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Update
{
    public class UpdateOrderModel : IRequest
    {
        public Guid Id { get; set; }
        public Status Status { get; set; }
    }
}
