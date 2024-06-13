const field = document.querySelector('.field');
const ball = document.querySelector('.ball');

field.addEventListener('click', (event) => {
    const fieldRect = field.getBoundingClientRect();
    const ballDiameter = ball.offsetWidth;
    const maxX = fieldRect.width - ballDiameter;
    const maxY = fieldRect.height - ballDiameter;

    let x = event.clientX - fieldRect.left - ballDiameter / 2;
    let y = event.clientY - fieldRect.top - ballDiameter / 2;

    x = Math.max(0, Math.min(x, maxX));
    y = Math.max(0, Math.min(y, maxY));

    ball.style.left = `${x}px`;
    ball.style.top = `${y}px`;
});