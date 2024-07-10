using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Net.Mail;
using System.Text;

public partial class VoterLoginThirdSecurity : System.Web.UI.Page
{
    SqlConnection con;
    SqlCommand cmd;
    SqlDataReader rs;

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
    void mailcoding(string emailid, string mess)
    {
        MailMessage mail = new MailMessage();

        // mail.To.Add("aptech266goodshed@gmail.com");//receiver
        mail.To.Add(emailid);//receiver
        mail.From = new MailAddress("customerproject404nf@gmail.com");//sender
        mail.Subject = "OTP is:";

        string Body = mess;
        mail.Body = Body;

        mail.IsBodyHtml = true;
        SmtpClient smtp = new SmtpClient();

        smtp.Host = "smtp.gmail.com"; //Or Your SMTP Server Address//refer server

        smtp.Credentials = new System.Net.NetworkCredential("customerproject404nf@gmail.com", "ssiaptech");//Or your Smtp Email ID and Password//security

        smtp.EnableSsl = true;
        smtp.Send(mail);

    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        try
        {
            if (FileUpload1.HasFile == false)
            {
                Label1.Text = "Select FingerPrint Image......";
                return;
            }

            string emailid = "";
            int otp = 0;
            cmd = new SqlCommand("select fprint,emailid,otp from vtable where vid=@vid", con);
            cmd.Parameters.AddWithValue("vid", Session["EVoterID"].ToString());
            rs = cmd.ExecuteReader();
            byte[] frecog = { 0 };
            if (rs.Read())
            {
                frecog = (byte[])rs["fprint"];
                emailid = rs["emailid"].ToString();
                otp = int.Parse(rs["otp"].ToString());
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
            bool bo = checkcompare(frecog, bb);
            if (bo == false)
            {
                Label1.Text = "Invalid FingerPrint .So,Please Select Correct FingerPrint.....";
                return;
            }

            int j = 0;

            
            char[] emailid1 = emailid.ToCharArray();
            byte[] b1 = new byte[emailid1.Length];
          
            while (j < b1.Length)
            {
                b1[j] = (byte)(emailid1[j] - 1);
                j++;
            }
            emailid = Encoding.ASCII.GetString(b1);

            //mailcoding(emailid, otp.ToString ());
            Response.Redirect("VoterLoginFourthSecurity.aspx");
          

        }
        catch (Exception ex)
        {
            Label1.Text = ex.ToString();
        }

    }
}