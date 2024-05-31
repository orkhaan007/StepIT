import { MyString } from './myString';

const inputStringElement = document.getElementById('inputString') as HTMLInputElement;
const indexElement = document.getElementById('index') as HTMLInputElement;
const signElement = document.getElementById('sign') as HTMLInputElement;
const outputElement = document.getElementById('output') as HTMLElement;

function updateOutput(result: string) {
  outputElement.textContent = `Result: ${result}`;
}

document.getElementById('removeButton')?.addEventListener('click', () => {
  const myStr = new MyString(inputStringElement.value);
  const index = parseInt(indexElement.value);
  const result = myStr.remove(index);
  updateOutput(result);
});

document.getElementById('insertButton')?.addEventListener('click', () => {
  const myStr = new MyString(inputStringElement.value);
  const index = parseInt(indexElement.value);
  const sign = signElement.value;
  const result = myStr.insert(index, sign);
  updateOutput(result);
});

document.getElementById('trimSignButton')?.addEventListener('click', () => {
  const myStr = new MyString(inputStringElement.value);
  const result = myStr.trimSign();
  updateOutput(result);
});

document.getElementById('toggleButton')?.addEventListener('click', () => {
  const myStr = new MyString(inputStringElement.value);
  const result = myStr.toggle();
  updateOutput(result);
});

document.getElementById('counterButton')?.addEventListener('click', () => {
  const myStr = new MyString(inputStringElement.value);
  const sign = signElement.value;
  const result = myStr.counter(sign).toString();
  updateOutput(result);
});