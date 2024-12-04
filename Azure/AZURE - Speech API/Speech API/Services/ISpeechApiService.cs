namespace Speech_API.Services
{
    public interface ISpeechApiService
    {
        Task<string> RecognizeSpeechAsync(string audioFilePath);
    }
}
