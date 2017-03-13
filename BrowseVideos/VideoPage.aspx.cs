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
        String vName = Request.QueryString["vName"];

        SqlConnection dbConnection = new SqlConnection("Data Source=stusql;Integrated Security=true");
        dbConnection.Open();

        try
        {
            dbConnection.ChangeDatabase("Emerald_Database");
            string retString = " SELECT VIDEO_NAME, VIDEO_VIEWS, VIDEO_UPVOTES, VIDEO_DOWNVOTES, VIDEO_DATE, "
                + "CAST(CAST(VIDEO_UPVOTES AS decimal) / (CAST(VIDEO_DOWNVOTES AS decimal) + CAST(VIDEO_UPVOTES AS decimal)) * 100 AS int) AS PERCENTAGE "
                +" FROM VIDEO_DATA WHERE VIDEO_NAME = '" + vName + "'  ORDER BY PERCENTAGE DESC";
            SqlCommand outlookCommand = new SqlCommand(retString, dbConnection);
            SqlDataReader outlookRecords = outlookCommand.ExecuteReader();

            if (outlookRecords.Read())
            {
                videos.Text = ("");
                do
                {
                    // The video Row
                    videos.Text = "<video width=\"320\" hieght=\"240\" src=\"Videos/" + vName + ".mp4\" controls=\"controls\" /> ";


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
                    voteRow.Cells.Add(upvotes);
                    voteRow.Cells.Add(downvotes);
                    voteRow.Cells.Add(views);

                    // Third row in the table
                    TableRow ratingRow = new TableRow();
                    TableCell rating = new TableCell();
                    rating.ColumnSpan = 3;
                    rating.Text = "Rating: " + outlookRecords["PERCENTAGE"] + "%";
                    // Applying the cells to the row
                    ratingRow.Cells.Add(rating);

                    // Applying the rows to the table
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
}