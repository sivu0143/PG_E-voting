using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Text;

public partial class PollHere : System.Web.UI.Page
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
            if (Session["CVoterID"] != null && Session["EVoterID"] != null)
            {
                TextBox1.Text = Session["CVoterID"].ToString();

                cmd = new SqlCommand("select vname,state,cons  from vtable where vid=@vid", con);
                cmd.Parameters.AddWithValue("vid", Session["EVoterID"].ToString());
                rs = cmd.ExecuteReader();
                string vname = "";
                string cons = "",state="";
                if (rs.Read())
                {
                    vname = rs["vname"].ToString();
                    state = rs["state"].ToString();
                    cons = rs["cons"].ToString();
                }
                rs.Close();
                cmd.Dispose();

                int i;
                    i= 0;
                char[] vname1 = vname.ToCharArray();
                byte[] b1 = new byte[vname1.Length];
                while (i < b1.Length)
                {
                    b1[i] = (byte)(vname1[i] - 1);
                    i++;
                }

                vname = Encoding.ASCII.GetString(b1);
                TextBox2.Text = vname;



                i = 0;
                char[] state1 = state.ToCharArray();
                byte[] b2 = new byte[state1.Length];
                while (i < b2.Length)
                {
                    b2[i] = (byte)(state1[i] - 1);
                    i++;
                }

                state = Encoding.ASCII.GetString(b2);
                TextBox3.Text = state;
            


                i = 0;
                char[] cons1 = cons.ToCharArray();
                byte[] b3 = new byte[cons1.Length];
                while (i < b3.Length)
                {
                    b3[i] = (byte)(cons1[i] - 1);
                    i++;
                }

                cons = Encoding.ASCII.GetString(b3);
                TextBox4.Text = cons;

                
                    



            }


        }
        catch (Exception ex)
        {
            Label1.Text = ex.ToString();
        }

    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("ConsDetails.aspx?State="+TextBox3 .Text +"&Cons=" + TextBox4.Text);
    }
}