using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            // if type of validator is not a validator type throw exception
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception("It is not a confirmation class.");
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            // Reflection
            // Create instance of validator
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            // Find type of validator
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            // Find parameters of method
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);
            // Traverse each item and validate with Validation Tool
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
