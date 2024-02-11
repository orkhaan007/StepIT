using Practics_DataAcsess.Repositories.Concretes;
using Practics_Model.Entities.Concretes;
using System;

namespace Practics
{
    class Program
    {
        static void Main(string[] args)
        {
            AuthorRepository<Author> authorRepository = new AuthorRepository<Author>();

            authorRepository.Add(new Author { Id = 1, });
        }
    }
}