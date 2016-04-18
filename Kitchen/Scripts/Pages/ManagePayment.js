var ManagePayment = {

    init: (function () {
        var executed = false;
        users = ["Անուն", "Ազգանուն", "Ծախսեր", "-"];


        managePaymentLoadData = new ManagePaymentLoadData();
        managePaymentLoadData.getUserPayment(function (usersData) {
            alert(usersData);
            var table = DisplayTable.drawTable(4, 4, users, usersData);
            for (var i = 1; i < table.rows.length; i++) {
                td = DisplayTable.drawButton("Ավելացնել", "addPayment");
                td1 = DisplayTable.drawButton("Փոփոխել", "changePayment");
                table.rows[i].appendChild(td);
                table.rows[i].appendChild(td1);
            }
            mainDiv.appendChild(table);
        });
        
        topDiv.appendChild(DisplayTable.drawInput());
        mainDiv.appendChild(DisplayTable.drawButton("Մուտքագրել", "inputDailyData"));

        return function () {
            executed = true;
        };
    })()

}

$("#addPayment").click(function () {
    $("#divmodal").dialog({
        title: "Add payment for user",
        width: 500,
        heigth: 500,
        modal: true,
        buttons: {
            Close: function () {
                $(this).dialog('close');
            }
        }
    });
});

$("#changePayment").click(function () {
    $("#divmodal").dialog({
        title: "Change payment for user",
        width: 500,
        heigth: 500,
        modal: true,
        buttons: {
            Close: function () {
                $(this).dialog('close');
            }
        }
    });
});

window.onload = function () {
    ManagePayment.init();
}