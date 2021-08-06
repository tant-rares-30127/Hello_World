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
                location.reload();
            }
        })


    });

    $("#clearButton").click(function ClearFields() {
        $("#nameField").val("");
        document.getElementById("createButton").disabled = true;
    });

    $("#editClassmate").on("click", "#submit", function () {
        console.log('submit changes to server');
        var name = $("#classmateName").val();
        var id = $('#editClassmate').attr('data-member-id');
      //  var id = 5;
        $.ajax({
            url: "/Home/EditTeamMember",
            method: "POST",
            data: {
                "id": id,
                "name": name
            },
            success: function (result) {
                console.log('Succesful renamed: ${id}');
                location.reload();
            }
        })
    })

    $("#editClassmate").on("click", "#cancel", function () {
        console.log('cancel changes');
    })

    $("#list").on("click", ".pencil", function () {

        var targetMemberTag = $(this).closest('li');
        var id = targetMemberTag.attr('data-member-id');
        var currentName = targetMemberTag.find(".memberName").text();

        $('#editClassmate').attr("data-member-id", id);
        $('#classmateName').val(currentName);
        $('#editClassmate').modal('show');
    })

});

function deleteMember(index) {

    $.ajax({
        url: "/Home/DeleteTeamMember",
        method: "DELETE",
        data: {
            "id": index
        },
        success: function (result) {
            location.reload();
        }
    })
}


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