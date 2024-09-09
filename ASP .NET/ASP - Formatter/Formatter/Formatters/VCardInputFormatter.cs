using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using System.Text;
using Formatter.Dtos;

namespace Formatter.Formatters
{
    public class VCardInputFormatter : TextInputFormatter
    {
        public VCardInputFormatter()
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/vcard"));
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

            var student = new StudentAddDto();

            try
            {
                line = await ReadLineAsync("BEGIN:VCARD", reader, context);

                line = await ReadLineAsync("FN:", reader, context);
                student.Fullname = line.Substring(3);

                line = await ReadLineAsync("SNO:", reader, context);
                student.SeriaNo = line.Substring(4);

                line = await ReadLineAsync("AGE:", reader, context);
                student.Age = int.Parse(line.Substring(4));

                line = await ReadLineAsync("SCORE:", reader, context);
                student.Score = double.Parse(line.Substring(6));

                await ReadLineAsync("END:VCARD", reader, context);

                return await InputFormatterResult.SuccessAsync(student);
            }
            catch
            {
                return await InputFormatterResult.FailureAsync();
            }
        }

        private static async Task<string> ReadLineAsync(
            string expectedText, StreamReader reader, InputFormatterContext context)
        {
            var line = await reader.ReadLineAsync();

            if (line is null || !line.StartsWith(expectedText))
            {
                var errorMessage = $"Looked for '{expectedText}' and got '{line}'";

                context.ModelState.TryAddModelError(context.ModelName, errorMessage);

                throw new Exception(errorMessage);
            }

            return line;
        }
    }
}
