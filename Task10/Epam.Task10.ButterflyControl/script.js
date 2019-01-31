"use strict"

var allAvailable = document.getElementById("available");
var allSelected = document.getElementById("selected");

function allRight(){
    allSelected.innerHTML = allSelected.innerHTML + allAvailable.innerHTML;
    allAvailable.options.length = 0;    
}
function allLeft(){
    allAvailable.innerHTML = allAvailable.innerHTML + allSelected.innerHTML;
    allSelected.options.length = 0;
}
function oneRight(){
    var availableOption = allAvailable.options[allAvailable.selectedIndex];
    if(availableOption != null){
        allSelected.appendChild(availableOption);
    }    
}
function oneLeft(){
    var selectedOption = allSelected.options[allSelected.selectedIndex];
    if(selectedOption != null){
        allAvailable.appendChild(selectedOption);
    }    
}
