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
                $("#list").append(
                    `<li>
                        <span class="memberName">
                            ${newcomerName}
                        </span >
                        <span class="delete fa fa-remove" onclick="deleteMember(${result})">
                        </span>
                        <span class="edit fa fa-pencil">
                        </span>
                    </li>`);
                $("#nameField").val("");
                document.getElementById("createButton").disabled = true;
            }
        })


    });

    $("#clearButton").click(function ClearFields() {
        $("#nameField").val("");
    });

});