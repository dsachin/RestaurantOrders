$(document).ready(function () {
    var order = {};

    var EditedQuantity = [];
    //var EditTableId = {};
    $("#MenuTable").on('click', '.Add', function () {
        // menuObject.TableNo = TableId;
        var Index = ($(this).parents('tr').index()) - 1;
        var currentRow = $(this).closest("tr");
        var updatedQuantity = currentRow.find("td:eq(2)").text();
        var colQty = $("#qty-" + Index).val()
        EditedQuantity.push(colQty);
        order.EditedQuantity = EditedQuantity;
        alert("Quantity Updated")
    });
    $("#DeleteOrder").click(function () {
        // var jsnData = JSON.stringify({ 'jsnData': orderData });
        //EditTableId.editTableId = $("#TableNo");
        //order.EditTableId = EditTableId;
        order.EditTableId = localStorage.getItem("TableNoEdit");
        //var OrderDeletion = {};
        //OrderDeletion.orderDeletion = 1;
        order.OrderDeletion = true;
        $.ajax({
            type: "POST",
            url: '@Url.Action("EditOrderUpdateData", "Home")',
            datatype: "json",
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify(order),
            success: function (data) {
                alert("Order Updated Successfully!!!");
                window.location = '@Url.Action("Index", "Home")';
            },
            error: function (data) {
                alert("Error While Updating Data")
                console.log(JSON.stringify(data));
            }
        });
    });
    $("#PlaceOrder").click(function () {
        // EditTableId.editTableId = $("#TableNo");
        order.EditTableId = localStorage.getItem("TableNoEdit");
        $.ajax({
            type: "POST",
            url: '@Url.Action("EditOrderUpdateData", "Home")',
            datatype: "json",
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify(order),
            success: function (data) {
                alert("Order Updated Successfully!!!");
                window.location = '@Url.Action("Index", "Home")';
            },
            error: function (data) {
                alert("Error While Updating Data")
                console.log(JSON.stringify(data));
            }
        });
    });
});