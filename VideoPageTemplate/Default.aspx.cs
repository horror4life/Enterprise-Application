using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page
{
    private static bool loggedIn = false;
    private static bool fullInfo = false;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Button1.Click += new EventHandler(callMore);

        }

        SqlConnection dbConnection = new SqlConnection("Data Source=stusql;Integrated Security=true");
        dbConnection.Open();

        try
        {
            dbConnection.ChangeDatabase("Emerald_Database");
            string retString = "SELECT [VIDEO_NAME], [VIDEO_VIEWS], [VIDEO_UPVOTES], [VIDEO_DOWNVOTES], [VIDEO_DATE] "
                //+ ",[Ranking_StoryTelling], [RANKING_CINEMATOGRAPHY], [RANKING_ORIGININALITY], [RANKING_DIALOGUE], [RANKING_CHARACTER_DEV]"
                + "FROM [VIDEO_DATA]"/*, [VIDEO_RANKINGS]*/
                + "ORDER BY [VIDEO_UPVOTES] " + \ + " [VIDEO_UPVOTES] + [VIDEO_DOWNVOTES];
            SqlCommand outlookCommand = new SqlCommand(retString, dbConnection);
            SqlDataReader outlookRecords = outlookCommand.ExecuteReader();

            if(outlookRecords.Read())
            {
                videos.Text = ("<table width='50%' border-bottom='0'");
                do
                {
                        videos.Text += "<tr>";
                    //videos.Text += ("<td colspan=\"2\">");
                    //videos.Text += ("<a href=\"#\">");
                    //videos.Text += ("<img height=\"200\" width=\"200\" alt=\"Play Video\" class=\"auto-style2\" longdesc=\"Click the Button to Play the video\" src=\"images/play_button.png\" />");
                    //videos.Text += ("</a>");
                    videos.Text += "<video height=\"240\" width=\"300\" controls>";
                    videos.Text += "<source src=\"Videos/" + outlookRecords["VIDEO_NAME"] + ".mp4\" type= \"video/mp4\">";
                    videos.Text += "</video>";
                    videos.Text += ("</td>");
                    videos.Text += ("</tr>");

                    videos.Text += ("<tr>");
                    videos.Text += ("<td>" + outlookRecords["VIDEO_NAME"] + "</td>");
                    videos.Text += ("<td>Views: " + outlookRecords["VIDEO_VIEWS"] + "</td>");
                    videos.Text += ("</tr>");
                    videos.Text += ("<tr>");
                    videos.Text += ("<td>Upvotes: " + outlookRecords["VIDEO_UPVOTES"] + "</td>");
                    videos.Text += ("<td>Downvotes: " + outlookRecords["VIDEO_DOWNVOTES"] + "</td>");
                    videos.Text += ("</tr>");
                    videos.Text += ("<tr>");
                    videos.Text += ("<td>" + outlookRecords["VIDEO_DATE"] + "</td>");
                    videos.Text += ("</tr>");

                    //if (fullInfo)
                    //{

                    //    videos.Text += ("<tr>");
                    //    videos.Text += ("<td>" + outlookRecords["RANKING_STORYTELLING"] + "</td>");
                    //    videos.Text += ("<td>" + outlookRecords["RANKING_CINEMATOGRAPHY"] + "</td>");
                    //    videos.Text += ("<td>" + outlookRecords["RANKING_ORIGINALITY"] + "</td>");
                    //    videos.Text += ("<td>" + outlookRecords["RANKING_DIALOGUE"] + "</td>");
                    //    videos.Text += ("<td>" + outlookRecords["RANKING_CHARACTER_DEV"] + "</td>");
                    //    videos.Text += ("</tr>");

                    //}
                } while (outlookRecords.Read());
                videos.Text += ("</table>");
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


    /*
     * On Click event to get more rating information
     */
    void callMore(object sender, EventArgs e)
    {
        if (fullInfo)
            fullInfo = false;
        else
            fullInfo = true;

    }
}