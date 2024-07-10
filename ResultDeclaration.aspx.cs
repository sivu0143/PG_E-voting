using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class ResultDeclaration : System.Web.UI.Page
{
    SqlConnection con;
    SqlCommand cmd;
    SqlDataReader rs;
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
        catch (Exception ex )
        {
            Label1.Text = ex.Message;
        }

    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            TextBox1.Text = "";
            if (DropDownList1.SelectedIndex == 0)
            {
                Label1.Text = "Select State....";
                return;
            }

            cmd = new SqlCommand("select * from ratable where state=@state", con);
            cmd.Parameters.AddWithValue("state", DropDownList1.SelectedItem.Text);
            rs = cmd.ExecuteReader();
            bool b = rs.Read();
            rs.Close();
            cmd.Dispose();
            if (b)
            {
                Label1.Text = "Result Already Declared.....";
                LinkButton1.Enabled = false;
                return;
            }


            cmd = new SqlCommand("select edate from electiondate  where state=@state", con);
            cmd.Parameters.AddWithValue("state", DropDownList1.SelectedItem.Text);
            rs = cmd.ExecuteReader();
            if (rs.Read())
            {
                TextBox1.Text = DateTime.Parse(rs["edate"].ToString()).ToString("dd-MMM-yyyy");
                rs.Close();
                cmd.Dispose();
            }
            else
            {
                rs.Close();
                cmd.Dispose();
                Label1.Text = "Record Not Found.Check ElectionDate Table....";
                return;
            }
            DateTime cd =DateTime.Parse ( DateTime.Now.ToString("dd-MMM-yyyy"));
            DateTime ed =DateTime .Parse ( TextBox1.Text);
            TimeSpan ts = cd.Subtract(ed);
            int d = ts.Days;
            if (d <= 0)
            {
                Label1.Text = "Election Date Not Completed.....";
                LinkButton1.Enabled = false;

            }
            else
            {
                LinkButton1.Enabled = true;
            }



          
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
            if (DropDownList1.SelectedIndex == 0)
            {
                Label1.Text = "Select State.....";
                return;
            }
            cmd = new SqlCommand("select * from ratable where state=@state", con);
            cmd.Parameters.AddWithValue("state", DropDownList1.SelectedItem.Text);
            rs = cmd.ExecuteReader();
            bool b = rs.Read();
            rs.Close();
            cmd.Dispose();
            if (b)
            {
                Label1.Text = "Result Already Declared.....";
                return;
            }
            cmd = new SqlCommand("insert into ratable values(@state,@radate)", con);
            cmd.Parameters.AddWithValue("state", DropDownList1.SelectedItem.Text);
            cmd.Parameters.AddWithValue("radate", DateTime.Now.ToString("dd-MMM-yyyy"));
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            Label1.Text = "Result Declared......";

        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }

    }
}