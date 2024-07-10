using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class AdminViewElectionDate : System.Web.UI.Page
{
    SqlConnection con;
    SqlCommand cmd;
    SqlDataAdapter adp;
    DataTable dt;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Label1.Text = "";

            Menu m2 = (Menu)Master.FindControl("Menu2");
            m2.Visible = true;
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
            con.Open();
            if (!IsPostBack)
                bindgrid();
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }
    }

    void bindgrid()
    {
        adp = new SqlDataAdapter("select * from electiondate", con);
        dt = new DataTable();
        adp.Fill(dt);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try 
        {
            string state = GridView1.DataKeys[e.RowIndex].Values[0].ToString();
            string edate = GridView1.DataKeys[e.RowIndex].Values[1].ToString();

            cmd = new SqlCommand("delete from electiondate where state=@state and edate=@edate", con);
            cmd.Parameters.AddWithValue("state", state);
            cmd.Parameters.AddWithValue("edate", edate);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            bindgrid();

        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }
    }
}