using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomValidator
{
    public class ValidationResult
    {
        public ValidationResult()
        {
            this.Error = new Dictionary<string, string>();
        }

        public bool IsValid => !this.Error.Any();

        public IDictionary<string, string> Error { get; }
    }
}
