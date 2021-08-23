'use strict';
$(document).ready(function () {

    var connection = new signalR.HubConnectionBuilder().withUrl("/messagehub").build();

    connection.on("NewTeamMemberAdded", function(name, id) {
        console.log(`New team member added: name, ${name} ${id}`);
        createNewComer(name, id)
    });

    connection.on("DeleteTheTeamMember", function (id) {
        console.log(`Delete team member: ${id}`);
        onMemberDelete(id)
    });

    connection.on("EditTheTeamMember", function (id, name) {
        console.log(`Edit team member: ${id}`);
        onMemberEdit(id, name)
    });

    connection.start().then(function () {
        console.log('Connection Started')

    }).catch(function (err) {
        return console.error(err.toString());
    });

    $("#createButton").click(function () {
        var newcomerName = $("#nameField").val();
        $.ajax({
            url: "/Home/AddTeamMember",
            method: "POST",
            data: {
                "name": newcomerName
            },
            success: function (result) {
                $("#nameField").val("");
                document.getElementById("createButton").disabled = true;
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
        $.ajax({
            url: "/Home/EditTeamMember",
            method: "POST",
            data: {
                "id": id,
                "name": name
            },
            success: function (result) {
                console.log('Succesful renamed: ${id}');
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

    $("#list").on("click", ".delete", function () {
        var targetMemberTag = $(this).closest('li');
        var id = targetMemberTag.attr('data-member-id');
/*        var id = $(this).parent().attr("data-member-id");*/
        deleteMember(id);
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
            
        }
    })
}

function onMemberDelete(id) {
    $(`li[data-member-id=${id}]`).remove();
}

function onMemberEdit(id, name) {
    $(`li[data-member-id=${id}]`).find(".memberName").text(name);
}

function createNewComer(name, id) {
    // Remember string interpolation
    $("#list").append(
        `<li class="member" data-member-id="${id}">
            <span class="memberName">
                ${name}
            </span >
            <span class="delete fa fa-remove">
            </span>
            <span class="pencil fa fa-pencil">
            </span>
        </li>`);
}
/*$("#clear").click(function () {
    $("#newcomer").val("");
})*/


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