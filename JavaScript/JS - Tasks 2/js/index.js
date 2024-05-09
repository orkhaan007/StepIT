function currency_converter() {
    let dollar = parseFloat(prompt("Enter the USD amount: "));
    let currency = prompt("Select the currency you want to convert (EUR, UAH, AZN): ").toUpperCase();
    let result;
    
    switch(currency) {
        case "EUR":
            result = dollar * 0.82;
            break;
        case "UAH":
            result = dollar * 27.71;
            break;
        case "AZN":
            result = dollar * 1.70;
            break;
        default:
            result = "Not the correct currency";
    }
    
    console.log("Result:", result, currency);
}

currency_converter();


function CalculateDiscount() {
    let amount = parseFloat(prompt("Enter amount: "));
    let discount = 0;
    
    if (amount >= 200 && amount < 300)
        discount = amount * 0.03;
    else if (amount >= 300 && amount < 500)
        discount = amount * 0.05;
    else if (amount >= 500)
        discount = amount * 0.07;
    
    let sum = amount - discount;
    console.log("Payment amount after discount: ", sum);
}

CalculateDiscount();

function circlePerimeter(radius) {
    return 2 * Math.PI * radius;
}

function squarePerimeter(side) {
    return 4 * side;
}

function isCircleSuitableSquare(radius, side) {
    let circle_perimeter = circlePerimeter(radius);
    let square_perimeter = squarePerimeter(side);

    if (circle_perimeter <= square_perimeter)
        console.log("Circle fits square");
    else
        console.log("Circle doesn't fit square");
}

let radius = parseFloat(prompt("Enter radius circle: "));
let side = parseFloat(prompt("Enter side square: "));

isCircleSuitableSquare(radius, side);

let score = 0;
const questions = [
    {
        question: "Who is the director of the Star Wars series?",
        options: ["A) George Lucas", "B) Martin Scorsese", "C) Quentin Tarantino"],
        correctAnswer: "A"
    },
    {
        question: "Who is the singer of my way music?",
        options: ["A) Wesley Howard", "B) Frank Sinatra", "C) James Brown Humphrey"],
        correctAnswer: "B"
    },
    {
        question: "Who was next js developed by?",
        options: ["A) Meta", "B) Vercel", "C) Microsoft"],
        correctAnswer: "B"
    }
];

function askQuestion(questionObj) {
    let userAnswer = prompt(`${questionObj.question}\n${questionObj.options.join("\n")}`);
    if (userAnswer.toUpperCase() === questionObj.correctAnswer) {
        score += 2;
        alert("That's right! Score: " + score);
    } else
        alert("Wrong answer! Score: " + score);
}

questions.forEach(askQuestion);
alert("Final Score: " + score);


function getNextDate(currentDate) {
    const date = new Date(currentDate);
    
    const day = date.getDate();
    const month = date.getMonth() + 1;
    const year = date.getFullYear();

    date.setDate(day + 1);

    const nextDay = date.getDate();
    const nextMonth = date.getMonth() + 1;
    const nextYear = date.getFullYear();

    return `${day}.${month}.${year} - ${nextDay}.${nextMonth}.${nextYear}`;
}



const daysOfWeek = ["Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"];

function showNextDayPrompt(day) {
    const dayOfWeek = daysOfWeek[day];
    const confirmation = confirm(dayOfWeek + ". Want to see the next day?");
    return confirmation;
}

function showNextDays() {
    let currentDay = new Date().getDay();
    while (true) {
        const confirmation = showNextDayPrompt(currentDay);

        if (!confirmation)
            break;

        currentDay = (currentDay + 1) % 7;
    }
}

showNextDays();


function multiplicationTable() {
    for (let i = 2; i <= 9; i++) {
        console.log(`Multiplication table with ${i}:`);
        for (let j = 1; j <= 10; j++)
            console.log(`${i} * ${j} = ${i * j}`);
        console.log("------------------");
    }
}

multiplicationTable();