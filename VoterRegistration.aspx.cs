using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using QRCoder;

using System.Drawing;

using System.IO;
using System.Collections;
using System.Text;


public partial class VoterRegistration : System.Web.UI.Page
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
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
            con.Open();
            TextBox6.Text = DateTime.Now.ToString("dd-MMM-yyyy");
            if (!IsPostBack)
            {
                for (int i = DateTime.Now.Year - 18; i >= DateTime.Now.Year - 80; i--)
                    DropDownList3.Items.Add(i.ToString());

                DropDownList3.Items.Insert(0, "Select");

                if (!IsPostBack)
                {
                    autonumber();
                }

            }
        }
        catch (Exception ex)
        {
            Label1.Text = ex.ToString();
        }
    }

    void autonumber()
    {
        cmd = new SqlCommand("select isnull(max(vid),1000)+1 from vtable", con);
       string vid  = cmd.ExecuteScalar().ToString();
        cmd.Dispose();


        if (vid.Equals("1001"))
            TextBox1.Text = vid;
        else
        {

            char[] vid1 = vid.ToCharArray();
            byte[] b1 = new byte[vid1.Length];
            int j1 = 0;

            while (j1 < b1.Length)
            {
                b1[j1] = (byte)(vid1[j1] - 1);
                j1++;
            }
            vid = Encoding.ASCII.GetString(b1);
            TextBox1.Text = vid;
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

            if (DropDownList1.SelectedIndex == 0 || DropDownList2.SelectedIndex == 0 || DropDownList3.SelectedIndex == 0 || DropDownList4.SelectedIndex == 0 || DropDownList5.SelectedIndex == 0 || RadioButtonList1.SelectedIndex == -1)
            {
                Label1.Text = "Select All Options......";
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
                Label1.Text = "Election Date Already Completed.........";
                return;
            }
            if (dday < 20 && dday >=0)
            {

                Label1.Text = "Voter  Registration Date Before >=20 Days.......";
                return;
            }



            int j1 = 0;

            string vid = TextBox1.Text;
            char[] vid1 = vid.ToCharArray();
            byte[] b1 = new byte[vid1.Length];
            j1 = 0;

            while (j1 < b1.Length)
            {
                b1[j1] = (byte)(vid1[j1] + 1);
                j1++;
            }
            vid = Encoding.ASCII.GetString(b1);


            cmd = new SqlCommand("select vid from vtable where vid=@vid", con);
            cmd.Parameters.AddWithValue("vid", vid);
            rs = cmd.ExecuteReader();
            bool b = rs.Read();
            rs.Close();
            cmd.Dispose();
            if (b)
            {
                Label1.Text = "VoterID Already Found.....";
                return;
            }


              if (FileUpload1.HasFile == false)
            {
                Label1.Text = "Select File Name....";
                return;
            }


              FileInfo fi = new FileInfo(FileUpload1.PostedFile.FileName);
            if (fi.Extension.ToLower().Equals(".jpg")==false && fi.Extension .ToLower ().Equals (".jpeg")&&  fi.Extension.ToLower().Equals(".gif"))
            {
               Label1.Text = "Select Only Jpg or Gif  File....";
                return ;
             
            }


                 byte [] ba=FileUpload1.FileBytes ;
           
                string fname = DateTime.Now.Ticks + "_" + fi.Name;



           adp=new SqlDataAdapter  ("select frecog from vtable",con );
           dt=new DataTable ();
            adp.Fill (dt);

             for (int i = 0; i < dt.Rows.Count; i++)
            {
                byte[] bb = (byte[])dt.Rows[i]["frecog"];
                bool bo = checkcompare(ba, bb);
                if (bo)
                {
                    Label1.Text = "Face Recognizaton  Image Already Found.Select Correct Face Recognizaton Image.....";
                //    LinkButton1.Enabled = false;
                    return;
                }
            }
         //    LinkButton1.Enabled = true;

             byte []ba1 = FileUpload2.FileBytes;
             adp = new SqlDataAdapter("select fprint from vtable", con);
             dt = new DataTable();
             adp.Fill(dt);

             for (int i = 0; i < dt.Rows.Count; i++)
             {
                 byte[] bb = (byte[])dt.Rows[i]["fprint"];
                 bool bo = checkcompare(ba1, bb);
                 if (bo)
                 {
                     Label1.Text = "FingerPrint Already Found.So,Please Select Correct FingerPrint Image.....";
                     //    LinkButton1.Enabled = false;
                     return;
                 }
             }

            string code = DateTime.Now.Ticks + "_"+TextBox2 .Text +"_" + TextBox1.Text + ".jpg" ;

            byte[] cc = System.Text.Encoding.ASCII.GetBytes(code);

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeGenerator.QRCode qrCode = qrGenerator.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q);
            System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
            imgBarCode.Height = 150;
            imgBarCode.Width = 150;
            byte[] byteImage = { 0 };
            using (Bitmap bitMap = qrCode.GetGraphic(20))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    byteImage = ms.ToArray();
                    imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
                    FileStream fin = new FileStream(Server.MapPath("QRCode\\" + code), FileMode.CreateNew, FileAccess.Write);
                     fin.Write(byteImage, 0, byteImage.Length);
                   // fin.Write(cc, 0, cc.Length);
                    // fin.Write(cc, 0, cc.Length);
                    fin.Close();
                }

          
            }

            int j;
            j = 0;

            


            string vname = TextBox2.Text;
            char[] vname1 = vname.ToCharArray();
            byte[] b2 = new byte[vname1.Length];
            j = 0;

            while (j < b2.Length)
            {
                b2[j] = (byte)(vname1[j] + 1);
                j++;
            }

            vname= Encoding.ASCII.GetString(b2);


            string faname = TextBox3.Text;
            char[] faname1 = faname.ToCharArray();
            byte[] b3 = new byte[faname1.Length];
            j = 0;

            while (j < b3.Length)
            {
                b3[j] = (byte)(faname1[j] + 1);
                j++;
            }

            faname = Encoding.ASCII.GetString(b3);

            string gender = RadioButtonList1 .SelectedItem .Text ;
            char[] gender1 = gender.ToCharArray();
            byte[] b4 = new byte[gender1.Length];
            j = 0;

            while (j < b4.Length)
            {
                b4[j] = (byte)(gender1[j] + 1);
                j++;
            }

            gender  = Encoding.ASCII.GetString(b4);


            string state = DropDownList4.SelectedItem.Text;
            char[] state1 = state.ToCharArray();
            byte[] b5 = new byte[state1.Length];
            j = 0;

            while (j < b5.Length)
            {
                b5[j] = (byte)(state1[j] + 1);
                j++;
            }

            state = Encoding.ASCII.GetString(b5);


            string cons = DropDownList5.SelectedItem.Text;
            char[] cons1 = cons.ToCharArray();
            byte[] b6 = new byte[cons.Length];
            j = 0;

            while (j < b6.Length)
            {
                b6[j] = (byte)(cons1[j] + 1);
                j++;
            }

            cons= Encoding.ASCII.GetString(b6);


            string address = TextBox5.Text;
            char[] address1 = address.ToCharArray();
            byte[] b7 = new byte[address1.Length];
            j = 0;

            while (j < b7.Length)
            {
                b7[j] = (byte)(address1 [j] + 1);
                j++;
            }

            address = Encoding.ASCII.GetString(b7);


            string password = TextBox7.Text;
            char[] password1 = password.ToCharArray();
            byte[] b8 = new byte[password1.Length];
            j = 0;

            while (j < b8.Length)
            {
                b8[j] = (byte)(password1[j] + 1);
                j++;
            }
            password = Encoding.ASCII.GetString(b8);


            string status = "Not Selected";
            char[] status1 = status.ToCharArray();
            byte[] b9 = new byte[status1.Length];
            j = 0;

            while (j < b9.Length)
            {
                b9[j] = (byte)(status1[j] + 1);
                j++;
            }
            status = Encoding.ASCII.GetString(b9);


            string emailid = TextBox8.Text;
            char[] emailid1 = emailid.ToCharArray();
            byte[] b10 = new byte[emailid1.Length];
            j = 0;

            while (j < b10.Length)
            {
                b10[j] = (byte)(emailid1[j] + 1);
                j++;
            }

            emailid   = Encoding.ASCII.GetString(b10);

            string dob =DropDownList1 .SelectedItem .Text +"-"+DropDownList2 .SelectedItem .Text +"-"+DropDownList3 .SelectedItem .Text ;


            Random r = new Random();
            int otp = r.Next(1111, 9999);



            cmd = new SqlCommand("insert into vtable values(@vid,@vname,@fname,@dob,@gender,@cno,@state,@cons,@address,@rdate,@pword,@frecog,@qrcode,@status,@fprint,@emailid,@otp)", con);
            cmd.Parameters .AddWithValue ("vid",vid);
            cmd.Parameters .AddWithValue ("vname",vname);
            cmd.Parameters .AddWithValue ("fname",faname );
            cmd.Parameters .AddWithValue ("dob",dob);
            cmd.Parameters .AddWithValue ("gender",gender );
            cmd.Parameters .AddWithValue ("cno",TextBox4 .Text );
            cmd.Parameters .AddWithValue ("state",state );
            cmd.Parameters .AddWithValue ("cons",cons );
            cmd.Parameters .AddWithValue ("address",address );
            cmd.Parameters .AddWithValue ("rdate",TextBox6 .Text );
            cmd.Parameters .AddWithValue ("pword",TextBox7 .Text );
            cmd.Parameters .AddWithValue ("frecog",ba);
            cmd.Parameters .AddWithValue ("qrcode",byteImage );
            cmd.Parameters.AddWithValue("status", status);
            cmd.Parameters.AddWithValue("fprint", ba1);
            cmd.Parameters.AddWithValue("emailid", emailid);
            cmd.Parameters.AddWithValue("otp", otp);
            cmd.ExecuteNonQuery ();
            cmd.Dispose ();
            Label1 .Text ="Record Inserted.....";

           /* DirectoryInfo dd = new DirectoryInfo(Server.MapPath("Temp"));
            FileInfo[] ff = dd.GetFiles();
            foreach (FileInfo fff in ff)
                fff.Delete();*/


            string ggg =DateTime .Now .Ticks +"_"+ FileUpload1 .FileName ;
            FileUpload1.PostedFile .SaveAs (Server .MapPath ("Temp\\"+ ggg));

           // FileStream ffs =new FileStream (Server .MapPath ("Temp/"+ FileUpload1 .FileName ));


            Session.Add("AVoterID", TextBox1.Text);
            Session.Add("AFRImage", ba);
            Session.Add("AFRImageLocation", ggg );
            Session.Add("AQRCodeImage", code);
            Session.Add("AQRCodeLocation", Server.MapPath("QRCode\\" + code));
            Response.Redirect("VoterRegistration1.aspx");


        }
        catch (Exception ex)
        {
            Label1.Text = ex.ToString();
        }
    }
}