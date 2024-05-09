function createProductCard(productName, price, imageUrl) {
    const card = document.createElement("div");
    const img = document.createElement("img");
    const name = document.createElement("h2");
    const priceElement = document.createElement("p");

    img.src = imageUrl;
    name.textContent = productName;
    priceElement.textContent = "Price: " + price;
    
    card.appendChild(img);
    card.appendChild(name);
    card.appendChild(priceElement);
    
    return card;
}

function createCommentMessage(author, message, timestamp) {
    const comment = document.createElement("div");
    const authorElement = document.createElement("h3");
    const messageElement = document.createElement("p");
    const timestampElement = document.createElement("small");
    
    authorElement.textContent = "Author: " + author;
    messageElement.textContent = message;
    timestampElement.textContent = "Date: " + timestamp;
    
    comment.appendChild(authorElement);
    comment.appendChild(messageElement);
    comment.appendChild(timestampElement);

    return comment;
}

function createMenuItem(name, price, description) {

    const menuItem = document.createElement("div");
    const nameElement = document.createElement("h2");
    const priceElement = document.createElement("p");
    const descriptionElement = document.createElement("p");
    
    nameElement.textContent = name;
    priceElement.textContent = "Price: " + price;
    descriptionElement.textContent =  description;
    
    menuItem.appendChild(nameElement);
    menuItem.appendChild(priceElement);
    menuItem.appendChild(descriptionElement);
    
    return menuItem;
}