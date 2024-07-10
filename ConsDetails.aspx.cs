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

public partial class ConsDetails : System.Web.UI.Page
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

            Menu m5 = (Menu)Master.FindControl("Menu5");
            m5.Visible = true;

            con = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
            con.Open();
            if (!IsPostBack)
            {
                if (Request.QueryString.Get("State") != null && Request.QueryString.Get("Cons") != null && Session ["EVoterID"]!=null)
                {
                    TextBox1.Text = Request.QueryString.Get("State");
                    TextBox2.Text = Request.QueryString.Get("Cons");


                    adp = new SqlDataAdapter("select * from crtable where state=@state and cons=@cons", con);
                    adp.SelectCommand.Parameters.AddWithValue("state", TextBox1.Text);
                    adp.SelectCommand.Parameters.AddWithValue("cons", TextBox2.Text);
                    dt = new DataTable();
                    adp.Fill(dt);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();


                }
            }
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

            if (e.CommandName == "vh")
            {

                cmd = new SqlCommand("select * from poll where vid=@vid", con);
                cmd.Parameters.AddWithValue("vid", Session["EVoterID"].ToString());
                rs = cmd.ExecuteReader();
                bool b = rs.Read();
                rs.Close();
                cmd.Dispose();
                if (b)
                {
                    Label1.Text = "Already Voted.....";
                    return;
                }

                string  uname=GridView1 .DataKeys [int.Parse (e.CommandArgument .ToString ())].Values [0].ToString ();
                string pname = GridView1.DataKeys[int.Parse(e.CommandArgument.ToString())].Values[1].ToString();

                cmd = new SqlCommand("select vname from vtable where vid=@vid", con);
                cmd.Parameters.AddWithValue("vid", Session["EVoterID"].ToString());
                string vname = "";
                rs = cmd.ExecuteReader();
                if (rs.Read())
                {
                    vname = rs["vname"].ToString();
                }
                rs.Close();
                cmd.Dispose();

                cmd = new SqlCommand("select isnull(max(tid), 0)+ 1 from poll", con);
                int tid = int.Parse(cmd.ExecuteScalar().ToString());
                cmd.Dispose();

                cmd = new SqlCommand("insert into poll values(@vid,@vname,@state,@cons,@pname,@uname,@tid,@status)", con);
                cmd.Parameters .AddWithValue ("vid", Session["EVoterID"].ToString());
                cmd.Parameters .AddWithValue ("vname",vname );
                cmd.Parameters .AddWithValue ("state",TextBox1 .Text );
                cmd.Parameters .AddWithValue ("cons",TextBox2 .Text );
                cmd.Parameters .AddWithValue ("pname",pname );
                cmd.Parameters.AddWithValue("uname", uname);
                cmd.Parameters.AddWithValue("tid", tid);
                cmd.Parameters.AddWithValue("status", "Accepted and Counted");
                int no= cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = new SqlCommand("select * from  rescount  where uname=@uname and pname=@pname and state=@state and cons=@cons", con);
                cmd.Parameters.AddWithValue("uname", uname);
                cmd.Parameters.AddWithValue("pname", pname);
                cmd.Parameters.AddWithValue("state", TextBox1.Text);
                cmd.Parameters.AddWithValue("cons", TextBox2.Text);
                rs = cmd.ExecuteReader();
                b = rs.Read();
                rs.Close();
                cmd.Dispose();

                if (b)
                {
                    cmd = new SqlCommand("update rescount set noofvote=noofvote+1 where uname=@uname and pname=@pname and state=@state and cons=@cons", con);
                    cmd.Parameters.AddWithValue("uname", uname);
                    cmd.Parameters.AddWithValue("pname", pname);
                    cmd.Parameters.AddWithValue("state", TextBox1.Text);
                    cmd.Parameters.AddWithValue("cons", TextBox2.Text);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    Response.Redirect("Success.aspx?TID="+tid );
                }
                else
                {
                    cmd = new SqlCommand("insert into rescount values(@uname,@pname,@state,@cons,@noofvote)", con);
                    cmd.Parameters.AddWithValue("uname", uname);
                    cmd.Parameters.AddWithValue("pname", pname);
                    cmd.Parameters.AddWithValue("state", TextBox1.Text);
                    cmd.Parameters.AddWithValue("cons", TextBox2.Text);
                    cmd.Parameters.AddWithValue("noofvote", "1");
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    Response.Redirect("Success.aspx?TID="+tid);
                }
            }
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }

    }
}