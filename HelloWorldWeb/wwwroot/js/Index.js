$(document).ready(function () {
    $("#createButton").click(function () {
        var newcomerName = $("#nameField").val();

        // Remember string interpolation
        

        $.ajax({
            url: "/Home/AddTeamMember",
            method: "POST",
            data: {
                "name": newcomerName
            },
            success: function (result) {
                $("#list").append(`<li>${newcomerName}</li>`);
                $("#nameField").val("");
            }
        })

        
    })

    $("#deleteField").click(function () {
        var newcomerName = $("#memberField").val();

        // Remember string interpolation


        $.ajax({
            url: "/Home/DeleteTeamMember",
            method: "POST",
            data: {
                "name": newcomerName
            },
            success: function (result) {
                $("#list").remove(`<li>${newcomerName}</li>`);
                $("#memberField").val("");
            }
        })


    })
});