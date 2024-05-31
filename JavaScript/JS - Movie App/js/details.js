document.addEventListener('DOMContentLoaded', function () {
    const apiKey = '980fdbdb';
    const apiUrl = 'http://www.omdbapi.com/';

    const urlParams = new URLSearchParams(window.location.search);
    const movieId = urlParams.get('id');

    if (movieId) {
        fetchDetails(movieId);
    } else {
        document.getElementById('details').innerHTML = 'No movie ID provided.';
    }

    function fetchDetails(movieId) {
        fetch(`${apiUrl}?apikey=${apiKey}&i=${movieId}`)
            .then(response => response.json())
            .then(data => {
                if (data.Response === "True") {
                    displayDetails(data);
                } else {
                    document.getElementById('details').innerHTML = data.Error || 'Details not found!';
                }
            })
            .catch(error => document.getElementById('details').innerHTML = `Error fetching data: ${error}`);
    }

    function displayDetails(movie) {
        const poster = movie.Poster !== 'N/A' ? movie.Poster : 'placeholder.jpg';
        document.getElementById('details').innerHTML = `
            <img src="${poster}" alt="Poster">
            <h2>${movie.Title}</h2>
            <p><strong>Year:</strong> ${movie.Year}</p>
            <p><strong>Rated:</strong> ${movie.Rated}</p>
            <p><strong>Released:</strong> ${movie.Released}</p>
            <p><strong>Runtime:</strong> ${movie.Runtime}</p>
            <p><strong>Genre:</strong> ${movie.Genre}</p>
            <p><strong>Director:</strong> ${movie.Director}</p>
            <p><strong>Writer:</strong> ${movie.Writer}</p>
            <p><strong>Actors:</strong> ${movie.Actors}</p>
            <p><strong>Plot:</strong> ${movie.Plot}</p>
            <p><strong>Language:</strong> ${movie.Language}</p>
            <p><strong>Country:</strong> ${movie.Country}</p>
            <p><strong>Awards:</strong> ${movie.Awards}</p>
            <p><strong>Metascore:</strong> ${movie.Metascore}</p>
            <p><strong>imdbRating:</strong> ${movie.imdbRating}</p>
            <p><strong>imdbVotes:</strong> ${movie.imdbVotes}</p>
            <p><strong>Type:</strong> ${movie.Type}</p>
            <p><strong>DVD:</strong> ${movie.DVD}</p>
            <p><strong>BoxOffice:</strong> ${movie.BoxOffice}</p>
            <p><strong>Production:</strong> ${movie.Production}</p>
            <p><strong>Website:</strong> <a href="${movie.Website}" target="_blank">${movie.Website}</a></p>
        `;
    }
});