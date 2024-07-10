using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class PollingResults : System.Web.UI.Page
{
    SqlConnection con;
    SqlCommand cmd;
    SqlDataReader rs;
    SqlDataAdapter adp;
    DataTable dt;
    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            Label1.Text = "";

            Menu m1 = (Menu)Master.FindControl("Menu1");
            m1.Visible = true;

            Label2.Visible = false;
            Label3.Visible = false;
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
            con.Open();
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try 
        {
            DropDownList2.Items.Clear();
            Label2.Visible = false;
            Label3.Visible = false;
            GridView1.Visible = false;
            GridView2.Visible = false;
            if (DropDownList1.SelectedIndex == 0)
            {
                Label1.Text = "Select State.....";
                return;
            }
                cmd = new SqlCommand("select distinct(cons) from crtable where state=@state", con);
                cmd.Parameters.AddWithValue("state", DropDownList1.SelectedItem.Text);
                rs = cmd.ExecuteReader();
                DropDownList2.DataSource = rs;
                DropDownList2.DataTextField = "cons";
                DropDownList2.DataBind();
                rs.Close();
                cmd.Dispose();

                DropDownList2.Items.Insert(0, "Select");

            

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
            if (DropDownList1.SelectedIndex == 0 || DropDownList2.SelectedIndex == 0)
            {
                Label1.Text = "Select All Options.....";
                return;
            }


            cmd = new SqlCommand("select * from ratable where state=@state", con);
            cmd.Parameters.AddWithValue("state", DropDownList1.SelectedItem.Text);
            rs = cmd.ExecuteReader();
            bool b = rs.Read();
            rs.Close();
            cmd.Dispose();
            if (b==false)
            {
                Label1.Text = "Result is Not Declared....";
                return;
            }


            adp = new SqlDataAdapter("select r1.uname,r1.pname,c1.symbol,r1.noofvote from rescount r1,crtable c1 where  r1.uname=c1.uname and r1.state=c1.state and r1.cons=c1.cons and c1.state=@state and c1.cons=@cons and noofvote=(select max(noofvote) from rescount where state=@state1 and cons=@cons1)", con);
            adp.SelectCommand.Parameters.AddWithValue("state", DropDownList1.SelectedItem.Text);
            adp.SelectCommand.Parameters.AddWithValue("cons", DropDownList2.SelectedItem.Text);
            adp.SelectCommand.Parameters.AddWithValue("state1", DropDownList1.SelectedItem.Text);
            adp.SelectCommand.Parameters.AddWithValue("cons1", DropDownList2.SelectedItem.Text);
            dt = new DataTable();
            adp.Fill(dt);
            if (dt.Rows.Count != 0)
            {
                Label2.Visible = true;
                GridView1.Visible = true;
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }


            adp = new SqlDataAdapter("select r1.uname,r1.pname,c1.symbol,r1.noofvote from rescount r1,crtable c1 where  c1.uname=r1.uname and r1.state=c1.state and r1.cons=c1.cons and c1.state=@state and c1.cons=@cons  and noofvote<>(select max(noofvote) from rescount where state=@state1 and cons=@cons1)", con);
            adp.SelectCommand.Parameters.AddWithValue("state", DropDownList1.SelectedItem.Text);
            adp.SelectCommand.Parameters.AddWithValue("cons", DropDownList2.SelectedItem.Text);
            adp.SelectCommand.Parameters.AddWithValue("state1", DropDownList1.SelectedItem.Text);
            adp.SelectCommand.Parameters.AddWithValue("cons1", DropDownList2.SelectedItem.Text);
            dt = new DataTable();
            adp.Fill(dt);
            if (dt.Rows.Count != 0)
            {
                Label3.Visible = true;
                GridView2.Visible = true;
                GridView2.DataSource = dt;
                GridView2.DataBind();
            }
            
            






        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }

    }
}