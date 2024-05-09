class Car {
    constructor(manufacturer, model, manufacturingYear, averageSpeed) {
        this.manufacturer = manufacturer;
        this.model = model;
        this.manufacturingYear = manufacturingYear;
        this.averageSpeed = averageSpeed;
    }

    printCarInfo() {
        console.log("Car information:");
        console.log("Manufacturer:", this.manufacturer);
        console.log("Model:", this.model);
        console.log("Manufacturing Year:", this.manufacturingYear);
        console.log("Average Speed:", this.averageSpeed + " km/h");
    }

    calculateTravelTime(distance) {
        const timeInHours = distance / this.averageSpeed;
        const restPeriods = Math.floor(timeInHours / 4);
        const totalRestTime = restPeriods * 1;
        const totalTime = timeInHours + totalRestTime;
        return totalTime;
    }
}