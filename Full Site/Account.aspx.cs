using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

public partial class Account : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
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
            Response.Write("Error");
        }
        SqlConnection dbConnection = new SqlConnection("Data Source=stusql;Integrated Security=true");
        dbConnection.Open();
        dbConnection.ChangeDatabase("Emerald_Database");
        string command = "select VIDEO_NAME from VIDEO_DATA where user_userid='" + id + "' order by VIDEO_DATE asc";
        SqlCommand sqlCommand = new SqlCommand(command, dbConnection);
        SqlDataAdapter sqlDataAdap = new SqlDataAdapter(sqlCommand);
        DataTable dt = new DataTable(); //Create data to fill into table
        sqlDataAdap.Fill(dt); //fill data table with values from data adapater
        GridView1.DataSource = dt; //set the source of where grid view will get data from
        GridView1.DataBind(); //fill table with data
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

    protected void upload1(object sender, EventArgs e)
    {
        string id = Request.QueryString["Id"];
        try
        {
            if (id != null)
            {
                Response.Redirect("Upload.aspx?id=" + id);
            }
            else
            {
                Response.Redirect("Upload.aspx");
            }
        }
        catch
        {
            Response.Write("Error");
        }
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if(e.Row.RowType == DataControlRowType.Header)
        {
            e.Row.Cells[0].Text = "Video Name";
        }
        
        if(e.Row.RowType == DataControlRowType.DataRow)
        {
            HyperLink link = new HyperLink();
            link.ID = " ";
            string cellText = e.Row.Cells[0].Text.ToString();
            link.Text = cellText;

            SqlConnection dbConnection = new SqlConnection("Data Source=stusql; Integrated Security=true");
            dbConnection.Open();
            dbConnection.ChangeDatabase("Emerald_Database");
            string command = "select video_id from video_data where video_name='" + cellText + "'";
            SqlCommand sqlCommand = new SqlCommand(command, dbConnection);

            string u_id = Request.QueryString["Id"];
            if(u_id != null)
            {
                link.NavigateUrl = "VideoPage.aspx?userID= " + u_id + "?vID= " + sqlCommand.ExecuteScalar().ToString();
            }
            else
            {
                link.NavigateUrl = "VideoPage.aspx?vID= " + sqlCommand.ExecuteScalar().ToString();
            }
            e.Row.Cells[0].Controls.Add(link);
        }
    }
}