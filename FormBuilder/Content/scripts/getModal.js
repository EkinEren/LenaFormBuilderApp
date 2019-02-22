$(document).ready(function () {
    $('#btn-popup').click(function (e) {
        e.preventDefault();
        var lastField = $("#formfields div:last");
        var intId = (lastField && lastField.length && lastField.data("idx"));

        var formname = $("#formName").val();
        var desc = $("#formDesc").val();
        var today = new Date();
        var dd = today.getDate();
        var mm = today.getMonth() + 1;
        var yyyy = today.getFullYear();

        if (dd < 10) {
            dd = '0' + dd;
        }

        if (mm < 10) {
            mm = '0' + mm;
        }

        today = yyyy + '-' + dd + '-' + mm;

        var fields = [];

        for (var i = 0; i < intId; i++) {
            fields[i] = {
                required: $("#field" + (i + 1)).children('input[type=checkbox]').prop("checked") ? true : false,
                name: $("#field" + (i + 1)).children('input[type=text]').val(),
                dataType: $("#field" + (i + 1)).children('select').children(':selected').text()
            };
        }

        var newForm = new Object();
        newForm.Name = formname;
        newForm.Description = desc;
        newForm.CreatedAt = today;
        newForm.Fields = fields;

        $.ajax({
            type: "POST",
            url: 'Home/CreateForm',
            contentType: "application/json;charset=utf-8",
            data: JSON.stringify(newForm),
            method: "POST",
            dataType: 'json',
            success: function () {
                $("#addSuccess").css("color", "green");
                $("#addSuccess").text('Form başarıyla eklendi!');
            },
            failure: function () {
                $("#addSuccess").css("color", "red");
                $("#addSuccess").text('Birşeyler ters gitti ve Form eklenemedi.');
            },
            error: function (jqXHR, textStatus, errorThrown) {
                console.log(errorThrown);
            }
        }); 
    });
});


$(document).ready(function () {
    $("#add").click(function () {
        var lastField = $("#formfields div:last");
        var intId = (lastField && lastField.length && lastField.data("idx") + 1) || 1;
        var fieldWrapper = $("<div class=\"fieldwrapper\" id=\"field" + intId + "\"/>");
        fieldWrapper.data("idx", intId);
        var fName = $("<input type=\"text\" class=\"fieldname\" placeholder=\"Alan Adı\" />");
        var fType = $("<select class=\"fieldtype\"><option value=\"input\">STRING</option><option value=\"number\" type=\"number\">NUMBER</option></select>");
        var fReq = $("<input type=\"checkbox\" class=\"fieldreq\">");
        var removeButton = $("<input type=\"button\" class=\"remove\" value=\"Sil\" />");
        removeButton.click(function () {
            $(this).parent().remove();
        });
        fieldWrapper.append(fName);
        fieldWrapper.append(fType);
        fieldWrapper.append(fReq);
        fieldWrapper.append(removeButton);
        $("#formfields").append(fieldWrapper);
    });
});
