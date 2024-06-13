function delay(milliseconds) {
    return new Promise(resolve => setTimeout(resolve, milliseconds));
}

delay(2000).then(() => {
    console.log("Test");
});


/////////////////////////////////////////////////////////////////////////////


function firstTask() {
    return new Promise(resolve => {
        setTimeout(() => resolve("First Mission"), 1000);
    });
}

function secondTask() {
    return new Promise(resolve => {
        setTimeout(() => resolve("Second Mission"), 1000);
    });
}

firstTask()
    .then(result => {
        console.log(result);
        return secondTask();
    })
    .then(result => {
        console.log(result);
    });


/////////////////////////////////////////////////////////////////////////////


function taskOne() {
    return new Promise(resolve => {
        setTimeout(() => resolve("First Mission"), 1000);
    });
}

function taskTwo() {
    return new Promise(resolve => {
        setTimeout(() => resolve("Second Mission"), 2000);
    });
}

function taskThree() {
    return new Promise(resolve => {
        setTimeout(() => resolve("Third Mission."), 3000);
    });
}

Promise.all([taskOne(), taskTwo(), taskThree()]).then(results => {
    console.log(results);
});


/////////////////////////////////////////////////////////////////////////////


function fastTask() {
    return new Promise(resolve => {
        setTimeout(() => resolve("Fast Mission"), 1000);
    });
}

function slowTask() {
    return new Promise(resolve => {
        setTimeout(() => resolve("Slow Mission"), 2000);
    });
}

Promise.race([fastTask(), slowTask()]).then(result => {
    console.log(result);
});


/////////////////////////////////////////////////////////////////////////////