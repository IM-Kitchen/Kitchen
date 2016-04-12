var ManageUsers = {

    init: (function () {
        var executed = false;
        users = ["Անուն", "Ազգանուն", "Էլ. հասցե"];

        manageUsersLoadData = new ManageUsersLoadData();
        manageUsersLoadData.getUsers(function (usersData) {
            var table = DisplayTable.drawTable(4, 3, users, usersData);
            mainDiv.appendChild(table);
        });

        topDiv.appendChild(DisplayTable.drawInput());
        topDiv.appendChild(DisplayTable.drawButton("Ավելացնել", "addUser"));


        return function () {
            executed = true;
        };
    })()

};


$("#addUser").click(function () {
    $("#divmodal").dialog({
        title: "my modal",
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
    ManageUsers.init();
}