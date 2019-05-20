/// <reference path="CategoryAdd.js" />
//$("#AddButton").click(function () {
//    createRowForCategory();

//});

$(document.body).on("keyup", "#Name", function () {

    var value = $(this).val();

    if (value !== "") {

        $(this).css("background-color", "burlywood");
    } else {
        $(this).css("background-color", "white");
    }

});

$(document.body).on("keyup", "#Code", function () {

    var value = $(this).val();

    if (value !== "") {

        $(this).css("background-color", "burlywood");
    } else {
        $(this).css("background-color", "white");
    }

});




//var index = 0;
//function createRowForCategory() {

//    //Get Selected Item from UI
//    var selectedItem = getSelectedItem();

//    //Check Last Row Index
//    var index = $("#CategoryDetailsTable").children("tr").length;
//    var sl = index;

//    //For Model List<Property> Binding For MVC
//    var indexTd = "<td style='display:none'><input type='hidden' id='Index" + index + "' name='Categories.Index' value='" + index + "' /> </td>";

//    //For Serial No For UI
//    var slTd = "<td id='Sl" + index + "'> " + (++sl) + " </td>";

//    var nameTd = "<td> <input type='hidden' id='CategoryName" + index + "'  name='Categories[" + index + "].Name' value='" + selectedItem.CategoryName + "' /> " + selectedItem.CategoryName + " </td>";
//    var codeTd = "<td> <input type='hidden' id='CategoryCode" + index + "'  name='Categories[" + index + "].Code' value='" + selectedItem.CategoryCode + "' /> " + selectedItem.CategoryCode + " </td>";


//    var newRow = "<tr>" + indexTd + slTd + nameTd + codeTd + " </tr>";

//    $("#CategoryDetailsTable").append(newRow);
//    $("#CategoryName").val("");
//    $("#CategoryCode").val("");

//}


//function getSelectedItem() {
//    var name = $("#CategoryName").val();
//    var code = $("#CategoryCode").val();

//    var category = {
//        "CategoryName": name,
//        "CategoryCode": code
//    };




//    return category;
//}

