using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string id = Request.QueryString["id"];

        try
        {
            if(id !=null)
            {
                Log.HRef = "Account.aspx";
                Log.InnerText = "My Account";
                Regis.HRef = "Home.aspx";
                Regis.InnerText = "Log out";
            }
        }
        catch
        {
            Response.Write("Error");
        }
    }

    protected void FTPUpload(object sender, EventArgs e)
    {
        using (BinaryReader br = new BinaryReader(FileUpload1.PostedFile.InputStream))
        {
            string id = Request.QueryString["id"];

            try
            {
                if (id != null)
                {
                    
                    DateTime today = DateTime.Today;
                    byte[] bytes = br.ReadBytes((int)FileUpload1.PostedFile.InputStream.Length);
                    string strConnString = ConfigurationManager.ConnectionStrings["Emerald_Database"].ConnectionString;
                    SaveData(strConnString, bytes);
                    SqlConnection dbConnection = new SqlConnection("Data Source=stusql;Integrated Security=true");
                    dbConnection.Open();
                    dbConnection.ChangeDatabase("Emerald_Database");
                    string command1 = "select count(video_id) from video_data;";
                    SqlCommand sqlCommand = new SqlCommand(command1, dbConnection);

                    int count = Convert.ToInt32(sqlCommand.ExecuteScalar());
                    count++;

                    string command2 = "insert into video_data(video_id, video_name, video_views, video_date, video_upvotes, video_downvotes, user_userid)" +
                        "values(" + count + ", '" + FileUpload1.FileName + "' , 0, 0, " + today.ToString("yyy-MM-dd") + ", 0, 0, '" + id + "'";

                    sqlCommand.CommandText = command2;

                    sqlCommand.ExecuteNonQuery();

                    sqlCommand.CommandText = "select count(ranking_id) from video_rankings";
                    int rankingCount = Convert.ToInt32(sqlCommand.ExecuteScalar());
                    rankingCount++;

                    sqlCommand.CommandText = "insert into VIDEO_RANKING(RANKING_ID, RANKING_STORYTELLING, RANKING_CINEMATOGRAPHY, RANKING_ORIGININALITY, " +
                        "RANKING_DIALOGUE, RANKING_CHARACTER_DEV, VIDEO_ID, RANKING_TOTAL values(" + rankingCount + ", 0, 0, 0, 0, 0, " + count + ", 0";

                    sqlCommand.ExecuteNonQuery();



                    //using (SqlConnection con = new SqlConnection(strConnString))
                    //{
                    //    using (SqlCommand cmd = new SqlCommand())
                    //    {
                    //        int count = Convert.ToInt32(cmd.ExecuteScalar());
                    //        count++;
                    //        cmd.CommandText = "insert into VIDEO_DATA(VIDEO_ID, VIDEO_NAME, VIDEO_VIEWS, VIDEO_DATE, VIDEO_UPVOTES, VIDEO_DOWNVOTES, USER_USERID)" +
                    //            " VALUES(@VIDEO_ID, @VIDEO_NAME, @VIDEO_VIEWS, @VIDEO_DATE, @VIDEO_UPVOTES, @VIDEO_DOWNVOTES, @USER_USERID)";
                    //        cmd.Parameters.AddWithValue("@VIDEO_ID", cmd.CommandText = "SELECT VIDEO_ID FROM VIDEO_DATA ORDER BY VIDEO_ID DESC;");
                    //        cmd.Parameters.AddWithValue("@VIDEO_NAME", Path.GetFileName(FileUpload1.PostedFile.FileName));
                    //        cmd.Parameters.AddWithValue("@VIDEO_VIEWS", "0");
                    //        cmd.Parameters.AddWithValue("@VIDEO_DATE", today.ToString("yyyy-MM-dd"));
                    //        cmd.Parameters.AddWithValue("@VIDEO_UPVOTES", "0");
                    //        cmd.Parameters.AddWithValue("@VIDEO_DOWNVOTES", "0");
                    //        cmd.Parameters.AddWithValue("@USER_USERID", count);
                    //        cmd.Connection = con;
                    //        con.Open();
                    //        cmd.ExecuteNonQuery();
                    //        con.Close();
                    //    }
                    //    using (SqlCommand cmd2 = new SqlCommand())
                    //    {
                    //        cmd2.CommandText = "insert into VIDEO_RANKING(RANKING_ID, RANKING_STORYTELLING, RANKING_CINEMATOGRAPHY, RANKING_ORIGININALITY, RANKING_DIALOGUE, RANKING_CHARACTER_DEV, VIDEO_ID, RANKING_TOTAL)" +
                    //            " VALUES(@RANKING_ID, @RANKING_STORYTELLING, @RANKING_CINEMATOGRAPHY, @RANKING_ORIGININALITY, @RANKING_DIALOGUE, @RANKING_CHARACTER_DEV, @VIDEO_ID, @RANKING_TOTAL)";
                    //        cmd2.Parameters.AddWithValue("@RANKING_ID", cmd2.CommandText = "SELECT RANKING_ID FROM VIDEO_RANKING ORDER BY RANKING_ID DESC;");
                    //        cmd2.Parameters.AddWithValue("@RANKING_STORYTELLING", "0");
                    //        cmd2.Parameters.AddWithValue("@RANKING_CINEMATOGRAPHY", "0");
                    //        cmd2.Parameters.AddWithValue("@RANKING_ORIGININALITY", "0");
                    //        cmd2.Parameters.AddWithValue("@RANKING_DIALOGUE", "0");
                    //        cmd2.Parameters.AddWithValue("@RANKING_CHARACTER_DEV", "0");
                    //        cmd2.Parameters.AddWithValue("@VIDEO_ID", cmd2.CommandText = "SELECT VIDEO_ID FROM VIDEO_DATA ORDER BY VIDEO_ID DESC;");
                    //        cmd2.Parameters.AddWithValue("@RANKING_TOTAL", "0");
                    //        cmd2.Connection = con;
                    //        con.Open();
                    //        cmd2.ExecuteNonQuery();
                    //        con.Close();
                    //    }
                    //}
                }
            }
            catch
            {
                Response.Write("Error");
            }
        }
        Response.Redirect("Home.aspx");
    }

    protected void home1(object sender, EventArgs e)
    {
        string id = Request.QueryString["id"];
        if (id != null)
        {
            Response.Redirect("Home.aspx?id=" + id);
        }
    }

    protected void browse1(object sender, EventArgs e)
    {
        string id = Request.QueryString["id"];
        if (id != null)
        {
            Response.Redirect("Browse.aspx?id=" + id);
        }
    }

    protected void about1(object sender, EventArgs e)
    {
        string id = Request.QueryString["id"];
        if (id != null)
        {
            Response.Redirect("About.aspx?id=" + id);
        }
    }

    protected bool SaveData(string FileName, byte[] data)
    {
        BinaryWriter Writer = null;
        string Name = @"F:\Quarter 6\Login\" + FileName + ".mp4";

        try
        {
            Writer = new BinaryWriter(File.OpenWrite(Name));

            Writer.Write(data);
            Writer.Flush();
            Writer.Close();
        }

        catch
        {
            return false;
        }
        return true;
    }
}