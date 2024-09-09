using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using System.Text;
using Formatter.Dtos;

namespace Formatter.Formatters
{
    public class TextCsvInputFormatter : TextInputFormatter
    {
        public TextCsvInputFormatter()
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/csv"));
            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);
        }

        protected override bool CanReadType(Type type)
            => type == typeof(StudentAddDto);

        public override async Task<InputFormatterResult> ReadRequestBodyAsync(
            InputFormatterContext context, Encoding effectiveEncoding)
        {
            var httpContext = context.HttpContext;

            using var reader = new StreamReader(httpContext.Request.Body, effectiveEncoding);
            string? line;

            try
            {
                line = await reader.ReadLineAsync();
                var fields = line.Split('-');

                if (fields.Length != 5)
                {
                    throw new Exception("Invalid CSV format");
                }

                var student = new StudentAddDto
                {
                    Fullname = fields[1].Trim(),
                    SeriaNo = fields[2].Trim(),
                    Age = int.Parse(fields[3].Trim()),
                    Score = double.Parse(fields[4].Trim())
                };

                return await InputFormatterResult.SuccessAsync(student);
            }
            catch
            {
                return await InputFormatterResult.FailureAsync();
            }
        }
    }
}