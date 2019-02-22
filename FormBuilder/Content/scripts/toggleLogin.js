$(document).ready(function () {
    $('#loginBtn, #registerBtn').click(function () {
        $('.login-container').toggle();
        $('.register-container').toggle();
    });
});