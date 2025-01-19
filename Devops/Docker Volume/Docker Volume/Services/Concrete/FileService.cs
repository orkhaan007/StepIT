using Docker_Volume.Services.Abstract;

namespace Docker_Volume.Services.Concrete
{
    public class FileService : IFileService
    {
        public async Task AppendInfoAsync(string filePath, string data)
        {
            await File.AppendAllTextAsync(filePath, data);
        }

        public async Task<string> GetInfoAsync(string filePath)
        {
           var info = await File.ReadAllTextAsync(filePath);
           return info;
        }
    }
}
