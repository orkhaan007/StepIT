document.querySelector('.start-button').addEventListener('click', startCountdown);

function startCountdown() {
    const hoursInput = document.querySelector('.hours').value;
    const minutesInput = document.querySelector('.minutes').value;
    const secondsInput = document.querySelector('.seconds').value;

    let totalTime = (parseInt(hoursInput) * 3600) + (parseInt(minutesInput) * 60) + parseInt(secondsInput);
    
    const countdownDisplay = document.querySelector('.time');
    const countdown = setInterval(() => {
        if (totalTime <= 0) {
            clearInterval(countdown);
            countdownDisplay.textContent = "Time's up!";
        } else {
            totalTime--;
            const hours = Math.floor(totalTime / 3600);
            const minutes = Math.floor((totalTime % 3600) / 60);
            const seconds = totalTime % 60;
            countdownDisplay.textContent = `${hours.toString().padStart(2, '0')}:${minutes.toString().padStart(2, '0')}:${seconds.toString().padStart(2, '0')}`;
        }
    }, 1000);
}