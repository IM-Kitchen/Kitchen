using System;
using System.Web.Services;

public partial class ManagePayment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //  ClientScript.RegisterStartupScript(this.GetType(), "search", String.Format("javascript:DisplayTable.search();"), true);
    }

    [WebMethod]
    public static string GetUserPayments()
    {
        return "[{'name':'Naira','lastname':'Poghosyan', 'payment': '5000'}, {'name':'Marine','lastname':'Grigoryan', 'payment': '5000'}, {'name':'Tamara','lastname':'Avagyan', 'payment': '5000'}]";
    }
}

 