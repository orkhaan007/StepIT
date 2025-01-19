async function fetchAndDisplayPosters() {
    try {
        const response = await fetch('/Home/GetMoviePosters');
        if (response.ok) {
            const posters = await response.json();
            const container = document.getElementById('moviePosters');
            container.innerHTML = '';

            posters.forEach(url => {
                const img = document.createElement('img');
                img.src = url;
                img.alt = 'Movie Poster';
                img.className = 'm-2';
                img.style.width = '200px';
                img.style.height = '300px';
                img.style.objectFit = 'cover';
                img.style.borderRadius = '8px';
                container.appendChild(img);
            });
        } else {
            console.error('Failed to fetch movie posters.');
        }
    } catch (error) {
        console.error('Error fetching posters:', error);
    }
}

setInterval(fetchAndDisplayPosters, 3000);

fetchAndDisplayPosters();