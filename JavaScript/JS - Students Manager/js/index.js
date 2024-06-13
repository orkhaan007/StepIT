document.addEventListener('DOMContentLoaded', function() {
    const form = document.getElementById('attendance-form');
    const attendanceList = document.getElementById('attendance-list');
    const attendanceRecords = [];

    form.addEventListener('submit', function(event) {
        event.preventDefault();

        const group = document.getElementById('group').value;
        const className = document.getElementById('class').value;
        const topic = document.getElementById('topic').value;
        const students = Array.from(document.querySelectorAll('input[name="students"]:checked'))
                            .map(checkbox => checkbox.value);

        const record = { group, className, topic, students };
        attendanceRecords.push(record);

        displayRecords();
        form.reset();
    });

    function displayRecords() {
        attendanceList.innerHTML = '';
        attendanceRecords.forEach(record => {
            const recordDiv = document.createElement('div');
            recordDiv.classList.add('attendance-record');
            recordDiv.innerHTML = `<strong>Group:</strong> ${record.group}, <strong>Pair:</strong> ${record.className}, <strong>Topic:</strong> ${record.topic}, <strong>Attendees:</strong> ${record.students.join(', ')}`;
            attendanceList.appendChild(recordDiv);
        });
    }
});
