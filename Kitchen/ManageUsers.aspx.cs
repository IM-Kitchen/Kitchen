using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Web.Script.Serialization;

public partial class ManageUsers : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {  
        ClientScript.RegisterStartupScript(this.GetType(),"search", String.Format("javascript:DisplayTable.search();"), true);
        ClientScript.RegisterStartupScript(this.GetType(), "appand", String.Format("javascript:ManageUsers.getButtons();"), true);
        ClientScript.RegisterStartupScript(this.GetType(), "users", String.Format("javascript:ManageUsers.getTableData();"), true);
        //mainDiv.Style.Add("color", "red");        
    }

}
