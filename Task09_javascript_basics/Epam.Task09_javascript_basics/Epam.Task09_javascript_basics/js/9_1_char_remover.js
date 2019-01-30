"use strict";

(function () {

    window.onload = function () {
        var calcBu = document.getElementById("calcBu");
        calcBu.onclick = calculate;
    }

    function calculate() {
        var text = input.value;
        output.innerHTML = removeChar(text);
    }

    function removeChar(text) {
        var separateSymbols = [" ", "\t", "?", "!", ":", ";", ",", "."]
        var startWord = 0;
        var endWord = 0;
        var counter = 0;
        var words = [];
        text += " ";
        for (var i = 0; i < text.length; i++) {
            for (var j = 0; j < separateSymbols.length; j++) {
                if (text[i] == separateSymbols[j]) {
                    endWord = i;
                    if (endWord > startWord) {
                        words[counter] = text.slice(startWord, endWord);
                        counter++;
                    }
                    startWord = i + 1;
                    break;
                }
            }
        }

        var symbolsForDelete = [];
        counter = 0;
        for (i = 0; i < words.length; i++) {
            for (j = 0; j < words[i].length; j++) {
                for (var k = 0; k < symbolsForDelete.length; k++) {
                    var find = false;
                    if (symbolsForDelete[k] == words[i][j]) {
                        find = true;
                        break;
                    }
                }
                if (!find) {
                    if (words[i].split(words[i][j]).length > 2) {
                        symbolsForDelete[counter] = words[i][j];
                        counter++;
                    }
                }
            }
        }

        text = text.slice(0,text.length-1)
        counter = 0;
        var newText = "";
        textCycle: for (i = 0; i < text.length; i++) {
            for (j = 0; j < symbolsForDelete.length; j++) {
                if (text[i] == symbolsForDelete[j]) {
                    continue textCycle;
                }
            }
            newText += text[i];
        }
        return newText;
    }

}) ()