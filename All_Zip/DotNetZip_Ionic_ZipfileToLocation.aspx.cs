using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DotNetZip_Ionic_ZipfileToLocation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)          //  運行成功230201  
    {
        try
        {
            using (ZipFile zip = new ZipFile())
            {
                //壓縮指定檔案到指定地方
                zip.AddFile(@"C:\Users\kanon\Desktop\New folder\pic1.png");
                zip.AddFile(@"C:\Users\kanon\Desktop\New folder\pic2.png");
                zip.AddFile(@"C:\Users\kanon\Desktop\New folder\pic3.png");

                zip.Save(@"C:\Users\kanon\Desktop\New folder\grouppic.zip");
            }
            Response.Write("File Zipped successfully");        
        }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        //https://www.codeproject.com/Tips/622746/Uploading-a-file-and-creating-a-Zip-File-in-ASP-NE


        if (FileUpload1.HasFile)
        {
            string path = Server.MapPath("DownloadFolder/" +
            Path.GetFileName(FileUpload1.PostedFile.FileName));
            FileUpload1.SaveAs(path);
            string NewPath = Server.MapPath("DownloadFolder/");
            string[] filenames = Directory.GetFiles(NewPath);
            using (Ionic.Zip.ZipFile zip = new Ionic.Zip.ZipFile())
            {
                string date = DateTime.Now.ToString("d");
                date = date.Replace("/", "");
                zip.AddFiles(filenames, date);
                zip.Save(Server.MapPath("~/DownloadFolder/" + date + ".zip"));
                Label1.Text = "ZIP File Created Successfully";
            }
            if (Label1.Text == "ZIP File Created Successfully")
            {
                // 刪除資料夾全部檔案
                // Array.ForEach(Directory.GetFiles(NewPath),
                // delegate (string deleteFile) { File.Delete(deleteFile); });          
            }
        }
    }
}