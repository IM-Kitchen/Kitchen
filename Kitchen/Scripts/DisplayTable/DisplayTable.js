var DisplayTable = {
    drawTable: function (rowCount, columnCount, columnNames, data) {
        var myObject = eval("(" + data + ")");
        table = document.createElement("table");

        for (var i = 0; i < rowCount; i++) {
            tr = document.createElement("tr");
            if (i == 0) {
                for (var j = 0; j < columnCount; j++) {
                    th = document.createElement("th");
                    var cellText = document.createTextNode(columnNames[j]);
                    th.appendChild(cellText);
                    tr.appendChild(th);
                }
            } else {

                for (var key in myObject[i - 1]) {

                    td = document.createElement("td");

                    var cellText = document.createTextNode(myObject[i - 1][key]);
                    td.appendChild(cellText);
                    tr.appendChild(td);
                }
            }

            table.appendChild(tr);
        }
        table.setAttribute("id", "tableId");
        return table;
    },

    drawInput: function () {
        input = document.createElement("input");
        return input;
    },

    drawButton: function (text, buttonId) {
        button = document.createElement("button");
        var buttonText = document.createTextNode(text);
        button.appendChild(buttonText);
        button.setAttribute("onclick", "return false");
        button.setAttribute("id", buttonId);
        return button;
    }

};