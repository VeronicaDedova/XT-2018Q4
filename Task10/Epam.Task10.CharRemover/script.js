"use strict"

function removeChars() {
    var separator = [' '];

    var inputString = document.getElementById("input").value.toLowerCase();
    var words = inputString.split(separator);
    var repeatedLetters = "";
    var resultString = inputString;

    words.forEach(function(item){
        for(var i = 0; i < item.length; i++){
            for(var j = i + 1; j < item.length; j++){
                if(item[i] == item[j]){
                    repeatedLetters += item[i];
                }               
            }
        }
    });
    
    for (var i = 0; i < repeatedLetters.length; i++){
        resultString = resultString.split(repeatedLetters[i]).join('');
    }

    document.getElementById("res").innerHTML = resultString;    
}
