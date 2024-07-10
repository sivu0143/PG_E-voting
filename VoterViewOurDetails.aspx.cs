using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;
using System.Data;
using System.Text;

public partial class VoterViewOurDetails : System.Web.UI.Page
{
    SqlConnection con;
    SqlDataAdapter adp;
    DataTable dt;
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
                if (Session["EVoterID"] != null)
                {
                    bindview();
                }
            }


        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }
    }
    void bindview()
    {

        DirectoryInfo di = new DirectoryInfo(Server.MapPath("TImage"));
        FileInfo[] f1 = di.GetFiles();
        foreach (FileInfo f2 in f1)
            f2.Delete();





      


        adp = new SqlDataAdapter("select * from vtable where vid=@vid", con);

        adp.SelectCommand.Parameters.AddWithValue("vid", Session["EVoterID"].ToString());
        dt = new DataTable();
        adp.Fill(dt);
        string photo = "";
        byte[] img = (byte[])dt.Rows[0]["frecog"];
        photo = "one.jpg";
       
        FileStream fs = new FileStream(Server.MapPath("TImage\\one.jpg" ), FileMode.Create, FileAccess.Write);
        fs.Write(img, 0, img.Length);
        fs.Close();

        DataTable dt1 = new DataTable();
        dt1.Columns.Add("VID", typeof(int));
        dt1.Columns.Add("VName");
        dt1.Columns.Add("FName");
        dt1.Columns.Add("DOB");
        dt1.Columns.Add("Gender");
        dt1.Columns.Add("CNO",typeof(long ));

        dt1.Columns.Add("State");
        dt1.Columns.Add("Cons");
        dt1.Columns.Add("Address");
        dt1.Columns.Add("RDate");
        dt1.Columns.Add("Photo");

     
        int j ;
        

            string vid = dt.Rows[0]["vid"].ToString();
            char[] vid1 = vid.ToCharArray();
            byte[] b1 = new byte[vid1.Length];
            j = 0;

            while (j < b1.Length)
            {
                b1[j] = (byte)(vid1[j] - 1);
                j++;
            }
            vid = Encoding.ASCII.GetString(b1);

            string vname = dt.Rows[0]["vname"].ToString();
            char[] vname1 = vname.ToCharArray();
            byte[] b2 = new byte[vname1.Length];
            j = 0;

            while (j < b2.Length)
            {
                b2[j] = (byte)(vname1[j] - 1);
                j++;
            }

            vname = Encoding.ASCII.GetString(b2);


            string fname = dt.Rows[0]["fname"].ToString();
            char[] fname1 = fname.ToCharArray();
            byte[] b3 = new byte[fname1.Length];
            j = 0;

            while (j < b3.Length)
            {
                b3[j] = (byte)(fname1[j] - 1);
                j++;
            }

           fname = Encoding.ASCII.GetString(b3);



            string dob=DateTime.Parse (dt.Rows [0]["dob"].ToString ()).ToString ("dd-MMM-yyyy");

            string gender = dt.Rows[0]["gender"].ToString();
            char[] gender1 = gender.ToCharArray();
            byte[] b4 = new byte[gender1.Length];
            j = 0;

            while (j < b4.Length)
            {
                b4[j] = (byte)(gender1[j] - 1);
                j++;
            }

            gender = Encoding.ASCII.GetString(b4);

            long cno=long.Parse (dt.Rows [0]["cno"].ToString ());


            string state = dt.Rows[0]["state"].ToString();
            char[] state1 = state.ToCharArray();
            byte[] b5 = new byte[state1.Length];
            j = 0;

            while (j < b5.Length)
            {
                b5[j] = (byte)(state1[j] - 1);
                j++;
            }

           state = Encoding.ASCII.GetString(b5);


         
            string cons =dt.Rows[0]["cons"].ToString();
            char[] cons1 = cons.ToCharArray();
            byte[] b6 = new byte[cons1.Length];
            j = 0;

            while (j < b6.Length)
            {
                b6[j] = (byte)(cons1[j] - 1);
                j++;
            }

            cons = Encoding.ASCII.GetString(b6);


            string address =dt.Rows[0]["address"].ToString();
            char[] address1 = address.ToCharArray();
            byte[] b7 = new byte[address1.Length];
            j = 0;

            while (j < b7.Length)
            {
                b7[j] = (byte)(address1[j] - 1);
                j++;
            }

            address = Encoding.ASCII.GetString(b7);

        string rdate=DateTime .Parse (dt.Rows [0]["rdate"].ToString ()).ToString ("dd-MMM-yyyy");



            DataRow dr = dt1.NewRow();
            dr[0] = vid;
            dr[1] = vname;
            dr[2] = fname;
        dr[3]=dob;
        dr[4]=gender ;
        dr[5]=cno;
        dr[6]=state;
        dr[7]=cons;
        dr[8]=address;
        dr[9]=rdate ;
            dr[10] = photo;
            dt1.Rows.Add(dr);

        DetailsView1 .DataSource =dt1 ;
        DetailsView1 .DataBind ();




        }
      




    }




