using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class UserViewVotingStatus : System.Web.UI.Page
{
    SqlConnection con;
    SqlDataAdapter adp;
    DataTable dt;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {


            Label1.Text = "";

            Menu m5 = (Menu)Master.FindControl("Menu5");
            m5.Visible = true;

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
            DetailsView1.Visible = false;
            if (Session["EVoterID"] != null)
            {
                adp = new SqlDataAdapter("select * from poll where vid=@vid and tid=@tid", con);
                adp.SelectCommand.Parameters.AddWithValue("vid", Session["EVoterID"].ToString());
                adp.SelectCommand.Parameters.AddWithValue("tid", TextBox1.Text);
                dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count == 0)
                {
                    Label1.Text = "Invalid Details.....";
                    return;
                }
                DetailsView1.Visible = true;
                DetailsView1.DataSource = dt;
                DetailsView1.DataBind();
            }

        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }
    }
}