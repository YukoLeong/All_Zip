using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Compression;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SystemIOCompression_ZipAndExtractFile2 : System.Web.UI.Page
{
    ArrayList array1 = new ArrayList();
    ArrayList array2 = new ArrayList();
    string[] values;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void LoadButton_Click(object sender, EventArgs e)
    {
        using (var archive = ZipFile.Open(Server.MapPath(@"ZipFolder\EXLSTSE.zip"), ZipArchiveMode.Update))     // 相對路徑
        //using (var archive = ZipFile.Open(@"C:\Users\kanon\Desktop\EXLSTSE.zip", ZipArchiveMode.Update))      // 絕對路徑

        {
            int counter = 0;
            string line = null;
            var path = archive.GetEntry("resources/public/Ad_Hoc_Report_Views/EXLSTSE_files/stateXMLtest.data");

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
                        array1.Add(match.Groups[1].Value);
                        array2.Add(match.Groups[3].Value);
                    }
                    if (line.ToString().Contains("<parameterizedExpressionString>") == true)     // 31 char
                    {
                        counter++;
                    }
                }
                //for (int i = 0; i < array1.Count; i++)           // 印出array1(前面字串)
                //    Response.Write(array1[i] + "<br>");
                for (int i = 0; i < array2.Count; i++)             // 印出array2(後面字串)
                    Response.Write(array2[i] + "<br>");
                TextBox1.Text = counter.ToString();
                //Response.Write(counter);
            }

            var serializer = new JavaScriptSerializer();


            var script = string.Format("ChangeHtml({0}, {1});", serializer.Serialize(array1), serializer.Serialize(array2));     // 執行前端javascript的ChangeHtml
            ClientScript.RegisterStartupScript(GetType(), "call", script, true);
        }
    }

    protected void UpdateButton_Click(object sender, EventArgs e)
    {
        //values = HiddenField.Value.Split(',');
        //Response.Write("values[0]:"+values[0]);
        //Response.Write("values[1]:" + values[1]);
        //Response.Write("values[2]:" + values[2]);
        //Response.Write("values[3]:" + values[3]);

        //Response.Write("array2[0]:" + array2[0]);
        //Response.Write("array2[1]:" + array2[1]);
        //Response.Write("array2[2]:" + array2[2]);
        //Response.Write("array2[3]:" + array2[3]);



        //foreach (string value in values)
        //{
        //    Response.Write(value + "<br>");
        //}
        //int linecount = Convert.ToInt32(TextBox1.Text);
        //Response.Write(linecount);



        //using (var archive = ZipFile.Open(@"C:\Users\kanon\Desktop\EXLSTSE.zip", ZipArchiveMode.Update))   // 打開 zip 檔案
        //{
        //    var path = archive.GetEntry("resources/public/Ad_Hoc_Report_Views/EXLSTSE_files/stateXMLtest.data");
        //    using (StreamReader sr = new StreamReader(path.Open()))
        //    {
        //        string line = null;
        //        StringBuilder sb = new StringBuilder();
        //        while (!sr.EndOfStream)   // 讀取文件中的每一行
        //        {
        //            line = sr.ReadLine();
        //                for (int i = 0; i < 4; i++)
        //                {
        //                //Response.Write(array2[i] + "--" + values[i]);
        //                line = line.Replace(array2[i].ToString(), values[i]);              // 更新行中的參數值
        //            }
        //            sb.AppendLine(line);                                             // 將修改後的行加入字串構建器中
        //        }
        //        using (StreamWriter sw = new StreamWriter(path.Open()))              // 將修改後的文件內容寫回 zip 檔案
        //        {
        //            sw.Write(sb.ToString());
        //        }
        //    }
        //}


    }
}