using Application.Models.Create;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Validation.Command.Create
{
    public class BaseCreateOrderValidator : AbstractValidator<CreateOrderModel>
    {
        public BaseCreateOrderValidator()
        {
            RuleFor(order => order.Name).NotEmpty().MaximumLength(30).MinimumLength(2).Must(WithoutNumbers);
            RuleFor(order => order.Price).NotEmpty();
            RuleFor(order => order.Person).NotEmpty().MaximumLength(40).MinimumLength(2).Must(WithoutNumbers).WithMessage("Your name is uncorrect");
            RuleFor(order => order.Phone).NotEmpty().Length(13).Must(IsNumber).WithMessage("Your number must haven`t letters or other symbols");
        }
        /// <summary>
        /// Checking the name to make sure it is without numbers
        /// </summary>
        /// <param name="name">Name to be without numbers</param>
        /// <returns>If name haven`t numbers that be true</returns>
        protected bool WithoutNumbers(string name)
        {
            char[] numbers = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

            for (int i = 0; i < name.Length; i++)
            {
                for (int j = 0; j < numbers.Length; j++)
                {
                    if (name[i] == numbers[j])
                        return false;
                }
            }

            return true;
        }
        /// <summary>
        /// Checking number without latters
        /// </summary>
        /// <param name="number">Number to be without latters</param>
        /// <returns>If number haven`t latters that be true</returns>
        protected bool IsNumber(string number)
        {
            int countOfMistakes = 0;
            if (number[0].ToString() != "+")
                return false;

            char[] values = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

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
