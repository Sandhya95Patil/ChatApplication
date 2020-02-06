$(document).ready(function () {
    Receiver();
})
function Receiver() {
    var name = sessionStorage.getItem('name');
    console.log("name", name);
    $('#chatBox').append('<h1>' + name + '</h1>');
}