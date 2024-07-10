using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

public partial class DeleteAllRecords : System.Web.UI.Page
{
    SqlConnection con;
    SqlCommand cmd;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Label1.Text = "";

            Menu m1 = (Menu)Master.FindControl("Menu1");
            m1.Visible = true;
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
            con.Open();
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

            cmd = new SqlCommand("delete from crtable", con);
            cmd.ExecuteNonQuery();
            cmd.Dispose();

            cmd = new SqlCommand("delete from electiondate", con);
            cmd.ExecuteNonQuery();
            cmd.Dispose();

            cmd = new SqlCommand("delete from fieldreg", con);
            cmd.ExecuteNonQuery();
            cmd.Dispose();

            cmd = new SqlCommand("delete from poll", con);
            cmd.ExecuteNonQuery();
            cmd.Dispose();

            cmd = new SqlCommand("delete from ratable", con);
            cmd.ExecuteNonQuery();
            cmd.Dispose();

            cmd = new SqlCommand("delete from rescount", con);
            cmd.ExecuteNonQuery();
            cmd.Dispose();

            cmd = new SqlCommand("delete from vtable", con);
            cmd.ExecuteNonQuery();
            cmd.Dispose();


            Label1.Text = "All Records Deleted.....";

            DirectoryInfo d1 = new DirectoryInfo(Server.MapPath("QRCode"));
            FileInfo[] f1 = d1.GetFiles();

            foreach (FileInfo f2 in f1)
                f2.Delete();

             d1 = new DirectoryInfo(Server.MapPath("Image"));
            f1 = d1.GetFiles();

            foreach (FileInfo f2 in f1)
                f2.Delete();

            d1 = new DirectoryInfo(Server.MapPath("TImage"));
            f1 = d1.GetFiles();

            foreach (FileInfo f2 in f1)
                f2.Delete();

            d1 = new DirectoryInfo(Server.MapPath("Temp"));
            f1 = d1.GetFiles();

            foreach (FileInfo f2 in f1)
                f2.Delete();

        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }
    }
}