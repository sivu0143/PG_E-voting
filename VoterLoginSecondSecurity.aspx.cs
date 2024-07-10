using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;


public partial class VoterLoginSecondSecurity : System.Web.UI.Page
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


    bool checkcompare(byte[] b, byte[] b1)
    {
        bool bo = false;
        //   byte[] b = check(fname);
        if (b.Length == b1.Length)
        {
            for (int i = 0; i < b.Length; i++)
            {
                if (b[i] == b1[i])
                    bo = true;
                else
                {
                    bo = false;
                    break;
                }
            }
        }
        else
        {
            return false;
        }
        if (bo == true)
            return true;
        else
            return false;

    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        try
        {
            if (FileUpload1.HasFile == false)
            {
                Label1.Text = "Select Face Recognization Image......";
                return;
            }

            cmd = new SqlCommand("select frecog from vtable where vid=@vid", con);
            cmd.Parameters.AddWithValue("vid", Session["EVoterID"].ToString());
            rs = cmd.ExecuteReader();
            byte[] frecog = { 0 };
            if (rs.Read())
            {
                frecog = (byte[])rs["frecog"];
                rs.Close();
                cmd.Dispose();
            }
            else
            {
                rs.Close();
                cmd.Dispose();
                Label1.Text = "Record Not Found.Check VTable.....";
                return;
            }

            byte[] bb = FileUpload1.FileBytes;
            bool bo = checkcompare(frecog, bb);
            if (bo == false)
            {
                Label1.Text = "Invalid Face Recognization Image.Select Correct Face Recognization Image.....";
                return;
            }

          //  Response.Redirect("VoterLoginSecondSecurity.aspx");
          //  Response.Redirect("VoterViewOurDetails.aspx");

           // Response.Redirect("PollHere.aspx");
            Response.Redirect("VoterLoginThirdSecurity.aspx");

        }
        catch (Exception ex)
        {
            Label1.Text = ex.ToString();
        }

    }
}