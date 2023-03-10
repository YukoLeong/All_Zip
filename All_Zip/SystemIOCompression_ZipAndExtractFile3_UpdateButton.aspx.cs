using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Compression;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

public partial class SystemIOCompression_ZipAndExtractFile3_TestAjax : System.Web.UI.Page
{
    //ArrayList array1 = new ArrayList();
    //ArrayList array2 = new ArrayList();
    string[] values;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["array1"] == null)
        {
            Session["array1"] = new List<object>();
        }

        if (Session["array2"] == null)
        {
            Session["array2"] = new List<object>();
        }


    }

    protected void LoadButton_Click(object sender, EventArgs e)
    {

        List<object> array1 = (List<object>)(HttpContext.Current.Session["array1"] = new List<object>());    // 把上面4句合成2句
        List<object> array2 = (List<object>)(HttpContext.Current.Session["array2"] = new List<object>());

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
                //for (int i = 0; i < array1.Count; i++)
                //    Response.Write(array1[i] + "<br>");
                for (int i = 0; i < array2.Count; i++)
                    Response.Write(array2[i] + "<br>");
                TextBox1.Text = counter.ToString();
                //Response.Write(counter);
                sr.Close();
            }

            var serializer = new JavaScriptSerializer();


            var script = string.Format("ChangeHtml({0}, {1});", serializer.Serialize(array1), serializer.Serialize(array2));
            ClientScript.RegisterStartupScript(GetType(), "call", script, true);

            


            //Response.Write("array2[0]:" + array2[0]);
            //Response.Write("array2[1]:" + array2[1]);
            //Response.Write("array2[2]:" + array2[2]);
            //Response.Write("array2[3]:" + array2[3]);


            //var script = string.Format("ChangeHtml({0}, {1});", serializer.Serialize(array1), serializer.Serialize(array2));
            //var array1Json = serializer.Serialize(array1);
            //var array2Json = serializer.Serialize(array2);


            //var script1 = string.Format("ChangeHtml({0});", serializer.Serialize(array1));
            //var script2 = string.Format("ChangeHtml({0});", serializer.Serialize(array2));
            //ClientScript.RegisterStartupScript(GetType(), "call", script1, true);
            //ClientScript.RegisterStartupScript(GetType(), "call", script2, true);

            //this.ClientScript.RegisterStartupScript(this.GetType(), "test", "<script type='text/javascript'>ChangeHtml()</script>");
        }
    }

    protected void UpdateButton_Click(object sender, EventArgs e)        // (230221) 成功改變zip檔裡面的東西
    {

        List<object> array1 = (List<object>)HttpContext.Current.Session["array1"];
        List<object> array2 = (List<object>)HttpContext.Current.Session["array2"];

        values = HiddenField.Value.Split(',');

        Response.Write("array2[0]:" + array2[0] + "<br>");     // arrays是截取zip檔案的數值
        Response.Write("array2[1]:" + array2[1] + "<br>");
        Response.Write("array2[2]:" + array2[2] + "<br>");
        Response.Write("array2[3]:" + array2[3] + "<br>");
        Response.Write("values[0]:" + values[0] + "<br>");     // values[]是記錄textbox改過的數值
        Response.Write("values[1]:" + values[1] + "<br>");
        Response.Write("values[2]:" + values[2] + "<br>");
        Response.Write("values[3]:" + values[3]);


        // 打開 zip 檔案
        using (var archive = ZipFile.Open(Server.MapPath(@"ZipFolder\EXLSTSE.zip"), ZipArchiveMode.Update))     // 相對路徑
        //using (var archive = ZipFile.Open(@"C:\Users\kanon\Desktop\EXLSTSE.zip", ZipArchiveMode.Update))      // 絕對路徑
        {
            var path = archive.GetEntry("resources/public/Ad_Hoc_Report_Views/EXLSTSE_files/stateXMLtest.data");
            using (StreamReader sr = new StreamReader(path.Open()))
            {
                string line = null;
                StringBuilder sb = new StringBuilder();
                while (!sr.EndOfStream)   // 讀取文件中的每一行
                {
                    line = sr.ReadLine();
                    for (int i = 0; i < 4; i++)
                    {
                        //Response.Write(array2[i] + "--" + values[i]);
                        line = line.Replace(array2[i].ToString(), values[i]);              // 更新行中的參數值
                    }
                    sb.AppendLine(line);                                             // 將修改後的行加入字串構建器中
                }
                sr.Close();
                using (StreamWriter sw = new StreamWriter(path.Open()))              // 將修改後的文件內容寫回 zip 檔案
                {
                    sw.Write(sb.ToString());
                }
            }
        }
    }

}