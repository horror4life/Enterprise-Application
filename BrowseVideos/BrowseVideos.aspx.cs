using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class BrowseVideos : System.Web.UI.Page
{
    private static bool loggedIn = false;
    private static bool fullInfo = false;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //Button1.Click += new EventHandler(callMore);

        }

        SqlConnection dbConnection = new SqlConnection("Data Source=stusql;Integrated Security=true");
        dbConnection.Open();

        try
        {
            dbConnection.ChangeDatabase("Emerald_Database");
            string retString = " SELECT VIDEO_NAME, VIDEO_VIEWS, VIDEO_UPVOTES, VIDEO_DOWNVOTES, VIDEO_DATE, CAST(CAST(VIDEO_UPVOTES AS decimal) / (CAST(VIDEO_DOWNVOTES AS decimal) + CAST(VIDEO_UPVOTES AS decimal)) * 100 AS int) AS PERCENTAGE FROM VIDEO_DATA ORDER BY PERCENTAGE DESC";
            SqlCommand outlookCommand = new SqlCommand(retString, dbConnection);
            SqlDataReader outlookRecords = outlookCommand.ExecuteReader();

            if (outlookRecords.Read())
            {
                videos.Text = ("");
                do
                {
                    // the first row in the section of the table
                    TableRow nameRow = new TableRow();
                    TableCell name = new TableCell();
                    name.ColumnSpan = 2;

                    HyperLink link = new HyperLink();
                    link.NavigateUrl = "VideoPage.aspx?vName=" + outlookRecords["VIDEO_NAME"];
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


    ///*
    // * On Click event to get more rating information
    // */
    //void callMore(object sender, EventArgs e)
    //{
    //    if (fullInfo)
    //        fullInfo = false;
    //    else
    //        fullInfo = true;

    //}
}