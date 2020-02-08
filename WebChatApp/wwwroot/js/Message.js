$(document).ready(function () {
    Receiver();
})
function Receiver() {
    var name = sessionStorage.getItem('name');
    console.log("name", name);
    recName = $('#chatBox').prepend('<h1>' + name + '</h1>');
}


function SendMessage() {
    alert("message send");
    console.log("name");
    var userdata = {
        Message: $('#input').val()
    };
    console.log("=============>", userdata);
    $.ajax({
        url: "https://localhost:44374/api/Chat/SendMessage",
        data: json.stringify(userdata),
        type: "post",
        contenttype: "application/json;charset=utf-8",
        datatype: "json",
        success: function (result) {
            console.log("send message", result);
        },
        error: function (errormessage) {
            console.log("error", errormessage.responsetext);
        }
    });
}
