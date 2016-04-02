var ManageUsers ={

getTableData : function(){
    users = ["Անուն", "Ազգանուն", "Էլ. հասցե"];
    DisplayTable.drawTable(4, 3, users);
},

getButtons : function(){
    DisplayTable.drawButton("Ավելացնել");
},

}
