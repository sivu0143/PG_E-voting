using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class VoterLoginFourthSecurity : System.Web.UI.Page
{
    SqlConnection con;
    SqlCommand cmd;
    SqlDataReader rs;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Label1.Text = "";

            Menu m5 = (Menu)Master.FindControl("Menu5");
            m5.Visible = true;

            con = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
            con.Open();
            if (!IsPostBack)
            {
                if (Session["CVoterID"] != null && Session["EVoterID"] != null)
                {
                    TextBox1.Text = Session["CVoterID"].ToString();
                }
            }


        }
        catch (Exception ex)
        {
            Label1.Text = ex.ToString();
        }

    }


   
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        try
        {
           
            cmd = new SqlCommand("select * from vtable where vid=@vid and otp=@otp", con);
            cmd.Parameters.AddWithValue("vid", Session["EVoterID"].ToString());
            cmd.Parameters.AddWithValue("otp", TextBox2.Text);
            rs = cmd.ExecuteReader();
            bool b = rs.Read();
            rs.Close();
            cmd.Dispose();
            if (b)
                Response.Redirect("PollHere.aspx");
            else
                Label1.Text = "Invalid OTP......";

                    
           

        }
        catch (Exception ex)
        {
            Label1.Text = ex.ToString();
        }

    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        try
        {

            cmd = new SqlCommand("select * from vtable where vid=@vid", con);
            cmd.Parameters.AddWithValue("vid", Session["EVoterID"].ToString());
            rs = cmd.ExecuteReader();
            int otp = 0;
            if (rs.Read())
            {
                otp = int.Parse(rs["otp"].ToString());
                rs.Close();
                cmd.Dispose();
                Label1.Text = "OTP is :" + otp;
            }
            else
            {
                rs.Close();
                cmd.Dispose();
                Label1.Text = "Record Not Found.Check VTable.....";
            }





        }
        catch (Exception ex)
        {
            Label1.Text = ex.ToString();
        }

    }
}