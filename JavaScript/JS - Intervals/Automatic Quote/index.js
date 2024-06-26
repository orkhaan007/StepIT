const quotes = [
    "First, solve the problem. Then, write the code. - John Johnson",
    "Java is to JavaScript what car is to Carpet. - Chris Heilmann",
    "Knowledge is power. - Francis Bacon",
    "Sometimes it pays to stay in bed on Monday, rather than spending the rest of the week debugging Monday’s code. - Dan Salomon",
    "Perfection is achieved not when there is nothing more to add, but rather when there is nothing more to take away. - Antoine de Saint-Exupery",
    "Ruby is rubbish! PHP is phpantastic! - Nikita Popov",
    "Code is like humor. When you have to explain it, it’s bad. - Cory House",
    "Fix the cause, not the symptom. - Steve Maguire",
    "Optimism is an occupational hazard of programming: feedback is the treatment. - Kent Beck",
    "When to use iterative development? You should use iterative development only on projects that you want to succeed. - Martin Fowler",
    "Simplicity is the soul of efficiency. - Austin Freeman",
    "Before software can be reusable it first has to be usable. - Ralph Johnson",
    "Make it work, make it right, make it fast. - Kent Beck"
];

const colors = [
    "#FF6633", "#FFB399", "#FF33FF", "#FFFF99", "#00B3E6", 
    "#E6B333", "#3366E6", "#999966", "#99FF99", "#B34D4D"
];

const quoteText = document.querySelector('.quote-text');
const quoteContainer = document.querySelector('.quote-container');

function showRandomQuote() {
    const randomQuote = quotes[Math.floor(Math.random() * quotes.length)];
    const randomColor = colors[Math.floor(Math.random() * colors.length)];
    
    quoteText.textContent = randomQuote;
    document.body.style.backgroundColor = randomColor;
    quoteText.style.color = randomColor;
    quoteContainer.style.borderColor = randomColor;
}

showRandomQuote();
setInterval(showRandomQuote, 5000);