using Movie_Worker.Entities;

namespace Movie_Worker.Repository.Abstract
{
    public interface IMovieRepository
    {
        Task<IEnumerable<Movie>> GetAllAsync();
        Task<Movie> GetByIdAsync(int id);
        Task AddAsync(Movie movie);
        Task UpdateAsync(Movie movie);
        Task DeleteAsync(Movie movie);
        Task SaveAsync();
        Task<Movie?> GetFilmByTitleAsync(string title);
    }
}
