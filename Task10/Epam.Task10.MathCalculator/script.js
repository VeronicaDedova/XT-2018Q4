"use strict"

function calculator() {
    var inputString = document.getElementById("input").value;
    var template = /(\d+[\.|\,]?\d*)\s?([\+\-\*\/]\s?(\d+[\.|\,]?\d*))*\s?\=/;
    var regExpNumbers = /(\d+[\.|\,]?\d*)/g;
    var regExpOperators = /[\+\-\*\/]/g;
    
    if(!inputString.match(template)){
        alert( "Incorrect input" );
    }
    else{
        var numbers = inputString.match(regExpNumbers);
        var operators = inputString.match(regExpOperators);
        var result = +numbers[0];
        for(var i = 0, j=0; (i < operators.length && j <numbers.length-1); i++, j++){
            if(operators[i] == '*'){
                result *= numbers[j + 1];
            }
            else if(operators[i] == '/'){
                result /= numbers[j + 1];                   
            }
            else if(operators[i] == '+'){
                result += +numbers[j + 1];
            }
            else if(operators[i] == '-'){
                result -= numbers[j + 1];  
            }                      
        }
        alert( result.toFixed(2)); 
    }   
}