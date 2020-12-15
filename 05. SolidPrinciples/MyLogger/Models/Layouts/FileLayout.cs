using System.Text;

using MyLogger.Models.Contracts;

namespace MyLogger.Models.Layouts
{
    public class FileLayout : ILayout
    {
        public string Format => this.GetFormat();

        private string GetFormat()
        {
            var sb = new StringBuilder();
            sb
                .AppendLine("<log>")
                    .AppendLine("<date>{0}</date>")
                    .AppendLine("<level>{1}</level>")
                    .AppendLine("<message>{2}</message>")
                .AppendLine("</log>");

            return sb.ToString().TrimEnd();
        }
    }
}
