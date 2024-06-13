document.addEventListener('DOMContentLoaded', function() {
    const form = document.getElementById('test-form');
    const resultDiv = document.getElementById('result');

    form.addEventListener('submit', function(event) {
        event.preventDefault();

        let correctAnswers = 0;
        const answers = {
            q1: '1',
            q2: '1'
        };

        Object.keys(answers).forEach(question => {
            const selectedAnswer = form.querySelector(`input[name="${question}"]:checked`);
            if (selectedAnswer && selectedAnswer.value === answers[question]) {
                correctAnswers++;
            }
        });

        resultDiv.textContent = `Number of correct answers: ${correctAnswers}`;
    });
});