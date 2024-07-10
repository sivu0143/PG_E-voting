using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class FORegistration : System.Web.UI.Page
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
        catch (Exception ex)
        {
            Label1.Text = ex.ToString();
        }

    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        try
        {

            if (DropDownList1.SelectedIndex == 0)
            {
                Label1.Text = "Select Constituency.....";
                return;
            }

            cmd = new SqlCommand("select cons from fieldreg where cons=@cons", con);
            cmd.Parameters.AddWithValue("cons", DropDownList1.SelectedItem.Text);
            rs = cmd.ExecuteReader();
            bool b = rs.Read();
            rs.Close();
            cmd.Dispose();
            if (b)
            {
                Label1.Text = DropDownList1.SelectedItem.Text + " Constituency Field Officer Details Already Registered.....";
                return;
            }
            cmd = new SqlCommand("insert into fieldreg values(@name,@id,@pwd,@cons)", con);
            cmd.Parameters.AddWithValue("@name", TextBox1.Text);
            cmd.Parameters.AddWithValue("@id", TextBox2.Text);
            cmd.Parameters.AddWithValue("@pwd", TextBox3.Text);
            cmd.Parameters.AddWithValue("@cons", DropDownList1.SelectedItem.Text);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
           // Response.Redirect("FOLogin.aspx");
            Label1.Text = "Register New Field Officer Details....";

        }
        catch (Exception ex)
        {
            Label1.Text = ex.ToString();
        }
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        TextBox1.Text = "";
        TextBox2.Text = "";
        DropDownList1.SelectedIndex = 0;
        TextBox1.Focus();
    }
}