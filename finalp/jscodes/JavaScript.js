
//navbar arka plan,boyut degistirme kodu


window.addEventListener("scroll", function () {
    var nav = document.getElementById("myNav");
    var scrollPosition = window.scrollY || window.pageYOffset;
    const navbar = document.querySelector('.navbar');

    if (scrollPosition > 100) { // İstenilen kaydırma mesafesi
        nav.style.backgroundColor = "#253c38ff"; // Arka plan rengini değiştirin
        nav.style.boxShadow = "1px 1px 2px rgba(0, 0, 0, 0.2)";
        navbar.classList.add('active');
    } else {
        nav.style.backgroundColor = " #253c38bf"; // Varsayılan arka plan rengi
        navbar.classList.remove('active');
    }
});

