using Application.Models.Queries.GetOrder.GetOrder;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Validation.Query.GetDetailsOrder
{
    public class BaseDetailsOrderValidator : AbstractValidator<OrderDetailsModel>
    {
        public BaseDetailsOrderValidator()
        {
            RuleFor(model => model.Id).NotEqual(Guid.Empty);
        }
    }
}
