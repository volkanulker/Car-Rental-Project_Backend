using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            // TODO: Add Car Validation Rules
            
            RuleFor(c => c.ModelYear).NotEmpty().WithMessage("Model year can not be empty.");
            RuleFor(c => c.Name).NotEmpty().WithMessage("Model year can not be empty.");
            // TODO If brandid and colorid deleted fix these codes
            RuleFor(c => c.BrandId).NotEmpty().WithMessage("Brand Id can not be empty.");
            RuleFor(c => c.ColorId).NotEmpty().WithMessage("Color Id can not be empty.");
            RuleFor(c => c.DailyPrice).NotEmpty().WithMessage("Daily Price can not be empty.");
            RuleFor(c => c.DailyPrice).GreaterThan(0).WithMessage("Daily price must be greater than 0");

            // Amazing Usage                                                                 
            //RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(10).When(p => p.CategoryId == 1)
            // Create new rule
            //RuleFor(p => p.ProductName).Must(StartWithA);


        }
        // NEW RULE
        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
