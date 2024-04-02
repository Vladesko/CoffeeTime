using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Behaviors
{
    public class ValidationBehavior<TRequest, TResponce> : IPipelineBehavior<TRequest, TResponce>
            where TRequest : IRequest<TResponce>
    {
        private readonly IEnumerable<IValidator<TRequest>> validators;
        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            this.validators = validators;
        }
        public Task<TResponce> Handle(TRequest request, RequestHandlerDelegate<TResponce> next, CancellationToken cancellationToken)
        {
            var context = new ValidationContext<TRequest>(request);
            var failures = validators.
                Select(v => v.Validate(context)).
                SelectMany(result => result.Errors).
                Where(failure => failure != null).
                ToList();           

            if (failures.Count != 0)
                throw new ValidationException(failures);

            return next();
        }
    }
}
