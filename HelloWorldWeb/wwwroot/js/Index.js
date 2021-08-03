$(document).ready(function () {
    $("#createButton").click(function () {
        var newcomerName = $("#nameField").val();

        // Remember string interpolation
        $("#list").append(`<li>${newcomerName}</li>`);

        $("#nameField").val("");
    })
});