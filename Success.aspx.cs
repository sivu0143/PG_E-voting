using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Success : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Label1.Text = "";
            Menu m5 = (Menu)Master.FindControl("Menu5");
            m5.Visible = true;
            if (!IsPostBack)
            {
                if (Request.QueryString.Get("TID") != null)
                    Label2.Text = "Your Transaction ID :" + Request.QueryString.Get("TID");
            }
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        
        }
        
    }
}