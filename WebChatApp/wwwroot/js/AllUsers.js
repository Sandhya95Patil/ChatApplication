$(document).ready(function () {
    AllUsers();

  
})
function userListClick(name) {
    alert("session storage " + name);
    sessionStorage.setItem('name', name);
}
function AllUsers() {
    $.ajax({
        url: "https://localhost:44374/api/Account/AllUsers",
        data: JSON.stringify(),
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            console.log("result", result);
            console.log("Zeroth value", result.data[0].firstName);

            $.each(result.data, function (key, item) {
                console.log("Item======", item.firstName);
                $('#users #lists').append('<li onClick="userListClick(\'' + item.firstName +'\')"><a href="Message.html"><h3>' + item.firstName + '</h3></a></li>')   
            })      
        },
        error: function (error) {
            console.log("Error", error);
        }
    })
};
function SignOut() {
    localStorage.clear();
    window.location.href = "/";
}
