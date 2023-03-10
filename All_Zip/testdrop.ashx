<%@ WebHandler Language="C#" Class="testdrop" %>

using System;
using System.Web;
using System.IO;

public class testdrop : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        try
        {
            HttpPostedFile uploadedFile = context.Request.Files["file"];
            if (uploadedFile != null && uploadedFile.ContentLength > 0)
            {
                string fileExtension = Path.GetExtension(uploadedFile.FileName);
                if (fileExtension.ToLower() != ".zip")
                {
                    context.Response.Write("只能上传zip文件");
                    return;
                }
                //string savePath = context.Server.MapPath("~/ZipFolder/") + uploadedFile.FileName;
                //string savePath = context.Server.MapPath(@"ZipFolder\") + uploadedFile.FileName;     // 未測試
                string savePath = context.Server.MapPath(@"\ZipFolder\") + uploadedFile.FileName;     // azure OK  檔案放在kudu
                uploadedFile.SaveAs(savePath);
                //context.Response.Write("上傳成功");
                context.Response.Write(uploadedFile.FileName);

                // 获取文件大小并返回
                long fileSizeInBytes = uploadedFile.ContentLength;
                string[] sizes = { "bytes", "KB", "MB", "GB", "TB" };
                double fileSize = fileSizeInBytes;
                int order = 0;
                while (fileSize >= 1024 && order < sizes.Length - 1)
                {
                    order++;
                    fileSize /= 1024;
                }
                string fileSizeString = String.Format("{0:0.##} {1}", fileSize, sizes[order]);
                context.Response.Write("|" + fileSizeString);


                //// 保存文件名到Session中
                //if (context.Session != null)
                //{
                //    context.Session["filename"] = uploadedFile.FileName;
                //    //context.Response.Write(uploadedFile.FileName); // 返回文件名稱

                //    // 获取文件大小并返回
                //    fileSizeInBytes = uploadedFile.ContentLength;
                //    fileSize = string.Format("{0} KB", (fileSizeInBytes / 1024));
                //    context.Response.Write("|" + fileSize); // 返回文件名稱和文件大小，使用 | 分隔符
                //}
            }
            else
            {
                context.Response.Write("文件未選中或文件大小為0");
            }
        }
        catch (Exception ex)
        {
            context.Response.Write("上傳失敗: " + ex.Message);
        }
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}