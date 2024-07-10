using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class FOLogin : System.Web.UI.Page
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
            cmd = new SqlCommand("select * from fieldreg where id=@id and pwd=@pwd", con);
            cmd.Parameters.AddWithValue("@id", TextBox1 .Text );
            cmd.Parameters.AddWithValue("@pwd", TextBox2 .Text );
            rs = cmd.ExecuteReader();
            if (rs.Read())
            {
                Session.Add("id", TextBox1.Text);
                Session.Add("FOCons", rs["cons"].ToString());
                rs.Close();
                cmd.Dispose();
               Response.Redirect("FieldOfficerViewVoterDetails.aspx");
            }
            else
            {
                rs.Close();
                cmd.Dispose();
                Label1.Text = "Invalid UserName Or Password.....";

            }
          
        }
        catch (Exception ex)
        {
            if (rs != null)
                rs.Close();
            Label1.Text = ex.Message;
        }
    }
}