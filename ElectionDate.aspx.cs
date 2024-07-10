using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data .SqlClient ;
using System.Configuration ;

public partial class ElectionDate : System.Web.UI.Page
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
                Label1.Text = "Select  State ......";
                return;
            }
            string s = DateTime.Now.ToString("dd-MMM-yyyy");
            string s1 = TextBox1.Text;
            DateTime dt1 = DateTime.Parse(s);
            DateTime dt2 = DateTime.Parse(s1);
            int n = dt1.CompareTo(dt2);//dt1 greater return positive
            //equal return 0,dt1 less return negative
            if (n >= 1 || n == 0)
            {
                Label1.Text = "Date Must  Be Greater Than " + dt1.ToString("dd-MMM-yyyy");
                return;
            }


            cmd = new SqlCommand("select * from electiondate where state=@state", con);
            cmd.Parameters.AddWithValue("@state", DropDownList1.SelectedItem.Text);
            rs = cmd.ExecuteReader();
            bool b = rs.Read();
            rs.Close();
            cmd.Dispose();
            if (b)
            {
                Label1.Text = "Record Already Inserted....";
                return;
            }
            cmd = new SqlCommand("insert into electiondate values(@state,@edate)", con);
            cmd.Parameters.AddWithValue("@state", DropDownList1.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@edate", TextBox1.Text);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            Label1.Text = "Record Inserted.....";


        }
        catch (Exception ex)
        {
            if (rs != null) rs.Close();
            Label1.Text = ex.ToString();
        }

    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        DropDownList1.SelectedIndex = 0;
        TextBox1.Text = "";

    }
}
