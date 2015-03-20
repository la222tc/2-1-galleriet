"use strict"

//var esc = document.getElementById("Esc");

//esc.onclick = function () {
//    
//    alert("hej")
//};

//alert("hej")
var succBox = document.getElementById("BorderSuccesBox");


document.getElementById("Esc").addEventListener("click", function (e) {
    e.preventDefault();
    succBox.parentNode.removeChild(succBox);
    //alert("hej")
});

//var main = {
//    Init: function () {
//        this.CloseButton();
//    },

//    CloseButton: function () {
//        var succBox = document.getElementById("BorderSuccesBox");
//        document.getElementById("Esc").addEventListener("click", function () {
//            succBox.parentNode.removeChild(succBox);
//        });
//    }
   
//}
//window.onload = function () {
//    main.Init();
//}

