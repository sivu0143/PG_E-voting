using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.IO;
using System.Collections;
using System.Text;

public partial class AdminViewVoterDetails : System.Web.UI.Page
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


            Menu m2 = (Menu)Master.FindControl("Menu2");
            m2.Visible = true;
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
            con.Open();
          

        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }
    }
    void bindgrid()
    {

        DirectoryInfo di = new DirectoryInfo(Server.MapPath("TImage"));
        FileInfo[] f1 = di.GetFiles();
        foreach (FileInfo f2 in f1)
            f2.Delete();



        int j;
        string cons =DropDownList1 .SelectedItem .Text ;
        char[] cons1 = cons.ToCharArray();
        byte[] b6 = new byte[cons.Length];
        j = 0;

        while (j < b6.Length)
        {
            b6[j] = (byte)(cons1[j] + 1);
            j++;
        }

        cons = Encoding.ASCII.GetString(b6);


        adp = new SqlDataAdapter("select frecog from vtable where cons=@cons", con);
        adp.SelectCommand.Parameters.AddWithValue("cons", cons);
        dt = new DataTable();
        adp.Fill(dt);


        ArrayList photo = new ArrayList();
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            byte[] img = (byte[])dt.Rows[i]["frecog"];
            photo.Add(i + ".jpg");
            FileStream fs = new FileStream(Server.MapPath("TImage\\" + (i + ".jpg")), FileMode.Create, FileAccess.Write);
            fs.Write(img, 0, img.Length);
            fs.Close();
        }



        string status = "Selected";
        char[] status1 = status.ToCharArray();
        byte[] b9 = new byte[status1.Length];
        j = 0;

        while (j < b9.Length)
        {
            b9[j] = (byte)(status1[j] + 1);
            j++;
        }

        status = Encoding.ASCII.GetString(b9);


        adp = new SqlDataAdapter("select * from vtable where cons=@cons and  status=@status", con);
        adp.SelectCommand.Parameters.AddWithValue("cons", cons);
        adp.SelectCommand.Parameters.AddWithValue("status", status);
        dt = new DataTable();
        adp.Fill(dt);



        DataTable dt1 = new DataTable();
        dt1.Columns.Add("VID", typeof(int));
        dt1.Columns.Add("VName");
  
        dt1.Columns.Add("RDate", typeof(DateTime));
        dt1.Columns.Add("Photo");

        for (int i = 0; i < dt.Rows.Count; i++)
        {

            j = 0;

            string vid = dt.Rows[i]["vid"].ToString();
            char[] vid1 = vid.ToCharArray();
            byte[] b1 = new byte[vid1.Length];
            j = 0;

            while (j < b1.Length)
            {
                b1[j] = (byte)(vid1[j] - 1);
                j++;
            }
            vid = Encoding.ASCII.GetString(b1);




            string vname = dt.Rows[i]["vname"].ToString();
            char[] vname1 = vname.ToCharArray();
            byte[] b2 = new byte[vname1.Length];
            j = 0;

            while (j < b2.Length)
            {
                b2[j] = (byte)(vname1[j] - 1);
                j++;
            }

            vname = Encoding.ASCII.GetString(b2);



            DataRow dr = dt1.NewRow();
            dr[0] = vid;
            dr[1] = vname;
            dr[2] = dt.Rows[i]["rdate"].ToString();
            dr[3] = photo[i].ToString();
            dt1.Rows.Add(dr);

        }
        if (dt1.Rows.Count != 0)
        {
            GridView1.Visible = true;
            GridView1.DataSource = dt1;
            GridView1.DataBind();
        }
    }




    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        try
        {
            GridView1.Visible = false;
            if (DropDownList1.SelectedIndex == 0)
            {
                Label1.Text = "Select Constituency......";
                return;
            }
            bindgrid();
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }
    }
}