using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Account : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SqlConnection dbConnection = new SqlConnection("Data Source=stusql;Integrated Security=true");
        dbConnection.Open();
        dbConnection.ChangeDatabase("Emerald_Database");
        string command = "Select VIDEO_NAME from VIDEO_DATA order by VIDEO_DATE asc;";
        SqlCommand sqlCommand = new SqlCommand(command, dbConnection);
        SqlDataAdapter sqlDataAdap = new SqlDataAdapter(sqlCommand);
        DataTable dt = new DataTable();
        sqlDataAdap.Fill(dt); // I get an exception error here when i try to debug is there any way i can fix this?
        GridView1.DataSource = dt;
        GridView1.DataBind();


        string id = Request.QueryString["Id"];

        try
        {
            if (id != null)
            {
                Log.HRef = "Account.aspx";
                Log.InnerText = "My Account";
                Reg.HRef = "Home.aspx";
                Reg.InnerText = "Sign out";
            }
        }
        catch
        {

        }
    }

    protected void UpdateVideo1(object sender, EventArgs e)
    {
        Response.Redirect("Edit_Video1.aspx");
    }

    protected void home1(object sender, EventArgs e)
    {
        string id = Request.QueryString["Id"];
        try
        {
            if (id != null)
            {
                Response.Redirect("Home.aspx?id=" + id);
            }
            else
            {
                Response.Redirect("Home.aspx");
            }
        }
        catch
        {
            Response.Write("Error");
        }
    }

    protected void browse1(object sender, EventArgs e)
    {
        string id = Request.QueryString["Id"];
        try
        {
            if (id != null)
            {
                Response.Redirect("Browse.aspx?id=" + id);
            }
            else
            {
                Response.Redirect("Browse.aspx");
            }
        }
        catch
        {
            Response.Write("Error");
        }
    }

    protected void about1(object sender, EventArgs e)
    {
        string id = Request.QueryString["Id"];
        try
        {
            if (id != null)
            {
                Response.Redirect("About.aspx?id=" + id);
            }
            else
            {
                Response.Redirect("About.aspx");
            }
        }
        catch
        {
            Response.Write("Error");
        }
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            e.Row.Cells[0].Text = "Video Name";
        }

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string cellText = e.Row.Cells[0].Text.ToString();

            SqlConnection dbConnection = new SqlConnection("Data Source=stusql; Integrated Security=true");
            dbConnection.Open();
            dbConnection.ChangeDatabase("Emerald_Database");
            string command = "select video_id from video_data where video_name='" + cellText + "'";
            SqlCommand sqlCommand = new SqlCommand(command, dbConnection);
        }
    }
}