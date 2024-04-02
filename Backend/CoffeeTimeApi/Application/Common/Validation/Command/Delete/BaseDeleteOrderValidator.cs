using Application.Models.Delete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Validation.Command.Delete
{
    public class BaseDeleteOrderValidator : AbstractValidator<DeleteOrderModel>
    {
        public BaseDeleteOrderValidator() 
        {
            RuleFor(order => order.Id).NotEqual(Guid.Empty);
        }
    }
}
