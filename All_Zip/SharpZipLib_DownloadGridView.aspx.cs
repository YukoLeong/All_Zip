using ICSharpCode.SharpZipLib.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SharpZipLib_DownloadGridView : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            PopulateFiles();
        }
    }

    private void PopulateFiles()
    {
        DirectoryInfo DI = new DirectoryInfo(Server.MapPath("~/DownloadFolder"));
        List<MyFile> allFiles = new List<MyFile>();
        foreach (var i in DI.GetFiles())
        {
            allFiles.Add(new MyFile
            {
                FileName = i.Name,
                FilePath = i.FullName.Replace(Server.MapPath("~/"), ""), // For Get URL FORM Full Path
                FileSize = i.Length / 1024
            }
            );
        }
        GridView1.DataSource = allFiles;
        GridView1.DataBind();
    }

    protected void BtnDownloadAll_Click(object sender, EventArgs e)
    {
        // Here we will create zip file & download
        string zipFileName = "MyZipFiles.zip";
        Response.ContentType = "application/zip";
        Response.AddHeader("content-disposition", "fileName=" + zipFileName);
        byte[] buffer = new byte[4096];
        ZipOutputStream zipOutputStream = new ZipOutputStream(Response.OutputStream);
        zipOutputStream.SetLevel(3);
        try
        {
            DirectoryInfo DI = new DirectoryInfo(Server.MapPath("~/DownloadFolder"));
            foreach (var i in DI.GetFiles())
            {
                Stream fs = File.OpenRead(i.FullName);
                ZipEntry zipEntry = new ZipEntry(ZipEntry.CleanName(i.Name));
                zipEntry.Size = fs.Length;
                zipOutputStream.PutNextEntry(zipEntry);
                int count = fs.Read(buffer, 0, buffer.Length);
                while (count > 0)
                {
                    zipOutputStream.Write(buffer, 0, count);
                    count = fs.Read(buffer, 0, buffer.Length);
                    if (!Response.IsClientConnected)
                    {
                        break;
                    }
                    Response.Flush();
                }
                fs.Close();
            }
            zipOutputStream.Close();
            Response.Flush();
            Response.End();
        }
        catch (Exception)
        {
            throw;
        }
    }
}

internal class MyFile
{
    public string FileName { get; set; }
    public string FilePath { get; set; }
    public decimal FileSize { get; set; }
}