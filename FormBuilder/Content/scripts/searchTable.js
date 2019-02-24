$(document).ready(function () {
    $("#search").on("keyup", function () {
        var value = $(this).val().toLowerCase();
        $("#formTable tr").filter(function () {
            $(this).toggle($(this).children(':eq(0)').text().toLowerCase().indexOf(value) > -1);
        });
    });
});