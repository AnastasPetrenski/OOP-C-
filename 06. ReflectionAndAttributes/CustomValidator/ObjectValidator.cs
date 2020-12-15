using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace CustomValidator
{
    public class ObjectValidator
    {
        public ValidationResult Validate(object obj)
        {
            if (obj == null)
            {
                var result = new ValidationResult();

                result.Error.Add("Object", "Object is null");

                return result;
            }

            var objType = obj.GetType();

            var properties = objType.GetProperties();

            var validationResult = new ValidationResult();

            foreach (var property in properties)
            {
                var propertyName = property.Name;
                var propertyValue = property.GetValue(obj);
                var attributes = property.GetCustomAttributes<ValidationAttribute>();

                foreach (var item in attributes)
                {
                    var isValid = item.IsValid(propertyValue);
                    if (!isValid)
                    {
                        var errorMessage = item.FormatErrorMessage(propertyName);

                        validationResult.Error.Add(propertyName, errorMessage);
                    }
                }

            }

            if (obj is IValidatable validatable)
            {
                var additionalErrors = validatable.Validate();

                foreach (var additionalError in additionalErrors)
                {
                    foreach (var additionalErrorValue in additionalError.Value)
                    {
                        validationResult.Error.Add(additionalError.Key, additionalErrorValue); 
                    }
                }
            }

            return validationResult;
        }
    }
}
