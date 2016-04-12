using System;
using System.Web.Services;

namespace Kitchen
{
    public partial class ManageDailyData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //ClientScript.RegisterStartupScript(this.GetType(), "appand1", String.Format("javascript:ManageDailyData.getInput();"), true);
          
        }
        [WebMethod]
        public static string GetUsers()
        {
            return "[{'name':'Naira','lastname':'Poghosyan', 'email': 'naira@mail.ru'}, {'name':'Marine','lastname':'Grigoryan', 'email': 'marishok@mail.ru'}, {'name':'Tamara','lastname':'Avagyan', 'email': 'tamara@mail.ru'}]";
        }
    }
}