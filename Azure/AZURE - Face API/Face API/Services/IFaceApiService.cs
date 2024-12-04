namespace Face_API.Services
{
    public interface IFaceApiService
    {
        Task<string> DetectFacesAsync(string imageUrl);
    }
}
