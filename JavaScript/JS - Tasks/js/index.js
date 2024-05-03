let name = prompt("Enter Your Name: ");
console.log("Hi, " + name);

const currentYear = new Date().getFullYear();
let birthYear = prompt("Enter your birth year:");
let age = currentYear - parseInt(birthYear);
console.log("Your Age: " + age + " (Current year: " + currentYear + ")");

let sideLength = prompt("Enter the length of one side of the square:");
let perimeter = 4 * parseFloat(sideLength);
console.log("Perimeter of the square: " + perimeter);

let radius = prompt("Enter the radius of the circle:");
let area = Math.PI * Math.pow(parseFloat(radius), 2);
console.log("Area of the circle: " + area);

let distance = prompt("Enter the distance between two cities in kilometers:");
let hours = prompt("At what speed do you want to arrive?");
let time = distance / hours;
console.log("Speed: " + time + " km/h");

const DOLLAR_TO_EURO_RATE = 0.82;
let dollar = prompt("Enter the amount (in dollars):");
let euro = dollar * DOLLAR_TO_EURO_RATE;
console.log("Amount: " + euro + " euro");

const FLASH_DRIVE_SIZE_GB = prompt("Enter the size of the flash drive in GB:");
const FILE_SIZE_MB = 820;
let fileCount = Math.floor(parseFloat(FLASH_DRIVE_SIZE_GB) * 1024 / FILE_SIZE_MB);
console.log("Number of files that will fit on the flash drive: " + fileCount);

let money = parseFloat(prompt("Enter your money:"));
let chocolatePrice = parseFloat(prompt("Enter price chocolate bar:"));
let chocolateCount = Math.floor(money / chocolatePrice);
let remainingMoney = money % chocolatePrice;
console.log("You can buy " + chocolateCount + " chocolate bars and have " + remainingMoney + " dollars left in your wallet.");

let number = parseInt(prompt("Enter three-digit number:"));
let reverse = 0;
reverse += number % 10 * 100;
number = Math.floor(number / 10);
reverse += number % 10 * 10;
number = Math.floor(number / 10);
reverse += number;
console.log("Reverse of the number: " + reverse);

let num = parseInt(prompt("Enter an integer:"));
if (num % 2 === 0)
    console.log(num + " is an even number.");
else
    console.log(num + " is not an even number.");