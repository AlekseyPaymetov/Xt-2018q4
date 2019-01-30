(function () {

    var srcs = [
        "https://images6.alphacoders.com/672/672060.jpg",
        "https://www.gismeteo.ru/weather-saratov-5032/",
        "https://images7.alphacoders.com/661/661243.png",
        "http://learn.javascript.ru/",
        "https://images3.alphacoders.com/672/672392.png",
        "https://images7.alphacoders.com/331/331095.jpg"
    ]

    var TIME_CONST_S = 5;
    var numberOfPage = 0;
    var numberOfSeconds = TIME_CONST_S;
    var showPagesTime;
    var showTime;
    
    window.onload = function () {
        gallery.setAttribute("src", srcs[numberOfPage]);
        showPagesTime = setInterval(showPages, (TIME_CONST_S+1) * 1000);
        showTimer();
        showTime = setInterval(showTimer, 1000);
        reset.onclick = resetTimers;
        closeWindow.onclick = function () { close();}
        prev.onclick = goToPreviosPage;
        next.onclick = goToNextPage;
    }

    function showPages() {
        numberOfPage++;
        if (numberOfPage > srcs.length - 1) {
            answerFromUser = confirm("Restart- ok. Exit-cancel.");
            if (answerFromUser) {
                needClose = false;
                numberOfPage = 0;
            }
            else {
                clearInterval(showTime);
                clearInterval(showPagesTime);
                gallery.setAttribute("src", "")
                close();
            }
        }

        gallery.setAttribute("src", srcs[numberOfPage])
        clearInterval(showTime);
        numberOfSeconds = TIME_CONST_S;
        showTimer();
        showTime = setInterval(showTimer, 1000);
    }

    function showTimer() {
        timer.innerText = numberOfSeconds;
        numberOfSeconds--;
    }

    function resetTimers() {
        clearInterval(showTime);
        clearInterval(showPagesTime);
        numberOfSeconds = TIME_CONST_S;
        showTimer();
        showPagesTime = setInterval(showPages, (TIME_CONST_S + 1) * 1000);
        showTime = setInterval(showTimer, 1000);
    }

    function goToPreviosPage() {
        if (numberOfPage == 0) {
            return;
        }
        numberOfPage-=2;
        showPages();
        resetTimers();
    }

    function goToNextPage() {
        if (numberOfPage == srcs.length - 1) {
            return;
        }
        showPages();
        resetTimers();
    }

})()