$(document).ready(function () {
    AllUsers();
})
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
                $('#users .list').append('<li><h3 class="name">' + item.firstName + '</h3></li>')
            })      
        },
        error: function (error) {
            console.log("Error", error);
        }
    })
}