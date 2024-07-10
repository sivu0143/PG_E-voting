using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class CandidateRegistration : System.Web.UI.Page
{
    SqlConnection con;
    SqlCommand cmd;
    SqlDataReader rs;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

            Label1.Text = "";

            Menu m1 = (Menu)Master.FindControl("Menu1");
            m1.Visible = true;
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
            con.Open();
            TextBox8.Text = DateTime.Now.ToString("dd-MMM-yyyy");
            if (!IsPostBack)
            {
                for (int i=DateTime .Now .Year -20 ; i>=DateTime .Now .Year -80 ; i--)
                    DropDownList3 .Items .Add (i.ToString ());

                DropDownList3.Items.Insert(0, "Select");


            }
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
            if (RadioButtonList1.SelectedIndex == -1 || RadioButtonList2.SelectedIndex == -1 || DropDownList1.SelectedIndex == 0 || DropDownList2.SelectedIndex == 0 || DropDownList3.SelectedIndex == 0 || DropDownList4.SelectedIndex == 0 || DropDownList5.SelectedIndex == 0)
            {
                Label1.Text = "Select All Options.....";
                return;

            }


            cmd = new SqlCommand("select edate from electiondate where state=@state", con);
            cmd.Parameters.AddWithValue("state", DropDownList4.SelectedItem.Text);
            rs = cmd.ExecuteReader();
            string edate = "";
            if (rs.Read())
            {
                edate = rs["edate"].ToString();
                rs.Close();
                cmd.Dispose();
            }
            else
            {
                rs.Close();
                cmd.Dispose();
                //Label1.Text = "ElectionDate Not Inserted.Please Contact Administrator....";
                Label1.Text = "ElectionDate Not Inserted.So Your Record Not Inserted.......";

                return;
            }


            DateTime edate1 = DateTime.Parse(edate);
            string cdate = DateTime.Now.ToString("dd-MMM-yyyy");
            DateTime cdate1 = DateTime.Parse(cdate);

            TimeSpan ts = edate1.Subtract(cdate1);
            
            int dday = int.Parse(ts.Days.ToString());

            if (dday < 0)
            {
               Label1.Text ="Election Date Already Completed.........";
                return;
            }
            if (dday < 30 && dday >= 0)
            {

                Label1.Text = "Nominee Registration Date Before >=30 Days.......";
                return;
            }

            if (FileUpload1.HasFile == false || FileUpload2.HasFile == false)
            {

                Label1.Text = "Select Symbol and Candidate Photo.......";
                return;
            }

            cmd = new SqlCommand("select pname from crtable where pname=@pname", con);
            cmd.Parameters.AddWithValue("pname", TextBox7.Text);
            rs = cmd.ExecuteReader();
            bool b = rs.Read();
            rs.Close();
            cmd.Dispose();
            if (b)
            {
                Label1.Text = "Party Symbol Name Already Found.....";
                return;
            }

            cmd = new SqlCommand("select uname from crtable where uname=@uname", con);
            cmd.Parameters.AddWithValue("uname", TextBox9.Text);
            rs = cmd.ExecuteReader();
            b = rs.Read();
            rs.Close();
            cmd.Dispose();
            if (b)
            {
                Label1.Text = "UserName Already Found.....";
                return;
            }

            string symbol = DateTime.Now.Ticks + "_" + FileUpload1.FileName;
            string cphoto = DateTime.Now.Ticks + "_" + FileUpload2.FileName;
            FileUpload1.PostedFile.SaveAs(Server.MapPath("Image/") +symbol);
            FileUpload2.PostedFile.SaveAs(Server.MapPath("Image/") +cphoto);

            string dob=DropDownList1 .SelectedItem .Text +"-"+DropDownList2 .SelectedItem .Text +"-"+DropDownList3 .SelectedItem .Text ;

            cmd = new SqlCommand("insert into crtable values(@cname,@fname,@cnumber,@gender,@dob,@state,@cons,@crecord,@aincome,@passets,@address,@pname,@nfdate,@symbol,@cphoto,@uname,@pword,@status)", con);

            cmd.Parameters .AddWithValue ("cname",TextBox1 .Text );
            cmd.Parameters .AddWithValue ("fname",TextBox2 .Text );
            cmd.Parameters .AddWithValue ("cnumber",TextBox3 .Text );
            cmd.Parameters .AddWithValue ("gender",RadioButtonList1 .SelectedItem .Text );
            cmd.Parameters .AddWithValue ("dob",dob );
            cmd.Parameters .AddWithValue ("state",DropDownList4 .SelectedItem .Text );
            cmd.Parameters .AddWithValue ("cons",DropDownList5 .SelectedItem .Text );
            cmd.Parameters .AddWithValue ("crecord",RadioButtonList2 .SelectedItem .Text );
            cmd.Parameters .AddWithValue ("aincome",TextBox4 .Text );
            cmd.Parameters .AddWithValue ("passets",TextBox5 .Text );
            cmd.Parameters .AddWithValue ("address",TextBox6 .Text );
            cmd.Parameters .AddWithValue ("pname",TextBox7 .Text );
            cmd.Parameters .AddWithValue ("nfdate",TextBox8 .Text );
            cmd.Parameters .AddWithValue ("symbol",symbol );
            cmd.Parameters .AddWithValue ("cphoto",cphoto);
            cmd.Parameters .AddWithValue ("uname",TextBox9 .Text );
            cmd.Parameters .AddWithValue ("pword",TextBox10 .Text );
            cmd.Parameters .AddWithValue ("status","Not Selected");
            cmd.ExecuteNonQuery ();
            cmd.Dispose ();
            Label1 .Text ="Nominee Registration Details Inserted.....";




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
        TextBox3.Text = "";
        TextBox4.Text = "";
        TextBox5.Text = "";
        TextBox6.Text = "";
        TextBox7.Text = "";
        TextBox9.Text = "";
        TextBox10.Text = "";
        RadioButtonList1.SelectedIndex = -1;
        RadioButtonList2.SelectedIndex = -1;
        DropDownList1.SelectedIndex = 0;
        DropDownList2.SelectedIndex = 0;
        DropDownList3.SelectedIndex = 0;
        DropDownList4.SelectedIndex = 0;
        DropDownList5.SelectedIndex = 0;
    }
}