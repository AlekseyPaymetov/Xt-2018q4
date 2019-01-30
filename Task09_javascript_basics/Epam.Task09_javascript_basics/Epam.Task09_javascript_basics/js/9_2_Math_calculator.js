"use strict";

(function () {

    window.onload = function () {
        var calcBu = document.getElementById("calcBu");
        calcBu.onclick = calculate;
    }

    function calculate() {
        var text = input.value;
        text = text.trim();
        if (text.indexOf("=") != text.length - 1) {
            output.innerHTML = "Errors in input.";
            return;
        }
        var operationReg = /[\+\-\*\/]/;
        var numberReg = /[0-9]+(\.[0-9]+)*/;
       
        if (text[0] == "-") {
            text.shift();
            if (text.search(numberReg) == 0) {
                var number1 = -text.match(numberReg);
                text = text.replace(numberReg, "");
            }
            else {
                output.innerHTML = "Errors in input.";
                return;
            }
        }
        else {
            if (text.search(numberReg) == 0) {
                number1 = text.match(numberReg);
                text = text.replace(numberReg, "");
            }
            else {
                output.innerHTML = "Errors in input.";
                return;
            }
        }

        while (text.indexOf("=") != 0 && text.length > 0) {
            text = text.trim();
            if (text.search(operationReg) == 0) {
                var operation = text[0];
                text = text.replace(operationReg, "");
                text = text.trim();
            }
            else {
                output.innerHTML = "Errors in input.";
                return;
            }

            if (text.search(numberReg) == 0) {
                var number2 = text.match(numberReg);
                text = text.replace(numberReg, "");
                text = text.trim();
            }
            else {
                output.innerHTML = "Errors in input.";
                return;
            }

            switch (operation) {
                case '+':
                    number1[0] = +number1[0] + +number2[0];
                    break;
                case '-':
                    number1[0] = number1[0] - number2[0];
                    break;
                case '*':
                    number1[0] = number1[0] * number2[0];
                    break;
                case '/':
                    number1[0] = number1[0] / number2[0];
                    break;
                default:
                    output.innerHTML = "Errors in input.";
                    return;
            }
        }

        output.innerHTML = number1[0].toFixed(2);
    }

})()