var ManageUsersLoadData = function () {

    this.getUsers = function (callback) {
        $.ajax('ManageUsers.aspx/GetUsers', {
            method: 'post',
            contentType: 'application/json; charset=utf-8',
            success: function (response) {
                callback(response.d);
            },
            error: function () {
                alert("ERROR: There are no data to show.");
            }
        })
    }
};