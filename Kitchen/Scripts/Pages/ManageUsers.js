var ManageUsers ={

getTableData : function(){
    users=["Name","Surname","Email"];
    DisplayTable.drawTable(4, 3, users);
},

getButtons : function(){
    DisplayTable.drawButton("Ավելացնել");
},

}
