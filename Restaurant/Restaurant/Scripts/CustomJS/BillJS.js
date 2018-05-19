
    $(document).ready(function () {
        $('#billInfo').hide()
        $('input:text[id="MobNo"]').blur(function (e) {
            phone = $(this).val();
            phone = phone.replace(/[^0-9]/g, '');
            if (phone.length != 10 & phone.length > 0) {
                alert('Phone number must be 10 digits.');
                $('#phonenumber').val('');
                $('#phonenumber').focus();
            }
        });
        var pay = {};
        var bill = {};
        var customer = {};
        var BillID; var TableNo; var CustomerName; var MobNo; var totalBill; var CashTaken; 
        $("p").hide();
        $("#PayBill").hide();    
        $("#SelectedTable").change(function () {
            TableNo = $(this).find('option:selected').val();            
            localStorage.setItem("TableNo", TableNo);
        });
        newTable = TableNo;
        $("#Pay").click(function () {
            $('#billInfo').show();

            var CashTaken = document.getElementById("amountReceived").value;
            BillID = $("#orderIndex").text();
          
            CustomerName = $("#CustomerName").val();
            MobNo = $("#MobNo").val();
            totalBill = $("#totalBillId").text();
            if (CashTaken < totalBill - 1) {
                alert("Enter Proper Amount :: Received amount should be greater than total bill or equals to")
            }
            else {
                $("p").show();
                $("#PayBill").show();
                var amountReturnedValue = CashTaken - totalBill;
                document.getElementById("amountReturned").value = amountReturnedValue;
                bill.TotalPrice = totalBill;
                bill.BillID = BillID;
                bill.TableNo = localStorage.getItem("TableNo");
                $("#getTable").hide();
                var span = document.getElementById("tableIDSelected");
                span.textContent = localStorage.getItem("TableNo");
                bill.CashTaken = CashTaken;
                bill.CashReturned = amountReturnedValue;
                pay.bill = bill;
                customer.Name = CustomerName;
                customer.MobNo = MobNo;
                customer.BillID = BillID;
                pay.customer = customer;
                $("#Pay").hide();
            }
        });
        $("#PayBill").click(function () {      
            $.ajax({
                type: "POST",
                url: '@Url.Action("BillUpdate","Home")',
                datatype: "json",
                contentType: 'application/json; charset=utf-8',
                data: JSON.stringify(pay),
                success: function (data) {
                    alert("Successfully Done");
                    window.print();
                    window.location = '@Url.Action("Index", "Home")';
                },
                error: function (data) {
                    alert("Error While Updating Bill Data")
                    console.log(JSON.stringify(data));
                }
            });
        });
    });
