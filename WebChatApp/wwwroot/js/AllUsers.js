function AllUsers() {
    $.ajax({
        url: "https://localhost:44374/api/Account/AllUsers",
        data: JSON.stringify(),
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            console.log("result", result);
            console.log("===================", result.data[0]);
            

        },
        error: function (error) {
            console.log("Error", error);
        }
    })
}