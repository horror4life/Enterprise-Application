using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class BrowseVideos : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {

        string user = Request.QueryString["userID"];

        if(user != null)
        {
            Log.InnerText = "Log out";
            Log.HRef = "BrowseVideos.aspx";
            Reg.InnerText = "My Account";
            //Reg.HRef = "MyAccount.aspx&userID=" + user;
        }

        SqlConnection dbConnection = new SqlConnection("Data Source=stusql;Integrated Security=true");
        dbConnection.Open();

        try
        {
            dbConnection.ChangeDatabase("Emerald_Database");
            
            string vidCount = " SELECT COUNT(VIDEO_NAME) AS NUM_VIDEOS FROM VIDEO_DATA";
            SqlCommand countVideos = new SqlCommand(vidCount, dbConnection);
            SqlDataReader VideoNumber = countVideos.ExecuteReader();
            int numberOfVideos = 0;
            if(VideoNumber.Read())
            {
                numberOfVideos = Convert.ToInt16(VideoNumber["NUM_VIDEOS"]);
            }
            else
            {
                numberOfVideos = 0;
            }
            VideoNumber.Close();

            View view = new View();
            //MultiView1.Controls.Add(view);
            

            string retString = " SELECT VIDEO_ID, VIDEO_NAME, VIDEO_VIEWS, VIDEO_UPVOTES, VIDEO_DOWNVOTES, VIDEO_DATE, "
                + "CAST(CAST(VIDEO_UPVOTES AS decimal) / (CAST(VIDEO_DOWNVOTES AS decimal) + CAST(VIDEO_UPVOTES AS decimal)) * 100 AS int) AS PERCENTAGE "
                + "FROM VIDEO_DATA ORDER BY PERCENTAGE DESC";
            SqlCommand outlookCommand = new SqlCommand(retString, dbConnection);
            SqlDataReader outlookRecords = outlookCommand.ExecuteReader();

            if (outlookRecords.Read())
            {
                videos.Text = ("");
                //int i = 0;
                do
                {
                    
                    //Table VideoTable = new Table();

                    // the first row in the section of the table
                    TableRow nameRow = new TableRow();
                    TableCell name = new TableCell();
                    name.ColumnSpan = 2;

                    HyperLink link = new HyperLink();
                    link.NavigateUrl = "VideoPage.aspx?vID=" + outlookRecords["VIDEO_ID"] + "&userID=" + user;
                    link.Text = outlookRecords["VIDEO_NAME"].ToString();
                    name.Controls.Add(link);

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

                    // the breakpoint row
                    TableFooterRow breakPoint = new TableFooterRow();
                    TableCell horizontalRule = new TableCell();
                    horizontalRule.ColumnSpan = 3;
                    horizontalRule.Text = "<hr/>";
                    // Applying the cells to the row
                    breakPoint.Cells.Add(horizontalRule);

                    // Applying the rows to the table

                    VideoTable.Rows.Add(nameRow);
                    VideoTable.Rows.Add(voteRow);
                    VideoTable.Rows.Add(ratingRow);
                    VideoTable.Rows.Add(breakPoint);

                } while (outlookRecords.Read());
                
                outlookRecords.Close();
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