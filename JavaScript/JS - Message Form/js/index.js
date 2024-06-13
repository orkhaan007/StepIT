document.addEventListener('DOMContentLoaded', function() {
    const form = document.getElementById('message-form');
    const messageList = document.getElementById('message-list');

    form.addEventListener('submit', function(event) {
        event.preventDefault();

        const author = document.getElementById('author').value;
        const content = document.getElementById('content').value;

        const messageDiv = document.createElement('div');
        messageDiv.classList.add('message');
        messageDiv.innerHTML = `<strong>${author}</strong>: ${content}`;

        messageList.appendChild(messageDiv);

        form.reset();
    });
});