using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class CandidateLogin : System.Web.UI.Page
{
    SqlConnection con;
    SqlCommand cmd;
    SqlDataReader rs;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Label1.Text = "";

            Menu m1 = (Menu)Master.FindControl("Menu1");
            m1.Visible = true;
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
            con.Open();


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
            cmd = new SqlCommand("select * from crtable where uname=@uname and pword=@pword", con);
            cmd.Parameters.AddWithValue("@uname", TextBox1.Text);
            cmd.Parameters.AddWithValue("@pword", TextBox2.Text);
            rs = cmd.ExecuteReader();
            if (rs.Read())
            {
                Session.Add("CUName", TextBox1.Text);
                rs.Close();

                cmd.Dispose();
                Response.Redirect("ViewCandidateDetails.aspx");
            }
            else
            {
                rs.Close();
                cmd.Dispose();
                Label1.Text = "Invalid UserName Or Password.....";

            }



        }
        catch (Exception e1)
        {
            if (rs != null)
                rs.Close();
            Response.Write(e1.ToString());
        }
    }
}