using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class AdminViewNomineeStatus : System.Web.UI.Page
{
    SqlConnection con;
    SqlDataAdapter adp;
    DataSet ds;
    SqlCommand cmd;
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
                if (Session["ACUName"] != null)
                    bindview();
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }

    }

    void bindview()
    {
        try
        {
            adp = new SqlDataAdapter("Select * from crtable  where uname=@uname", con);
            adp.SelectCommand.Parameters.AddWithValue("uname", Session["ACUName"].ToString());
            ds = new DataSet();
            adp.Fill(ds);
            DetailsView1.DataSource = ds;
            DetailsView1.DataBind();
            string status = ds.Tables[0].Rows[0]["status"].ToString();
            RadioButtonList1.Text = status;
            if (status.Equals("Accepted"))
                RadioButtonList1.Enabled = false;

        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }
    }
    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (Session["ACUName"] != null)
            {
                cmd = new SqlCommand("update crtable set status=@status where uname=@uname", con);
                cmd.Parameters.AddWithValue("status", RadioButtonList1.SelectedItem.Text);
                cmd.Parameters.AddWithValue("uname", Session["ACUName"].ToString());
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                Label1.Text = "Your Status Is Updated.....";
                bindview();
            }
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }
    }
}