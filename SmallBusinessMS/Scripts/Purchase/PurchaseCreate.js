$("#addPurchaseDtls").click(function () {
    createRowForPurchase();

});


var index = 0;
function createRowForPurchase() {

    //Get Selected Item from UI
    var selectedItem = getSelectedItem();

    //Check Last Row Index
    var index = $("#PurchaseDetailsTable").children("tr").length;
    var sl = index;

    //For Model List<Property> Binding For MVC
    var indexTd = "<td style='display:none'><input type='hidden' id='Index" + index + "' name='PurchaseDetailses.Index' value='" + index + "' /> </td>";

    //For Serial No For UI
    var slTd = "<td id='Sl" + index + "'> " + (++sl) + " </td>";

    var productId = "<td> <input type='hidden' id='ProductId" + index + "'  name='PurchaseDetailses[" + index + "].ProductId' value='" + selectedItem.ProductId + "' />" + selectedItem.ProductId + "</td>";
    //var productCode = "<td> <input type='hidden' id='productCode" + index + "'  name='PurchaseDetailses[" + index + "].productCode' value='" + selectedItem.productCode + "' /> " + selectedItem.productCode + " </td>";
    //var productCode = "<td>" + selectedItem.Code + " </td>";
    var mfDate = "<td> <input type='hidden' id='ManufacturedDate" + index + "'  name='PurchaseDetailses[" + index + "].ManufacturedDate' value='" + selectedItem.ManufacturedDate + "' />" + selectedItem.ManufacturedDate + "</td>";
    var exDate = "<td> <input type='hidden' id='ExpireDate" + index + "'  name='PurchaseDetailses[" + index + "].ExpireDate' value='" + selectedItem.ExpireDate + "' />" + selectedItem.ExpireDate + "</td>";
    var quantity = "<td> <input type='hidden' id='Quantity" + index + "'  name='PurchaseDetailses[" + index + "].Quantity' value='" + selectedItem.Quantity + "' />" + selectedItem.Quantity + "</td>";
    var unitPrice = "<td> <input type='hidden' id='UnitPrice" + index + "'  name='PurchaseDetailses[" + index + "].UnitPrice' value='" + selectedItem.UnitPrice + "' />" + selectedItem.UnitPrice + "</td>";
    var totalPrice = "<td> <input type='hidden' id='TotalPrice" + index + "'  name='PurchaseDetailses[" + index + "].TotalPrice' value='" + selectedItem.TotalPrice + "' />" + selectedItem.TotalPrice + "</td>";
    var previousMRP = "<td> <input type='hidden' id='PreviousMRP" + index + "'  name='PurchaseDetailses[" + index + "].PreviousMRP' value='" + selectedItem.PreviousMRP + "' />" + selectedItem.PreviousMRP + "</td>";
    var previousCostPrice = "<td> <input type='hidden' id='PreviousCostPrice" + index + "'  name='PurchaseDetailses[" + index + "].PreviousCostPrice' value='" + selectedItem.PreviousCostPrice + "' />" + selectedItem.PreviousCostPrice + "</td>";
    var newCostPrice = "<td> <input type='hidden' id='NewCostPrice" + index + "'  name='PurchaseDetailses[" + index + "].NewCostPrice' value='" + selectedItem.NewCostPrice + "' />" + selectedItem.NewCostPrice + "</td>";
    var newMRP = "<td> <input type='hidden' id='NewMRP" + index + "'  name='PurchaseDetailses[" + index + "].NewMRP' value='" + selectedItem.NewMRP + "' />" + selectedItem.NewMRP + "</td>";
    //var qtyTd = "<td> <input type='hidden' id='ItemQty" + index + "'  name='PurchaseDetailses[" + index + "].Qty' value='" + selectedItem.Qty + "' /> " + selectedItem.Qty + " </td>";


    var newRow = "<tr>" + indexTd + slTd + productId + mfDate + exDate + quantity + unitPrice + totalPrice + newCostPrice + newMRP + " </tr>";

    $("#PurchaseDetailsTable").append(newRow);
    // $("#Code").val("");
    $("#ManufacturedDate").val("");
    $("#ExpireDate").val("");
    $("#Quantity").val("");
    $("#UnitPrice").val("");
    //$("#PreviousMRP").val("");
    $("#TotalPrice").val("");
    //$("#PreviousCostPrice").val("");
    $("#NewCostPrice").val("");
    $("#NewMRP").val("");


}


function getSelectedItem() {
    var productId = $("#ProductId").val();
    var name = $("#Name").val();
    var mfDate = $("#ManufacturedDate").val();
    var exDate = $("#ExpireDate").val();
    var quantity = $("#Quantity").val();
    var unitPrice = $("#UnitPrice").val();
    var pMRP = $("#PreviousMRP").val();
    var totalPrice = $("#TotalPrice").val();
    var pCostPrice = $("#PreviousCostPrice").val();
    var newCostPrice = $("#NewCostPrice").val();
    var newMRP = $("#NewMRP").val();

    var item = {
        "ProductId": productId,
        "Name": name,
        "ManufacturedDate": mfDate,
        "ExpireDate": exDate,
        "Quantity": quantity,
        "UnitPrice": unitPrice,
        "PreviousMRP": pMRP,
        "TotalPrice": totalPrice,
        "PreviousCostPrice": pCostPrice,
        "NewCostPrice": newCostPrice,
        "NewMRP": newMRP
    };




    return item;
}

function calculatePrice() {
    var total = 0;
    $("#TotalPrice").val(total);
    var quantity = parseInt($("#Quantity").val());
    var unitPrice = parseInt($("#UnitPrice").val());
    if (quantity !== null && unitPrice !== null) {
         total = quantity * unitPrice;
        $("#TotalPrice").val(total);
    }
    $("#NewCostPrice").val(unitPrice);
    if (unitPrice !== null) {
        var mrp = (unitPrice * 125) / 100;
        $("#NewMRP").val(mrp);

    }

}