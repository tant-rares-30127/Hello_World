$(document).ready(function () {
    $("#createButton").click(function () {
        var newcomerName = $("#nameField").val();


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
        document.getElementById("createButton").disabled = true;
    });

});

(function () {
    $('#nameField').on('change textInput input', function () {
        var inputVal = this.value;
        if (inputVal != "") {
            document.getElementById("createButton").disabled = false;
        } else {
            document.getElementById("createButton").disabled = true;
        }
    });
}());