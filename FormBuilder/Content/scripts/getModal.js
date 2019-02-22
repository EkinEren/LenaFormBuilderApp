$(document).ready(function () {
    $('#btn-popup').click(function () {
        
    });
});


$(document).ready(function () {
    $("#add").click(function () {
        var lastField = $("#formfields div:last");
        var intId = (lastField && lastField.length && lastField.data("idx") + 1) || 1;
        var fieldWrapper = $("<div class=\"fieldwrapper\" id=\"field" + intId + "\"/>");
        fieldWrapper.data("idx", intId);
        var fName = $("<input type=\"text\" class=\"fieldname\" placeholder=\"Alan Adı\" />");
        var fType = $("<select class=\"fieldtype\"><option value=\"input\">STRING</option><option value=\"input type=\"number\"\">NUMBER</option></select>");
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
