using Logger.Models.Contracts;
using System;
using System.Text;

namespace Logger.Models.Layouts
{
    public class JsonLayout : ILayout
    {
        public string Format => this.GetFormat();

        public string GetFormat()
        {
            var sb = new StringBuilder();
            sb
                .AppendLine("[")
                .AppendLine("\tdate: {0},")
                .AppendLine("\tlevel: {1},")
                .AppendLine("\tmessage: {2}")
                .AppendLine("]");

            return sb.ToString().TrimEnd();
        }
    }
}
