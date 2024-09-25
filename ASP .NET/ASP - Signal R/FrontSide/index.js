var roomsSection = document.querySelector("#rooms");
var CURRENT_ROOM = "";
var totalSeconds = 10;
var currentUser = "";
var room = document.querySelector("#room");
var element = document.querySelector("#offerValue");
var timeSection = document.querySelector("#time-section");
var time = document.querySelector("#time");
var button = document.querySelector("#offerBtn");

const url = "http://localhost:5053/";
const connection = new signalR.HubConnectionBuilder()
  .withUrl(url + "offers")
  .configureLogging(signalR.LogLevel.Information)
  .build();

async function start() {
  try {
    await connection.start();
    updateOffer();
  } catch (err) {
    console.log(err);
    setTimeout(() => {
      start();
    }, 5000);
  }
}

async function fetchCars() {
  try {
    const response = await fetch(url + "api/Offer");
    const cars = await response.json();

    roomsSection.innerHTML = `
      <section>
        <label for="user">Username</label>
        <input type="text" id="user" />
      </section>
    `;

    const buttonsContainer = document.createElement("div");
    cars.forEach((car) => {
      const button = document.createElement("button");
      button.textContent = `Join ${car.Name}`;
      button.onclick = () => JoinRoom(car.Name);
      buttonsContainer.appendChild(button);
    });

    roomsSection.appendChild(buttonsContainer);
  } catch (error) {
    console.error("Failed to fetch car data:", error);
  }
}

async function JoinRoom(roomName) {
  let infoUser = document.querySelector("#info");
  infoUser.innerHTML = "";
  roomsSection.style.display = "none";
  CURRENT_ROOM = roomName;
  room.style.display = "block";
  await start();
  currentUser = document.querySelector("#user").value;
  await connection.invoke("JoinRoom", CURRENT_ROOM, currentUser);
}

async function LeaveRoom() {
  currentUser = document.querySelector("#user").value;
  await connection.invoke("LeaveRoom", CURRENT_ROOM, currentUser);
  room.style.display = "none";
  roomsSection.style.display = "block";
}

connection.on("ReceiveJoinInfo", (message) => {
  let infoUser = document.querySelector("#info");
  infoUser.innerHTML = message + " connected to our room";
});

connection.on("ReceiveInfoRoom", (user, data) => {
  const element2 = document.querySelector("#offerValue2");
  element2.innerHTML = user + " offer this price " + data + "$";
  button.disabled = false;
  timeSection.style.display = "none";
  clearTimeout(myInterval);
  totalSeconds = 10;
});

connection.on("RecieveLeaveInfo", (message) => {
  let infoUser = document.querySelector("#info");
  infoUser.innerHTML = message + " left the room";
});

connection.on("ReceiveWinInfoRoom", (message, data) => {
  const element2 = document.querySelector("#offerValue2");
  element2.innerHTML = message + " Offer this price " + data + "$";
  button.disabled = true;
  timeSection.style.display = "none";
  clearTimeout(myInterval);
});

var myInterval;

async function IncreaseOffer() {
  clearTimeout(myInterval);
  timeSection.style.display = "block";
  totalSeconds = 10;

  const result = document.querySelector("#user");

  await fetch(url + `api/Offer/IncreaseRoom?room=${CURRENT_ROOM}&data=100`);
  const response = await fetch(url + "api/Offer/Room?room=" + CURRENT_ROOM);
  const data = await response.json();

  var element2 = document.querySelector("#offerValue2");
  element2.innerHTML = data;

  await connection.invoke("SendMessageRoom", CURRENT_ROOM, result.value);
  button.disabled = true;

  myInterval = setInterval(async () => {
    time.innerHTML = totalSeconds;

    if (totalSeconds == 0) {
      clearTimeout(myInterval);
      button.disabled = true;
      await connection.invoke(
        "SendWinnerMessageRoom",
        CURRENT_ROOM,
        "Game Over \n " + result.value + " is Winner!"
      );
    }
    --totalSeconds;
  }, 1000);
}

fetchCars();