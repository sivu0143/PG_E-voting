using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;


public partial class VoterLoginFirstSecurity : System.Web.UI.Page
{
    SqlConnection con;
    SqlCommand cmd;
    SqlDataReader rs;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Label1.Text = "";

            Menu m5= (Menu)Master.FindControl("Menu5");
            m5.Visible = true;
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
            con.Open();
            if (!IsPostBack)
            {
                if (Session["CVoterID"] != null && Session["EVoterID"] != null)
                {
                    TextBox1.Text = Session["CVoterID"].ToString();
                }
            }
        }
        catch (Exception ex)
        {
            Label1.Text = ex.ToString();
        }

    }


    bool checkcompare(byte[] b, byte[] b1)
    {
        bool bo = false;
        //   byte[] b = check(fname);
        if (b.Length == b1.Length)
        {
            for (int i = 0; i < b.Length; i++)
            {
                if (b[i] == b1[i])
                    bo = true;
                else
                {
                    bo = false;
                    break;
                }
            }
        }
        else
        {
            return false;
        }
        if (bo == true)
            return true;
        else
            return false;

    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        try 
        {
            cmd = new SqlCommand("select state from vtable where vid=@vid", con);
            cmd.Parameters.AddWithValue("vid", Session["EVoterID"].ToString());
            string state = "";
            rs = cmd.ExecuteReader();
            if (rs.Read())
            {
                state = rs["state"].ToString();
                rs.Close();
                cmd.Dispose();
            }
            else
            {
                rs.Close();
                cmd.Dispose();
                Label1.Text = "Record Not Found . Check VTable......";
                return;
            }


            char[] state1 = state.ToCharArray();
            byte []b1=new byte [state1 .Length ];

            int i = 0;
            while (i < b1.Length)
            {
                b1[i] = (byte)(state1[i] - 1);
                i++;
            }
            state = Encoding.ASCII.GetString(b1);


            cmd = new SqlCommand("Select edate from electiondate where state=@state", con);
            cmd.Parameters.AddWithValue("state", state);
            rs = cmd.ExecuteReader();
            DateTime dt;
            if (rs.Read())
            {
                dt = DateTime.Parse(rs["edate"].ToString());
                rs.Close();
                cmd.Dispose();
            }
            else
            {
                rs.Close();
                cmd.Dispose();
                return;
            }
            string cd1 = DateTime.Now.ToString("dd-MMM-yyyy");
            string dt1 = dt.ToString("dd-MMM-yyyy");
            DateTime cd2 = DateTime.Parse(cd1);
            DateTime dt2 = DateTime.Parse(dt1);
            TimeSpan ts = cd2.Subtract(dt2);
            int no1 = ts.Days;
            if (no1 < 0)
            {
                Label1.Text = "Election Date is :" + dt1 + " . So You are Not Voted......";
                return;
            }
            else if (no1 > 0)
            {
                Label1.Text = "Election Date is Completed......";
                return;
            }
                cmd = new SqlCommand("Select * from ratable where state=@state", con);
                cmd.Parameters.AddWithValue("state", state);
                rs = cmd.ExecuteReader();
                bool b = rs.Read();
                rs.Close();
                cmd.Dispose();
                if (b)
                {
                    Label1.Text = "Result Already Declared . So You Have Not Voted.......";
                    return;
                }

                cmd = new SqlCommand("select * from poll where vid=@vid", con);
                cmd.Parameters.AddWithValue("vid", Session["EVoterID"].ToString());
                rs = cmd.ExecuteReader();
                b = rs.Read();
                rs.Close();
                cmd.Dispose();
                if (b)
                {
                   Label1.Text = "Already Voted......";
                   return;
                }


     
            if (FileUpload1.HasFile == false)
            {
                Label1.Text = "Select QRCode Image......";
                return;
            }

            cmd = new SqlCommand("select qrcode from vtable where vid=@vid", con);
            cmd.Parameters.AddWithValue("vid", Session["EVoterID"].ToString());
            rs = cmd.ExecuteReader();
            byte[] qrcode = { 0 };
            if (rs.Read())
            {
                qrcode = (byte[])rs["qrcode"];
                rs.Close();
                cmd.Dispose();
            }
            else
            {
                rs.Close();
                cmd.Dispose();
                Label1.Text = "Record Not Found.Check VTable.....";
                return;
            }

            byte[] bb = FileUpload1.FileBytes;
            bool bo = checkcompare(qrcode, bb);
            if (bo==false )
            {
                Label1.Text = "Invalid QRCode.Select Correct QRCode Image.....";
                return;
            }

            Response.Redirect("VoterLoginSecondSecurity.aspx");

        }
        catch (Exception ex)
        {
            Label1.Text = ex.ToString();
        }

    }
}