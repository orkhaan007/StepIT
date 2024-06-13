document.addEventListener('DOMContentLoaded', function() {
    const form = document.getElementById('style-form');
    const outputDiv = document.getElementById('output');

    form.addEventListener('submit', function(event) {
        event.preventDefault();

        const text = document.getElementById('text').value;
        const color = document.getElementById('color').value;
        const fontSize = document.getElementById('fontSize').value;

        const styledText = document.createElement('div');
        styledText.textContent = text;
        styledText.style.color = color;
        styledText.style.fontSize = `${fontSize}px`;

        outputDiv.innerHTML = '';
        outputDiv.appendChild(styledText);
    });
});