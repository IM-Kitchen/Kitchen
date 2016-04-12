var ManageDailyData = {

    init: (function() {
        var executed = false;
        users = ["Անուն", "Ազգանուն", "Էլ. հասցե", "-"];


        dailyLoadData = new DailyLoadData();
        dailyLoadData.getUsers(function(usersData) {
            var table = DisplayTable.drawTable(4, 4, users, usersData);
            for (var i = 1; i < table.rows.length; i++) {
                td = document.createElement("td");
                checkbox = document.createElement("input");
                checkbox.setAttribute("type", "checkbox");
                checkbox.setAttribute("name", "checkbox" + i);
                checkbox.setAttribute("checked", "checked");
                td.appendChild(checkbox);
                table.rows[i].appendChild(td);
            }
            mainDiv.appendChild(table);
        });


        topDiv.appendChild(DisplayTable.drawInput());
        topDiv.appendChild(DisplayTable.drawInput());
        mainDiv.appendChild(DisplayTable.drawButton("Մուտքագրել", "inputDailyData"));

        return function() {
            executed = true;
        };
    })()

}
window.onload = function() {
    ManageDailyData.init();
}