
function LoginForm() {
    var userData = {
        Email: $('#email').val(),
        Password: $('#password').val()
    };
    console.log("=============>", userData);
    $.ajax({
        url: "https://localhost:44374/api/Account/Login",
        data: JSON.stringify(userData),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            console.log("Login", result);
            localStorage.setItem("token", result.data.token);
            localStorage.setItem("id", result.data.id);
            console.log("id============>", result.data.id);
            var location = window.location.href = "./Template//Dashboard.html";
            console.log("location", location);

        },
        error: function (errormessage) {
            console.log("error", errormessage.responseText);
        }
    });
}

function RegisterForm() {
    console.log("Register");
    var userData = {
        FirstName: $('#firstName').val(),
        LastName: $('#lastName').val(),
        Email: $('#email').val(),
        Password: $('#password').val(),
        MobileNumber: $('#mobileNumber').val()
    };
    console.log("Register data", userData);
    $.ajax({
        url: "https://localhost:44374/api/Account/SignUp",
        data: JSON.stringify(userData),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType:"json",
        success: function (result) {
            console.log("Register", result);
        },
        error: function (errorMessage) {
            console.log("Error", errorMessage);
        }
    })
}

