let input = document.getElementById("channelNameInput");
let writeMsgInput = document.getElementById('writeMessage');
let currentChannel;

input.addEventListener("input", (e) => {
    let btn = document.getElementById("btn");
    btn.disabled = e.target.value === "";
});

writeMsgInput.addEventListener("input", (e) => {
    let btn2 = document.getElementById("btn2");
    btn2.disabled = e.target.value === "";
});

async function getSelectedChannelMessages(channelName) {
    try {
        const response = await fetch(`/Home/GetSelectedChannelMessages?channelName=${encodeURIComponent(channelName)}`);
        if (!response.ok) {
            throw new Error("Failed to fetch channel messages.");
        }
        const messages = await response.json();
        console.log(messages);
        displayMessages(messages, channelName);
        const sendMessageDiv = document.getElementById('sendMessageDiv');
        sendMessageDiv.style.display = "flex";
    } catch (error) {
        console.error(error);
        alert("Error fetching messages. Please try again.");
    }
}

function displayMessages(messages, channelName) {
    const container = document.getElementById("messages");
    currentChannel = channelName;
    container.innerHTML = `<h3 class="messages-heading">${channelName}</h3>`;
    if (messages.length === 0) {
        container.innerHTML += "<p>No messages in this channel.</p>";
    } else {
        const messageList = document.createElement("ul");
        messageList.style.listStyle = "none";
        messages.forEach((msg) => {
            const li = document.createElement("li");
            li.textContent = msg;
            messageList.appendChild(li);
        });
        container.appendChild(messageList);
    }
}

async function sendMessage() {
    const msg = document.getElementById('writeMessage').value;

    if (!msg || !currentChannel) return;

    try {
        const response = await fetch(`/Home/SendMessage?channelName=${encodeURIComponent(currentChannel)}&message=${encodeURIComponent(msg)}`, {
            method: 'POST'
        });
        if (response.ok) {
            getSelectedChannelMessages(currentChannel);
        } else {
            alert("Error sending message.");
        }
    } catch (error) {
        console.error("Error:", error);
        alert("Error sending message.");
    }

    document.getElementById('writeMessage').value = '';
}