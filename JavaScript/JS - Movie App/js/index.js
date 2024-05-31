document.addEventListener('DOMContentLoaded', function () {
    const apiKey = '980fdbdb';
    const apiUrl = 'http://www.omdbapi.com/';

    const searchForm = document.getElementById('search-form');
    searchForm.addEventListener('submit', function (event) {
        event.preventDefault();
        const title = document.getElementById('title').value;
        const type = document.getElementById('type').value;
        searchMovies(title, type, 1);
    });

    function searchMovies(title, type, page) {
        fetch(`${apiUrl}?apikey=${apiKey}&s=${title}&type=${type}&page=${page}`)
            .then(response => response.json())
            .then(data => displayResults(data, title, type, page))
            .catch(error => document.getElementById('results').innerHTML = `Error fetching data: ${error}`);
    }

    function displayResults(data, title, type, page) {
        const results = document.getElementById('results');
        const pagination = document.querySelector('.pagination');
        results.innerHTML = '';
        pagination.innerHTML = '';

        if (data.Response === 'True') {
            data.Search.forEach(movie => {
                const poster = movie.Poster !== 'N/A' ? movie.Poster : 'placeholder.jpg';
                results.innerHTML += `
                    <div class="movie">
                        <img src="${poster}" alt="Poster">
                        <div>
                            <h3>${movie.Title}</h3>
                            <p>${movie.Year}</p>
                            <button class="details-button" data-id="${movie.imdbID}">Details</button>
                        </div>
                    </div>
                `;
            });

            const totalResults = parseInt(data.totalResults);
            const totalPages = Math.ceil(totalResults / 10);

            for (let i = 1; i <= totalPages; i++) {
                pagination.innerHTML += `<button class="page-button" data-page="${i}">${i}</button>`;
            }

            document.querySelectorAll('.page-button').forEach(button => {
                button.addEventListener('click', function () {
                    const page = this.getAttribute('data-page');
                    searchMovies(title, type, page);
                });
            });

            document.querySelectorAll('.details-button').forEach(button => {
                button.addEventListener('click', function () {
                    const movieId = this.getAttribute('data-id');
                    window.location.href = `details.html?id=${movieId}`;
                });
            });
        } else {
            results.innerHTML = 'Movie not found!';
        }
    }
});