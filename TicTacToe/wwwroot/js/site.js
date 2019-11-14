// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.

var checkers = document.getElementsByTagName("circle");
var squares = document.getElementsByTagName("rect");

var selectedChecker;

function OnClickChecker(event) {
    if (selectedChecker) {
        selectedChecker.setAttribute("stroke", "grey");
    }
    selectedChecker = event.target;
    event.target.setAttribute("stroke", "green");
}

function OnClickSquare(event) {
    if (selectedChecker) {
        document.getElementById("cx").value = selectedChecker.getAttribute("data-x");
        document.getElementById("cy").value = selectedChecker.getAttribute("data-y");
        document.getElementById("sx").value = event.target.getAttribute("data-x");
        document.getElementById("sy").value = event.target.getAttribute("data-y");
        document.getElementById("move-form").submit();
    }
}

for (var i = 0; i < checkers.length; i++) {
    checkers[i].addEventListener("click", OnClickChecker);
}
for (var i = 0; i < squares.length; i++) {
    squares[i].addEventListener("click", OnClickSquare);
}