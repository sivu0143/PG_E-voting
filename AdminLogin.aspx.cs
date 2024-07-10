using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminLogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Label1.Text = "";

        Menu m1 = (Menu)Master.FindControl("Menu1");
        m1.Visible = true;


    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        if (TextBox1.Text.Equals("Siva") && TextBox2.Text.Equals("Siva"))
            Response.Redirect("AdminViewNomineeDetails.aspx");
        else
            Label1.Text = "Invalid UserName Or Password......";

    }
}