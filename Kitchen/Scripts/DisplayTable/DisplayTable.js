var DisplayTable = {
    drawTable : function(rowCount, columnCount, columnNames) {
    table = document.createElement("table");
        for (var i = 0; i < rowCount; i++) {
            tr = document.createElement("tr");
            if(i==0){
                for(var j = 0; j < columnCount; j++) {
                    th=document.createElement("th");
                    var cellText = document.createTextNode(columnNames[j]);
                    th.appendChild(cellText);
                    tr.appendChild(th);
                }
            }else{
                for(var j = 0; j < columnCount; j++) {
                    td=document.createElement("td");
                    var cellText = document.createTextNode("------" + i + "--------");
                    td.appendChild(cellText);
                    tr.appendChild(td);
                }
            }
            table.appendChild(tr);
        }
        mainDiv.appendChild(table);
    },
    
    search : function() {
        input = document.createElement("input");
        topDiv.appendChild(input);
    },
    
    drawButton : function(text) {
       button = document.createElement("button");
       var buttonText = document.createTextNode(text);
       button.appendChild(buttonText);
       topDiv.appendChild(button);
    }
    
};