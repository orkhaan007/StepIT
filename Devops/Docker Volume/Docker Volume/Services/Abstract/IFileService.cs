namespace Docker_Volume.Services.Abstract
{
    public interface IFileService
    {
        Task<string> GetInfoAsync(string filePath);
        Task AppendInfoAsync(string filePath,string data);
    }
}
