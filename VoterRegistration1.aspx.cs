using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class VoterRegistration1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Label1.Text = "";

            Menu m1 = (Menu)Master.FindControl("Menu1");
            m1.Visible = true;

            if (Session["AVoterID"] != null && Session["AFRImage"] != null && Session["AQRCodeImage"] != null && Session["AQRCodeLocation"] != null && Session["AFRImageLocation"] != null)
            {
                Label2.Text = Session["AVoterID"].ToString();
                Label3.Text = Session["AQRCodeLocation"].ToString();
                Image1.ImageUrl ="~/Temp/"+ Session["AFRImageLocation"].ToString();
             //   Image2.ImageUrl = Server .MapPath ("QRCode\\"+Session["AQRCodeImage"].ToString());
                Image2.ImageUrl = "~\\QRCode\\" + Session["AQRCodeImage"].ToString();
            }
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }
    }
}