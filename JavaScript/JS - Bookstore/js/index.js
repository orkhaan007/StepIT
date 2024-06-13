document.addEventListener('DOMContentLoaded', function() {
    const form = document.getElementById('order-form');
    const outputDiv = document.getElementById('output');

    form.addEventListener('submit', function(event) {
        event.preventDefault();

        const name = document.getElementById('name').value;
        const book = document.getElementById('book').selectedOptions[0].text;
        const date = document.getElementById('date').value;
        const address = document.getElementById('address').value;

        outputDiv.textContent = `${name}, thank you for your order. ${book} will be delivered on ${date} to ${address}.`;
    });
});