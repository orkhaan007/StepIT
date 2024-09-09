using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using System.Text;
using Formatter.Dtos;

namespace Formatter.Formatters
{
    public class TextCsvOutputFormatter : TextOutputFormatter
    {
        public TextCsvOutputFormatter()
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/csv"));
            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);
        }

        public override async Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
        {
            var response = context.HttpContext.Response;
            var sb = new StringBuilder();

            if (context.Object is IEnumerable<StudentDto> list)
            {
                foreach (var item in list)
                {
                    FormatCsv(sb, item);
                }
            }
            else if (context.Object is StudentDto student)
            {
                FormatCsv(sb, student);
            }

            await response.WriteAsync(sb.ToString());
        }

        private void FormatCsv(StringBuilder sb, StudentDto item)
        {
            sb.AppendLine($"{item.Id}-{item.Fullname}-{item.SeriaNo}-{item.Age}-{item.Score}");
        }
    }
}
