var orderArray = [];
var orderObject = {};
var menuObject = {};
var orderJSON = {};
var TableId;
$(document).ready(function () {

    // code to read selected table row cell data (values).
    $("#tableTable").on('click', '.tableButton', function () {

        var Index = ($(this).parents('td').index());
        TableId = $("#tableId-" + Index).text()

    });
    //Selected menu is stored in object and array
    //$('#tableDiv').append('<table class="table table-bordered table-hover"><thead><tr><th>ID</th><th>Name</th><th>Price</th><th>Quantity</th></tr></thead><tbody>');
    $("#MenuTable").on('click', '.Add', function () {
        menuObject.TableNo = TableId;
        if (TableId == null) {
            alert("Please Select Table No first");
        }
        else {

            $("#tableNo").html(TableId);
            // get the current row
            var Index = ($(this).parents('tr').index()) - 1;
            var currentRow = $(this).closest("tr");
            var colID = currentRow.find("td:eq(0)").text(); // get current row 1st TD value
            var colName = currentRow.find("td:eq(1)").text(); // get current row 2nd TD
            var colPrice = currentRow.find("td:eq(2)").text();
            var colQty = $("#qty-" + Index).val()
            if (colQty == "")
                alert("Please Enter Quantity");
            else if (jQuery.isNumeric(colQty) && colQty > 0) {
                var date = new Date();
                orderObject.MenuId = colID;
                orderObject.Name = colName;
                orderObject.Price = colPrice;
                orderObject.Quantity = colQty;
                // orderArray.push(orderObject);
                //menuObject.Order = orderObject;
                //Order List For JSON
                menuObject.OrderId = colID;
                menuObject.Quantity = colQty;
                menuObject.OrderTime = date.toLocaleString();
                orderArray.push(menuObject);
                menuObject = {};
                //console.log(orderArray);
                console.log(orderArray);
                orderJSON = JSON.stringify(orderObject);
                $('#tableDiv').append('<tr>');
                for (var key in orderObject) {
                    $('#tableDiv').append('<td>' + orderObject[key] + '</td>');
                }
                $('#tableDiv').append('</tr>');
            }
            else {
                alert("Please Enter Quantity in positive number");
            }
        }
    });
    $("#PlaceOrder").click(function () {
        if (orderArray[0] == null) {
            alert("Please Select Table No first");
        }
        else {
            var jsnData = JSON.stringify({ 'jsnData': orderArray });
            $.ajax({
                type: "POST",
                url: '@Url.Action("OrderPlacedData", "Home")',
                datatype: "json",
                contentType: 'application/json; charset=utf-8',
                data: jsnData,
                success: function (data) {
                    alert("Order Placed Successfully!!!");
                    window.location = '@Url.Action("Index", "Home")';
                }
            });
        }
    });
});