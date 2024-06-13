document.addEventListener('DOMContentLoaded', function() {
    const form = document.getElementById('booking-form');
    const bookingList = document.getElementById('booking-list');
    const bookingRecords = [];

    form.addEventListener('submit', function(event) {
        event.preventDefault();

        const direction = document.getElementById('direction').value;
        const date = document.getElementById('date').value;
        const seats = Array.from(document.querySelectorAll('input[name="seats"]:checked'))
                          .map(checkbox => checkbox.value);

        const record = { direction, date, seats };
        bookingRecords.push(record);

        displayRecords();
        form.reset();
    });

    function displayRecords() {
        bookingList.innerHTML = '';
        bookingRecords.forEach(record => {
            const recordDiv = document.createElement('div');
            recordDiv.classList.add('booking-record');
            recordDiv.innerHTML = `<strong>Направление:</strong> ${record.direction}, <strong>Дата:</strong> ${record.date}, <strong>Места:</strong> ${record.seats.join(', ')}`;
            bookingList.appendChild(recordDiv);
        });
    }
});