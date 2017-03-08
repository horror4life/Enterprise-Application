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

public partial class _Default : System.Web.UI.Page
{
    //protected void Page_Load(object sender, EventArgs e)
    //{
    //    SqlConnection dbConnection = new SqlConnection("Data Source=stusql;Initial Catalog=Emerald_Studios; Integrated Security=true");
    //    try
    //    {
    //        dbConnection.Open();
    //        SqlCommand cmd = new SqlCommand(@"SELECT Count(*) FROM USER_DATA
    //                                            WHERE EMAIL_ADDRESS=@EMAIL_ADDRESS and 
    //                                            USER_PASSWORD=@USER_PASSWORD", dbConnection);
    //        cmd.Parameters.AddWithValue("@EMAIL_ADDRESS");
    //    }
    //}

    protected void FTPUpload(object sender, EventArgs e)
    {
        // FTP Server URL.
        string ftp = "ftp://yourserver.com/";

        // FTP Folder name. Leave blank if you want to upload to root folder.
        string ftpFolder = "Uploads/";

        byte[] filebytes = null;

        // Read the FileName and convert it to Byte array.
        string fileName = Path.GetFileName(FileUpload1.FileName);
        using (StreamReader fileStream = new StreamReader(FileUpload1.PostedFile.InputStream))
        {
            filebytes = Encoding.UTF8.GetBytes(fileStream.ReadToEnd());
            fileStream.Close();
        }

        try
        {
            // Create FTP Request.
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftp + ftpFolder + fileName);
            request.Method = WebRequestMethods.Ftp.UploadFile;

            // Enter FTP Server credentials
            request.Credentials = new NetworkCredential("UserName", "Password");
            request.ContentLength = filebytes.Length;
            request.UsePassive = true;
            request.UseBinary = true;
            request.ServicePoint.ConnectionLimit = filebytes.Length;
            request.EnableSsl = false;

            using (Stream requestStream = request.GetRequestStream())
            {
                requestStream.Write(filebytes, 0, filebytes.Length);
                requestStream.Close();
            }

            FtpWebResponse response = (FtpWebResponse)request.GetResponse();

            lblMessage.Text += fileName + " uploaded.<br />";
            response.Close();
        }
        catch (WebException ex)
        {
            throw new Exception((ex.Response as FtpWebResponse).StatusDescription);
        }
    }

}