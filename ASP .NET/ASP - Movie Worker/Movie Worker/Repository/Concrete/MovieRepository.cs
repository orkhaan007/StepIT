using Microsoft.EntityFrameworkCore;
using Movie_Worker.Contexts;
using Movie_Worker.Entities;
using Movie_Worker.Repository.Abstract;
#nullable disable

namespace Movie_Worker.Repository.Concrete
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MovieDbContext _context;

        public MovieRepository(MovieDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Movie>> GetAllAsync()
        {
            return await _context.Movies.ToListAsync();
        }

        public async Task<Movie> GetByIdAsync(int id)
        {
            return await _context.Movies.FindAsync(id);
        }

        public async Task AddAsync(Movie movie)
        {
            await _context.Movies.AddAsync(movie);
        }
        public async Task DeleteAsync(Movie movie)
        {
            _context.Movies.Remove(movie);
        }

        public async Task<Movie?> GetFilmByTitleAsync(string title)
        {
            return await _context.Movies.FirstOrDefaultAsync(f => f.Title == title);
        }

        public async Task UpdateAsync(Movie movie)
        {
            _context.Movies.Update(movie);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
