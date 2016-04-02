var ManageDailyData = {

    getTableData: function () {
        users = ["Անուն", "Ազգանուն", "-"];
        DisplayTable.drawTable(3, 3, users);
    },

    getButtons: function () {
        DisplayTable.drawButton("Մուտքագրել");
    },

}