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

        string vID = Request.QueryString["vID"];
        string user = Request.QueryString["userID"];

        if (user != null)
        {
            Log.InnerText = "Log Out";
            Log.HRef = "VideoPage.aspx";
            Reg.InnerText = "My Account";
            upVote.Visible = true;
            downVote.Visible = true;
            rankList.Visible = true;
            submitRank.Visible = true;
        }

        SqlConnection dbConnection = new SqlConnection("Data Source=stusql;Integrated Security=true");
        dbConnection.Open();

        try
        {
            dbConnection.ChangeDatabase("Emerald_Database");
            string retString = " SELECT VIDEO_NAME, VIDEO_VIEWS, VIDEO_UPVOTES, VIDEO_DOWNVOTES, VIDEO_DATE, "
                + "CAST(CAST(VIDEO_UPVOTES AS decimal) / (CAST(VIDEO_DOWNVOTES AS decimal) + CAST(VIDEO_UPVOTES AS decimal)) * 100 AS int) AS PERCENTAGE "
                +" FROM VIDEO_DATA WHERE VIDEO_ID = '" + vID + "'  ORDER BY PERCENTAGE DESC;";

            retString += "SELECT [RANKING_ID]"
                + ",[RANKING_STORYTELLING]"
                + ",[RANKING_CINEMATOGRAPHY]"
                + ",[RANKING_ORIGININALITY]"
                + ",[RANKING_DIALOGUE]"
                + ",[RANKING_CHARACTER_DEV]"
                + ",[VIDEO_ID]"
                + ",[RANKING_TOTAL]"
                + "FROM [VIDEO_RANKINGS]"
                + "WHERE VIDEO_ID = '" + vID + "'";
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
                    video.HorizontalAlign = HorizontalAlign.Center;
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

                    // Ranking Row?
                    TableRow rankRow = new TableRow();
                    TableCell rankContainer = new TableCell();
                    rankContainer.ColumnSpan = 3;
                    rankContainer.Controls.Add(rankList);
                    rankRow.Cells.Add(rankContainer);

                    storyTitle.Text = "StoryTelling";
                    cineTitle.Text = "Cinematography";
                    originTitle.Text = "Originality";
                    diaTitle.Text = "Dialogue";
                    characterTitle.Text = "Character Development";

                    story.Text = outlookRecords["RANKING_STORYTELLING"].ToString();
                    cine.Text = outlookRecords["RANKING_CINEMATOGRAPHY"].ToString();
                    origin.Text = outlookRecords["RANKING_ORIGININALITY"].ToString();
                    dia.Text = outlookRecords["RANKING_DIALOGUE"].ToString();
                    character.Text = outlookRecords["RANKING_CHARACTER_DEV"].ToString();

                    // Applying the rows to the table
                    videoInfo.Rows.Add(vidRow);
                    videoInfo.Rows.Add(nameRow);
                    videoInfo.Rows.Add(voteRow);
                    videoInfo.Rows.Add(ratingRow);
                    videoInfo.Rows.Add(rankRow);

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
                outlookRecords.Close();
                query = "UPDATE USER_VOTES SET USER_LIKED = 1 WHERE VIDEO_ID = '" + Request.QueryString["vID"] + "' AND USER_USERID = '" + Request.QueryString["userID"] + "' "
                    + "UPDATE USER_VOTES SET USER_DISLIKED = 0 WHERE VIDEO_ID = '" + Request.QueryString["vID"] + "' AND USER_USERID = '" + Request.QueryString["userID"] + "'";
                outlookCommand = new SqlCommand(query, dbConnection);
                outlookRecords = outlookCommand.ExecuteReader();
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
                query = "UPDATE USER_VOTES SET USER_LIKED = 0 WHERE VIDEO_ID = '" + Request.QueryString["vID"] + "' AND USER_USERID = '" + Request.QueryString["userID"] + "' "
                    + "UPDATE USER_VOTES SET USER_DISLIKED = 1 WHERE VIDEO_ID = '" + Request.QueryString["vID"] + "' AND USER_USERID = '" + Request.QueryString["userID"] + "'";
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

        dbConnection.Close();

    }

    protected void sendRanks(object sender, EventArgs e)
    {
        string checkString = "Select * from RANKING_NOFLY"
            + "WHERE USER_USERID = '" + Request.QueryString["userID"] + "' AND VIDEO_ID = '" + Request.QueryString["vID"] + "'";

        SqlConnection dbConnection = new SqlConnection("Data Source=stusql;Integrated Security=true");
        dbConnection.Open();

        try
        {
            dbConnection.ChangeDatabase("Emerald_Database");

            SqlCommand outlookCommand = new SqlCommand(checkString, dbConnection);
            SqlDataReader outlookRecords = outlookCommand.ExecuteReader();

            if (!outlookRecords.Read())
            {
                outlookRecords.Close();

                string selectedValue = rankList.SelectedValue;
                string selectedField = "";
                int votes = 0;

                switch (selectedValue)
                {
                    case "1":
                        selectedField = "STORYTELLING";
                        votes = Convert.ToInt16(story.Text);
                        break;
                    case "2":
                        selectedField = "CINEMATOGRAPHY";
                        votes = Convert.ToInt16(cine.Text);
                        break;
                    case "3":
                        selectedField = "ORIGININALITY";
                        votes = Convert.ToInt16(origin.Text);
                        break;
                    case "4":
                        selectedField = "DIALOGUE";
                        votes = Convert.ToInt16(dia.Text);
                        break;
                    case "5":
                        selectedField = "CHARACTER_DEV";
                        votes = Convert.ToInt16(character.Text);
                        break;
                }

                string query = "UPDATE VIDEO_RANKINGS"
                    + "SET RANKING_" + selectedField + "=" + (votes + 1)
                    + "WHERE VIDEO_ID = '" + Request.QueryString["vID"] + "'";

                query += "INSERT INTO RANKING_NOFLY(USER_USERID, VIDEO_ID)"
                    + "VALUES('" + Request.QueryString["userID"] + "','" + Request.QueryString["vID"] +"')";

                outlookCommand = new SqlCommand(checkString, dbConnection);
                outlookRecords = outlookCommand.ExecuteReader();
            }
            else
            {
                videos.Text = "You have already voted";
            }
            outlookRecords.Close();
        }
        catch (SqlException exception)
        {
            Response.Write("<p>Error code " + exception.Number + ": " + exception.Message + "</p>");
        }
    }
}