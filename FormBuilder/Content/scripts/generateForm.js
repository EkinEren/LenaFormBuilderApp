$(document).ready(function () {
    $("#preview").click(function () {
        var values = '@Html.Raw(Json.Encode(Model.Fields));';
        var fname = $("#fname").val();
        var fieldSet = $("<fieldset id=\"yourform\"><legend>" + fname + "</legend></fieldset>");
        console.log(values);
        alert('hi!');
        //$("#buildyourform div").each(function () {
        //    var id = "input" + $(this).attr("id").replace("field", "");
        //    var label = $("<label for=\"" + id + "\">" + $(this).find("input.fieldname").first().val() + "</label>");
        //    var input;
        //    switch ($(this).find("select.fieldtype").first().val()) {
        //        case "checkbox":
        //            input = $("<input type=\"checkbox\" id=\"" + id + "\" name=\"" + id + "\" />");
        //            break;
        //        case "textbox":
        //            input = $("<input type=\"text\" id=\"" + id + "\" name=\"" + id + "\" />");
        //            break;
        //        case "textarea":
        //            input = $("<textarea id=\"" + id + "\" name=\"" + id + "\" ></textarea>");
        //            break;
        //    }
        //    fieldSet.append(label);
        //    fieldSet.append(input);
        //});
        //$("body").append(fieldSet);
    });
});