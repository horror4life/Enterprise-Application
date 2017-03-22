using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class VideoPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        String vID = Request.QueryString["vID"];
        string user = Request.QueryString["userID"];

        if (user != null)
        {
            Log.InnerText = "Log Out";
            Log.HRef = "VideoPage.aspx";
            Reg.InnerText = "My Account";
            upVote.Visible = true;
            downVote.Visible = true;
        }

        SqlConnection dbConnection = new SqlConnection("Data Source=stusql;Integrated Security=true");
        dbConnection.Open();

        try
        {
            dbConnection.ChangeDatabase("Emerald_Database");
            string retString = " SELECT VIDEO_NAME, VIDEO_VIEWS, VIDEO_UPVOTES, VIDEO_DOWNVOTES, VIDEO_DATE, "
                + "CAST(CAST(VIDEO_UPVOTES AS decimal) / (CAST(VIDEO_DOWNVOTES AS decimal) + CAST(VIDEO_UPVOTES AS decimal)) * 100 AS int) AS PERCENTAGE "
                +" FROM VIDEO_DATA WHERE VIDEO_ID = '" + vID + "'  ORDER BY PERCENTAGE DESC";
            SqlCommand outlookCommand = new SqlCommand(retString, dbConnection);
            SqlDataReader outlookRecords = outlookCommand.ExecuteReader();

            if (outlookRecords.Read())
            {
                videos.Text = ("");
                do
                {
                    // The video Row
                    string videoTag = "<video width=\"550\" src=\"Videos/" + outlookRecords["VIDEO_NAME"] + ".mp4\" controls=\"controls\" /> ";
                    TableRow vidRow = new TableRow();
                    TableCell video = new TableCell();
                    video.ColumnSpan = 3;
                    video.Text = videoTag;
                    vidRow.Cells.Add(video);

                    // the first row in the section of the table
                    TableRow nameRow = new TableRow();
                    TableCell name = new TableCell();
                    name.ColumnSpan = 2;
                    name.Text =  outlookRecords["VIDEO_NAME"].ToString();
                    TableCell date = new TableCell();
                    date.Text = outlookRecords["VIDEO_DATE"].ToString();
                    // Applying the cells to the row
                    nameRow.Cells.Add(name);
                    nameRow.Cells.Add(date);

                    // Second row in this section of the table
                    TableRow voteRow = new TableRow();
                    TableCell upvotes = new TableCell();
                    upvotes.Text = "Upvotes: " + outlookRecords["VIDEO_UPVOTES"];
                    TableCell downvotes = new TableCell();
                    downvotes.Text = "Downvotes: " + outlookRecords["VIDEO_DOWNVOTES"];
                    TableCell views = new TableCell();
                    views.Text = "Views: " + outlookRecords["VIDEO_VIEWS"];
                    // Applying the cells to the row
                    voteRow.Cells.Add(views);
                    voteRow.Cells.Add(upvotes);
                    voteRow.Cells.Add(downvotes);

                    // Third row in the table
                    TableRow ratingRow = new TableRow();
                    TableCell rating = new TableCell();
                    rating.Text = "Rating: " + outlookRecords["PERCENTAGE"] + "%";
                    TableCell upImage = new TableCell();
                    TableCell downImage = new TableCell();
                    upImage.Controls.Add(upVote);
                    downImage.Controls.Add(downVote);
                    // Applying the cells to the row
                    ratingRow.Cells.Add(rating);
                    ratingRow.Cells.Add(upImage);
                    ratingRow.Cells.Add(downImage);

                    // Applying the rows to the table
                    videoInfo.Rows.Add(vidRow);
                    videoInfo.Rows.Add(nameRow);
                    videoInfo.Rows.Add(voteRow);
                    videoInfo.Rows.Add(ratingRow);

                } while (outlookRecords.Read());
            }
            else
            {
                videos.Text = ("No Records Found");
            }
        }
        catch (SqlException exception)
        {
            Response.Write("<p>Error code " + exception.Number + ": " + exception.Message + "</p>");
        }

        dbConnection.Close();
    }

    protected void likeVideo(object sender, EventArgs e)
    {
        string query = "SELECT * FROM USER_VOTES WHERE VIDEO_ID = '" + Request.QueryString["vID"] + "' AND USER_USERID = '" + Request.QueryString["userID"] + "'";
        SqlConnection dbConnection = new SqlConnection("Data Source=stusql;Integrated Security=true");
        dbConnection.Open();

        try
        {
            dbConnection.ChangeDatabase("Emerald_Database");
            
            SqlCommand outlookCommand = new SqlCommand(query, dbConnection);
            SqlDataReader outlookRecords = outlookCommand.ExecuteReader();

            if (outlookRecords.Read())
            {
                string query2 = "UPDATE USER_VOTES SET USER_LIKED = 1 WHERE VIDEO_ID = '" + Request.QueryString["vID"] + "' AND USER_USER_ID = '" 
                    + Request.QueryString["userID"];

                query2 += " UPDATE USER_VOTES SET USER_DISLIKED = 0 WHERE VIDEO_ID = '" + Request.QueryString["vID"] + "' AND USER_USER_ID = '" 
                    + Request.QueryString["userID"];
            }
            else
            {
                outlookRecords.Close();
                query = "INSERT INTO USER_VOTES(VIDEO_ID, USER_USERID, USER_LIKED, USER_DISLIKED)"
                    + " VALUES('" + Request.QueryString["vID"] + "', '" + Request.QueryString["userID"] + "', '1', '0')";
                outlookCommand = new SqlCommand(query, dbConnection);
                outlookRecords = outlookCommand.ExecuteReader();
            }
            outlookRecords.Close();
        }
        catch (SqlException exception)
        {
            Response.Write("<p>Error code " + exception.Number + ": " + exception.Message + "</p>");
        }

        dbConnection.Close();
    }

    protected void dislikeVideo(object sender, EventArgs e)
    {

        string query = "SELECT * FROM USER_VOTES WHERE VIDEO_ID = '" + Request.QueryString["vID"] + "' AND USER_USERID = '" + Request.QueryString["userID"] + "'";
        SqlConnection dbConnection = new SqlConnection("Data Source=stusql;Integrated Security=true");
        dbConnection.Open();

        try
        {
            dbConnection.ChangeDatabase("Emerald_Database");

            SqlCommand outlookCommand = new SqlCommand(query, dbConnection);
            SqlDataReader outlookRecords = outlookCommand.ExecuteReader();

            if (outlookRecords.Read())
            {
                outlookRecords.Close();
                query = "UPDATE USER_VOTES SET USER_LIKED = 0 WHERE VIDEO_ID = '" + Request.QueryString["vID"] + "' AND USER_USER_ID = '" + Request.QueryString["userID"] + " "
                    + "UPDATE USER_VOTES SET USER_DISLIKED = 1 WHERE VIDEO_ID = '" + Request.QueryString["vID"] + "' AND USER_USER_ID = '" + Request.QueryString["userID"];
                outlookCommand = new SqlCommand(query, dbConnection);
                outlookRecords = outlookCommand.ExecuteReader();
            }
            else
            {
                outlookRecords.Close();
                query = "INSERT INTO USER_VOTES(VIDEO_ID, USER_USERID, USER_LIKED, USER_DISLIKED)"
                    + " VALUES('" + Request.QueryString["vID"] + "', '" + Request.QueryString["userID"] + "', '0', '1')";
                outlookCommand = new SqlCommand(query, dbConnection);
                outlookRecords = outlookCommand.ExecuteReader();
            }
            outlookRecords.Close();
        }
        catch (SqlException exception)
        {
            Response.Write("<p>Error code " + exception.Number + ": " + exception.Message + "</p>");
        }


    }
}