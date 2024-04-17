using App.Comon.Exceptions;
using App.Interfaces;
using DomainApp.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Comon.Validations
{
    public class UserValidator(IValidator<RegistrationViewModel> validator) : IUserValidator
    {
        private readonly IValidator<RegistrationViewModel> validator = validator;
        public void Validate(RegistrationViewModel model)
        {
            var result = validator.Validate(model);

            if(result.IsValid == false)
            {
                foreach(var error in result.Errors)
                {
                    throw new CustomValidationException(error.ErrorMessage);
                }
            }
        }
    }
}
