using DomainApp.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Comon.Validations
{
    public class RegistrationValidator : AbstractValidator<RegistrationViewModel>
    {
        public RegistrationValidator()
        {
            RuleFor(model => model.UserName).NotEmpty().
                    MaximumLength(50).WithMessage("Your name is so long").
                    MinimumLength(2).WithMessage("Your name is so short");
            RuleFor(model => model.Email).EmailAddress().WithMessage("Your Email is not current");
            RuleFor(model => model.NumberPhone).Must(IsNumber).Length(13).WithMessage("Your number of phone is not current");


        }

        /// <summary>
        /// Checking number without latters
        /// </summary>
        /// <param name="number">Number to be without latters</param>
        /// <returns>If number haven`t latters that be true</returns>
        protected static bool IsNumber(string number)
        {
            int countOfMistakes = 0;
            if (number[0].ToString() != "+")
                return false;

            char[] values = ['0', '1', '2', '3', '4', '5', '6', '7', '8', '9'];

            for (int i = 1; i < number.Length; i++)
            {
                countOfMistakes++;
                for (int j = 0; j < values.Length; j++)
                {
                    if (number[i] == values[j])
                    {
                        countOfMistakes--;
                        break;
                    }
                }
                if (countOfMistakes == 1)
                    return false;
            }

            return true;
        }
    }
}
