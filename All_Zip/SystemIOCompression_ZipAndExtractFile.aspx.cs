using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO.Compression;                                    //要加上這個
using System.IO;
using System.Text;
using System.Reflection;
using System.Collections;
using System.Xml.Linq;
using System.Text.RegularExpressions;
using System.Web.Script.Serialization;
using Newtonsoft.Json.Linq;

public partial class SystemIOCompression_ZipAndExtractFile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)           // 建立zip檔
    {

        //https://learn.microsoft.com/en-us/dotnet/api/system.io.compression.zipfile.createfromdirectory?view=net-7.0

        string startPath = @"C:\Users\kanon\Desktop\New folder";       // 想要變成zip資料的文件夾
        string zipPath = @"C:\Users\kanon\Desktop\zipfilestor.zip";    // 想要輸出zip的路徑
        ZipFile.CreateFromDirectory(startPath, zipPath);

    }

    protected void Button2_Click(object sender, EventArgs e)                 // 解壓zip檔
    {
        string zipPath = @"C:\Users\kanon\Desktop\zipfilestor.zip";          // 想要zip檔的路徑
        string extractPath = @"C:\Users\kanon\Desktop\extractfile.zip";      // 想要輸出zip的路徑
        ZipFile.ExtractToDirectory(zipPath, extractPath);
    }

    // --


    protected void Button3_Click(object sender, EventArgs e)
    {
        string zipPath = @"C:\Users\kanon\Desktop\test.zip";
        string extractPath = Path.GetFullPath(@"C:\Users\kanon\Desktop\txthere");
        //string extractPath = Path.GetFullPath("C:\\Users\\kanon\\Desktop\\abc");    // 路徑的2種寫法 上面那種比較好
        System.IO.Directory.CreateDirectory(extractPath);   // If the folder does not exist yet, it will be created
                                                            //extractPath = TextBox1.Text; 

        if (!extractPath.EndsWith(Path.DirectorySeparatorChar.ToString(), StringComparison.Ordinal))          // Path.DirectorySeparatorChar = 92'\\'  , StringComparison.Ordinal = Ordinal
            extractPath += Path.DirectorySeparatorChar;                 // extractPath = C:\\Users\\kanon\\Desktop\\txthere    Path.DirectorySeparatorChar = 92'\\'

        using (ZipArchive archive = System.IO.Compression.ZipFile.OpenRead(zipPath))
        {
            foreach (ZipArchiveEntry entry in archive.Entries)            // archive.Entries = 4 (檔案總數)
            {                                                                              // StringComparison.OrdinalIgnoreCase = OrdinalIgnoreCase
                if (entry.FullName.EndsWith(".txt", StringComparison.OrdinalIgnoreCase))   // 只解壓zip檔的.txt檔案       // entry, entry.FullName = 111.txt    找到txt檔    
                {                                                     // destinationPath = C:\\Users\\kanon\\Desktop\\txthere\\111.txt
                    string destinationPath = Path.GetFullPath(Path.Combine(extractPath, entry.FullName));
                    // 如果zip檔裡面有資料夾 要確保輸入的路徑也有同名的資料夾
                    if (destinationPath.StartsWith(extractPath, StringComparison.Ordinal))   // StartsWith = true
                        entry.ExtractToFile(destinationPath);
                }
            }
        }
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        using (FileStream zipToOpen = new FileStream(@"C:\Users\kanon\Desktop\result.zip", FileMode.Open))     // 在已存在的zip檔裡面增加txt檔
        {
            using (ZipArchive archive = new ZipArchive(zipToOpen, ZipArchiveMode.Update))
            {
                ZipArchiveEntry readmeEntry = archive.CreateEntry("tryadd.txt");             // 建立tryadd.txt檔案
                                                                                             ////Response.Write(readmeEntry);                                               // tryadd.txt
                using (StreamWriter writer = new StreamWriter(readmeEntry.Open()))
                {
                    writer.WriteLine("Information about this packageaaa.");                     // 在tryadd.txt檔案打上文字
                    writer.WriteLine("========================");
                }
            }
        }
    }

    protected void Button5_Click(object sender, EventArgs e)         // 打開zip和把指定檔案壓縮出來  (OK)
    {
        using (ZipArchive sourceArchive = ZipFile.OpenRead(@"C:\Users\kanon\Desktop\result.zip"))
        {
            var entry = sourceArchive.GetEntry("tryadd.txt");
            using (ZipArchive destArchive = ZipFile.Open(@"C:\Users\kanon\Desktop\update.zip", ZipArchiveMode.Update))
            {
                using (var existinFileStream = entry.Open())
                {
                    var newFile = destArchive.CreateEntry(entry.FullName);
                    using (var newFileStream = newFile.Open())
                    {
                        existinFileStream.CopyTo(newFileStream);
                    }
                }
            }
        }
    }

    protected void Button6_Click(object sender, EventArgs e)                // 更改zip檔裡面的全部文字 (OK)
    {

        // https://stackoverflow.com/questions/46810169/overwrite-contents-of-ziparchiveentry


        using (var archive = ZipFile.Open(@"C:\Users\kanon\Desktop\EXLSTSE.zip", ZipArchiveMode.Update))
        {
            StringBuilder document;
            //var entry = archive.GetEntry("input.txt");                       
            var entry = archive.GetEntry("resources/public/input.data");       //txt和data檔都可以改
            using (StreamReader reader = new StreamReader(entry.Open()))
            {
                document = new StringBuilder(reader.ReadToEnd());
            }

            document.Replace("123", "555");                 //變更zip檔文字

            using (StreamWriter writer = new StreamWriter(entry.Open()))       //要有這個method才會執行變更
            {
                writer.Write(document);
            }
        }
    }


    //----testing but Could not find a part of the path 'C:\Program Files\IIS Express\Users\kanon\Desktop\test.zip'.
    protected void Button7_Click(object sender, EventArgs e)
    {

        //https://stackoverflow.com/questions/17232414/creating-a-zip-archive-in-memory-using-system-io-compression


        using (var memoryStream = new MemoryStream())
        {
            using (var archive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
            {
                var demoFile = archive.CreateEntry(@"C:\Users\kanon\Desktop\foo.txt");

                using (var entryStream = demoFile.Open())
                using (var streamWriter = new StreamWriter(entryStream))
                {
                    streamWriter.Write("Bar!");
                }
            }

            // Could not find a part of the path 'C:\Program Files\IIS Express\Users\kanon\Desktop\test.zip'.
            //using (var fileStream = new FileStream(@"C:Users\kanon\Desktop\test.zip", FileMode.Create)) 
            //{
            //    memoryStream.Seek(0, SeekOrigin.Begin);
            //    memoryStream.CopyTo(fileStream);
            //}
        }

    }

    protected void Button8_Click(object sender, EventArgs e)       // count上傳檔案有多少行  配合FileUpload
    {

        // https://stackoverflow.com/questions/41891198/read-textfile-and-count-number-of-lines-into-textbox-using-asp-net-c-sharp

        string text = String.Empty;
        using (StreamReader stRead = new StreamReader(FileUpload1.PostedFile.InputStream))
        {
            int i = 0;
            //to write textfile content
            while (!stRead.EndOfStream)
            {
                text += stRead.ReadLine() + Environment.NewLine;
                i++;
            }
            Response.Write(i);
        }

    }

    protected void Button9_Click(object sender, EventArgs e)      // 更改zip檔裡面的文本內容
    {
        // archive = System.IO.Compression.ZipArchive
        using (var archive = ZipFile.Open(@"C:\Users\kanon\Desktop\EXLSTSE.zip", ZipArchiveMode.Update))
        {
            StringBuilder sb;                 // sb = null
                                              //var path = archive.GetEntry("input.txt");               // path = resources/public/Ad_Hoc_Report_Views/EXLSTSE_files/stateXMLtest.data        
            var path = archive.GetEntry("resources/public/Ad_Hoc_Report_Views/EXLSTSE_files/stateXMLtest.data");       //txt和data檔都可以改
            using (StreamReader sr = new StreamReader(path.Open()))    // sr = System.IO.StreamReader
            {
                sb = new StringBuilder(sr.ReadToEnd());    // sb = 整個文本內容
            }

            sb.Replace("123", "555");                 //變更zip檔文字      // Replace是StringBuilder的method  

            using (StreamWriter sw = new StreamWriter(path.Open()))       //要有這個method才會執行變更
            {
                sw.Write(sb);
            }
        }
    }

    protected void Button10_Click(object sender, EventArgs e)          // 數zip裡面的某文本某字串有多少行
    {
        // archive = System.IO.Compression.ZipArchive
        using (var archive = ZipFile.Open(@"C:\Users\kanon\Desktop\EXLSTSE.zip", ZipArchiveMode.Update))
        {
            string line = null;
            //var path = archive.GetEntry("input.txt");          //txt和data檔都可以改
            var path = archive.GetEntry("resources/public/Ad_Hoc_Report_Views/EXLSTSE_files/stateXMLtest.data");
            var arlist1 = new ArrayList();
            var arlist2 = new ArrayList();
            using (StreamReader sr = new StreamReader(path.Open()))    // sr = System.IO.StreamReader
            {
                while (!sr.EndOfStream)
                {
                    line = sr.ReadLine();
                    line = line.Trim();
                    string pattern1 = @"EXLSTSE\.EXLSTSE_\w+CODE";
                    string pattern2 = @"Para_\w+";
                    var matches1 = Regex.Matches(line, pattern1);
                    var matches2 = Regex.Matches(line, pattern2);
                    foreach (Match match in matches1)
                    {
                        arlist1.Add(match.Value);

                    }
                    foreach (Match match in matches2)
                    {
                        arlist2.Add(match.Value);
                    }
                }
                for (int i = 0; i < arlist1.Count; i++)      // 排除數組裡面相同的內容
                {
                    for (int j = i + 1; j < arlist1.Count; j++)
                        if (arlist1[i].ToString() == arlist1[j].ToString())
                            arlist1.Remove(arlist1[j]);
                }

                for (int i = 0; i < arlist1.Count; i++)
                    Response.Write(arlist1[i] + "<br>");
                for (int i = 0; i < arlist2.Count; i++)
                    Response.Write(arlist2[i] + "<br>");

            }

            this.ClientScript.RegisterStartupScript(this.GetType(), "test", "<script type='text/javascript'>startChangeHtml()</script>");

            //sb.Replace("123", "555");                 //變更zip檔文字      // Replace是StringBuilder的method  

            //using (StreamWriter sw = new StreamWriter(path.Open()))       //要有這個method才會執行變更
            //{
            //    sw.Write(sb);
            //}
        }
    }


    protected void Button11_Click(object sender, EventArgs e)
    {
        using (var archive = ZipFile.Open(@"C:\Users\kanon\Desktop\EXLSTSE.zip", ZipArchiveMode.Update))
        {
            int counter = 0;
            string line = null;
            var path = archive.GetEntry("resources/public/Ad_Hoc_Report_Views/EXLSTSE_files/stateXMLtest.data");
            var arlist1 = new ArrayList();
            var arlist2 = new ArrayList();
            using (StreamReader sr = new StreamReader(path.Open()))
            {
                while (!sr.EndOfStream)
                {
                    line = sr.ReadLine();
                    line = line.Trim();
                    string pattern = @"<parameterizedExpressionString>(.+?) (==|in) (.+?)<\/parameterizedExpressionString>";
                    var matches = Regex.Matches(line, pattern);
                    foreach (Match match in matches)
                    {
                        arlist1.Add(match.Groups[1].Value);
                        arlist2.Add(match.Groups[3].Value);
                    }
                    if (line.ToString().Contains("<parameterizedExpressionString>") == true)     // 31 char
                    {
                        counter++;
                    }
                }
                for (int i = 0; i < arlist1.Count; i++)
                    Response.Write(arlist1[i] + "<br>");
                for (int i = 0; i < arlist2.Count; i++)
                    Response.Write(arlist2[i] + "<br>");
                TextBox1.Text = counter.ToString();
                Response.Write(counter);
            }

            var serializer = new JavaScriptSerializer();
            var arlist1Json = serializer.Serialize(arlist1);
            var arlist2Json = serializer.Serialize(arlist2);
            var script1 = string.Format("startChangeHtml({0});", serializer.Serialize(arlist1));
            var script2 = string.Format("startChangeHtml({0});", serializer.Serialize(arlist1));
            ClientScript.RegisterStartupScript(GetType(), "call", script1, true);
            ClientScript.RegisterStartupScript(GetType(), "call", script2, true);

            this.ClientScript.RegisterStartupScript(this.GetType(), "test", "<script type='text/javascript'>ChangeHtml()</script>");
        }
    }


}