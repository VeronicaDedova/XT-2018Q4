"use strict"

var nextPage = document.getElementById("timer").getAttribute("href");
var timeout;

function startTimer(){
    var timer = document.getElementById("timer");
    var time = timer.innerHTML;
    var arr = time.split(":");
    var minutes = arr[0];
    var seconds = arr[1];
   
    if (seconds == 0){
        if (nextPage == ""){
            var repeat = confirm('Повторить?');
            if(repeat){
                window.location.href = "SimpleGallery1.html";
            }
            else{
                alert('Пока:)');
            }
        }
        else{
            window.location.href = nextPage;
            return;
        }            
    }    
    seconds--;

    if (seconds < 10){
        seconds = "0" + seconds;
    }   
    
    document.getElementById("timer").innerHTML = minutes + ":" + seconds;
    timeout = setTimeout(startTimer, 1000);
}

function toPreviousPage(){
    var previousPage = document.getElementById("previousid").getAttribute("href");
    if(previousPage == ""){
        alert('Это первая страница.');
    }
    else{
        window.location.href = previousPage;
    }  
}

function pause(){
    clearInterval(timeout);
}

function play(){
    setTimeout(startTimer, 1000);
}