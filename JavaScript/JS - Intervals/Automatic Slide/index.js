let Index = 0;

function showSlides() {
    const slides = document.querySelectorAll(".mySlides");
    for (let i = 0; i < slides.length; i++)
        slides[i].style.display = "none";  
    Index++;
    if (Index > slides.length)
        Index = 1;
    slides[Index - 1].style.display = "block";  
}

showSlides();
setInterval(showSlides, 3000);