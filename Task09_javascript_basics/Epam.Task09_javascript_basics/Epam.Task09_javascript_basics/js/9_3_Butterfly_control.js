"use strict";

(function () {
    var selectedClass = "blueBg";
    window.onload = function () {
        butterflyControl1.onclick = workControl;
        butterflyControl2.onclick = workControl;
    }

    function workControl(event) {
        if (event.target.tagName == "LI") {
            event.target.classList.toggle(selectedClass);
        }

        if (event.target.className == "allToSelected") {
            allCopy(this,"allToSelected");
        }

        if (event.target.className == "allToAvailable") {
            allCopy(this, "allToAvailable");
        }

        if (event.target.className == "selectedToSelected") {
            copySelected(this, "selectedToSelected");
        }

        if (event.target.className == "selectedToAvailable") {
            copySelected(this, "selectedToAvailable");
        }
    }
    
    function allCopy(objOfEvent, from) {
        var fromUl = "availableUl";
        var toUl = "selectedUl";

        if (from == "allToAvailable") {
            fromUl = "selectedUl";
            toUl = "availableUl";
        }
        else if (from != "allToSelected") {
            return;
        }

        var whatToCopyUl = objOfEvent.getElementsByClassName(fromUl)[0];
        var toCopyLi = whatToCopyUl.getElementsByTagName("li");
        var whereToCopyUl = objOfEvent.getElementsByClassName(toUl)[0];
        var copyToCopyLi = [];
        var numberOfLi = toCopyLi.length;
        for (var i = 0; i < numberOfLi; i++) {
            copyToCopyLi[i] = toCopyLi[i];
        }
        for (var i = 0; i < numberOfLi; i++) {
            copyToCopyLi[i].classList.remove(selectedClass);
            whereToCopyUl.appendChild(copyToCopyLi[i]);
        }
    }

    function copySelected(objOfEvent, from) {
        var fromUl = "availableUl";
        var toUl = "selectedUl";

        if (from == "selectedToAvailable") {
            fromUl = "selectedUl";
            toUl = "availableUl";
        }
        else if (from != "selectedToSelected") {
            return;
        }

        var whatToCopyUl = objOfEvent.getElementsByClassName(fromUl)[0];
        var allToCopyLi = whatToCopyUl.getElementsByTagName("li");
        var toCopyLi=[];
        var counter = 0;
        for (var i = 0; i < allToCopyLi.length; i++) {
            if (allToCopyLi[i].classList.contains(selectedClass)) {
                toCopyLi[counter] = allToCopyLi[i];
                counter++;
            }
        }
        if (counter==0) {
            var message = "There is no selected items in \"Available\" area";
            if (fromUl == "selectedUl") {
                message = "There is no selected items in \"Selected\" area";
            }
            alert(message);
            return;
        }

        var whereToCopyUl = objOfEvent.getElementsByClassName(toUl)[0];
        var copyToCopyLi = [];
        var numberOfLi = toCopyLi.length;
        for (var i = 0; i < numberOfLi; i++) {
            copyToCopyLi[i] = toCopyLi[i];
        }
        for (var i = 0; i < numberOfLi; i++) {
            copyToCopyLi[i].classList.remove(selectedClass);
            whereToCopyUl.appendChild(copyToCopyLi[i]);
        }
    }

})()