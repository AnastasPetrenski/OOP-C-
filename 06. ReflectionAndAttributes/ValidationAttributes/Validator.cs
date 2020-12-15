namespace ValidationAttributes
{
    public static class Validator
    {
        public static bool IsValid(Person person)
        {
            var properties = person.GetType().GetProperties();
            foreach (var propertie in properties)
            {
                var attributies = propertie.GetCustomAttributes(true);
                if(propertie.Name == "FullName" && attributies.Length == 0)
                {
                    return false;
                }
                                
                //var currentValue = propertie.GetValue(person);
                foreach (MyValidationAttribute attr in attributies)
                {
                    var isValid = attr.IsValid(person);

                    if (!isValid)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
