using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;

public partial class VoterLogin : System.Web.UI.Page
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
            string vid = TextBox1.Text;
            char[] vid1 = vid.ToCharArray();
            byte[] b1 = new byte[vid1.Length];
            int j1 = 0;

            while (j1 < b1.Length)
            {
                b1[j1] = (byte)(vid1[j1] + 1);
                j1++;
            }
            vid = Encoding.ASCII.GetString(b1);



            string status = "Selected";
            char[] status1 = status.ToCharArray();
            byte[] b9 = new byte[status1.Length];
            int j = 0;

            while (j < b9.Length)
            {
                b9[j] = (byte)(status1[j] + 1);
                j++;
            }

            status = Encoding.ASCII.GetString(b9);

            cmd = new SqlCommand("select * from vtable where vid=@vid and pword=@pword and status=@status", con);
            cmd.Parameters.AddWithValue("vid", vid);
            cmd.Parameters.AddWithValue("pword", TextBox2.Text);
            cmd.Parameters.AddWithValue("status", status);
            rs = cmd.ExecuteReader();
            bool b = rs.Read();
            rs.Close();
            cmd.Dispose();
            if (b)
            {
                Session.Add("CVoterID", TextBox1.Text);
                Session.Add("EVoterID", vid);
               // Response.Redirect("VoterLoginFirstSecurity.aspx");

                Response.Redirect("VoterViewOurDetails.aspx");
            }
            else
            {
                Label1.Text = "Invalid VoterID Or Password Or Status Not Selected......";
            }
        }
        catch (Exception ex)
        {
            Label1.Text = ex.ToString();
        }
    }
}