using System;
using System.Collections.Generic;
using System.Text;

namespace CustomValidator
{
    public interface IValidatable
    {
        IDictionary<string, List<string>> Validate();
    }
}
