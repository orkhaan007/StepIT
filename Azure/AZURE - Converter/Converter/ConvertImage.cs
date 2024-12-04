using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System.Drawing;
using System.Drawing.Imaging;

namespace Converter
{
    public static class ConvertImage
    {
        [FunctionName("ConvertImage")]
        public static void Run(
            [BlobTrigger("images-original/{name}", Connection = "AzureWebJobsStorage")] Stream inputBlob,
            string name,
            [Blob("images/{name}.jpeg", FileAccess.Write, Connection = "AzureWebJobsStorage")] Stream outputBlob,
            ILogger log)
        {
            log.LogInformation($"Processing blob: {name}");

            try
            {
                using (var image = Image.FromStream(inputBlob))
                {
                    image.Save(outputBlob, ImageFormat.Jpeg);
                }

                log.LogInformation($"Converted {name} to JPEG.");
            }
            catch (System.Exception ex)
            {
                log.LogError($"Error converting image {name}: {ex.Message}");
            }
        }
    }
}
