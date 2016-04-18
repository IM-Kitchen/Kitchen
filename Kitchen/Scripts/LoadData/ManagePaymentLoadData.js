var ManagePaymentLoadData = function () {

    this.getUserPayment = function (callback) {
        $.ajax('ManagePayment.aspx/GetUserPayments', {
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