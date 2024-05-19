const display = document.querySelector('.display');
const buttons = document.querySelectorAll('.btn');

buttons.forEach(button => {
    button.addEventListener('click', () => {
        if (button.textContent === '=') {
            try {
                display.value = eval(display.value);
            } catch (e) {
                display.value = 'Error!';
            }
        } else {
            display.value += button.textContent;
        }
    });
});