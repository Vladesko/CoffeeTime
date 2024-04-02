using Application.Models.Update;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Validation.Command.Update
{
    public class BaseUpdateOrderValidator : AbstractValidator<UpdateOrderModel>
    {
        public BaseUpdateOrderValidator()
        {
            RuleFor(order => order.Id).NotEqual(Guid.Empty);
            RuleFor(order => order.Status).IsInEnum();
        }
    }
}
