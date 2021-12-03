using Core.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules
{
    public class UserValidator: AbstractValidator<User>
    {
        public UserValidator()
        {
            // TODO: Add User Validation Rules

        }
    }
}
