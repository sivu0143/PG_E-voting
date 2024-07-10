using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class AdminViewNomineeDetails : System.Web.UI.Page
{
    SqlConnection con;
    SqlDataAdapter adp;
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Label1.Text = "";
            Menu m2 = (Menu)Master.FindControl("Menu2");
            m2.Visible = true;
         
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
            con.Open();
           
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        try 
        {
            GridView1.Visible = false;
            if (DropDownList1.SelectedIndex == 0)
            {
                Label1.Text = "Select Constituency......";
                return;
            }

            bindgrid();
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }

    }
    void bindgrid()
    {
        try
        {
            adp = new SqlDataAdapter("Select * from crtable where cons=@cons ", con);
            adp.SelectCommand.Parameters.AddWithValue("cons", DropDownList1.SelectedItem.Text);
            ds = new DataSet();
            adp.Fill(ds);
            GridView1.Visible = true;
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }
    }
 

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        try
        {
            if (e.CommandName == "vv")
            {
                string uname = GridView1.DataKeys[int.Parse(e.CommandArgument.ToString())].Value.ToString();
                Session.Add("ACUName", uname);
                Response.Redirect("AdminViewNomineeStatus.aspx");
            }
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }
    }
   
}