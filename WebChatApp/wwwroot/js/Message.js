$(document).ready(function () {
    Receiver();
    function connect() {
        var webSocketProtocol = location.protocol == "https:" ? "wss:" : "ws:";
        var webSocketURI = webSocketProtocol + "//localhost:44374/ws";
        socket = new WebSocket(webSocketURI);
        socket.onopen = function () {
            console.log("Web Socket Connected.");
        };

        socket.onclose = function (event) {
            if (event.wasClean) {
                console.log('Disconnected.');
            } else {
                console.log('Connection lost.'); // for example if server processes is killed
            }
            console.log('Code: ' + event.code + '. Reason: ' + event.reason);
        };
        socket.onmessage = function (event) {
             recName = sessionStorage.getItem('name');
            console.log("Message received By: " + recName + ' message: ' + event.data);
            $('#chatArea').prepend(event.data + '<br />');
        };
        socket.onerror = function (error) {
            console.log("Error: " + error);
        };
        $('#messageToSend').keypress(function (e) {
            if (e.which != 13) {
                return;
            }
            e.preventDefault();
            //var name = sessionStorage.getItem('name');
            var message = recName+ ":" + $('#messageToSend').val();
            socket.send(message);
        });     
    }
    connect();
/*
     document.getElementById('sendButton').addEventListener("click", function () {
         var sendMessage = function (element) {
             console.log("Sending message", element);
             socket.send(element);
        }
        var message = document.getElementById('messageToSend');
        sendMessage(message);
    })
   */ 
})

function Receiver() {
    var name = sessionStorage.getItem('name');
    console.log("name", name);
    recName = $('#chatBox').prepend('<h1>' + name + '</h1>').text();
    console.log("receiver name", recName);
    id = sessionStorage.getItem('id');
    console.log("id", id);
}

  

function SendMessage() {
    
    alert("message send");
    var userdata = {
        Message: $('#input').val(),
        ReceiverId: id
    };
    console.log("=============>", userdata);
    $.ajax({
        url: "https://localhost:44374/api/Chat/SendMessage",
        data: JSON.stringify(userdata),
        type: "post",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        headers: { "Authorization":'Bearer ' + localStorage.getItem('token')},
        success: function (result) {
            console.log("send message", result);
            $('#chatArea').append(result.data.message).text();
        },
        error: function (errormessage) {
            console.log("error", errormessage.responsetext);
        }
    });
}
