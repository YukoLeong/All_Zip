using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class StreamWriterExample : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var text = "";

        int checkword = 0;
        int checkwordcount = 0;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {

        //https://www.c-sharpcorner.com/article/csharp-streamwriter-example/

        string fileName = @"C:\Users\kanon\Desktop\test_stream_writer.txt";
        FileStream fs = null;                // finally要用 所以寫上面
        try
        {
            fs = new FileStream(fileName, FileMode.OpenOrCreate);              // 如果沒有這個文字檔的話會建立新的
            using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))   //注意 會取代文本全部文字
            {
                sw.WriteLine("C# Corner Authors");
                sw.WriteLine("==================");
                sw.WriteLine("Monica Rathbun");
                sw.WriteLine("Vidya Agarwal");
                sw.WriteLine("Mahesh Chand");
                sw.WriteLine("Vijay Anand");
                sw.WriteLine("Jignesh Trivedi");
            }
        }
        finally
        {
            if (fs != null)
                fs.Dispose();
        }
        // Read a file (Console testing用)
        string readText = File.ReadAllText(fileName);      //fileName = C:\Users\kanon\Desktop\test_stream_writer.txt
        Response.Write(readText);                // 只會顯示一行過
                                                 //Console.WriteLine(readText);
                                                 //Console.ReadKey();
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        //讀取文本,建立或寫入新文本,移除文本,更名或移動文本
        //https://stackoverflow.com/questions/13509532/how-to-find-and-replace-text-in-a-file

        using (var input = File.OpenText(@"C:\Users\kanon\Desktop\input.txt"))                //讀取文本內容
        using (var output = new StreamWriter(@"C:\Users\kanon\Desktop\output.txt"))           //寫入文本內容(如果沒有就建立)
        {
            string line;
            while (null != (line = input.ReadLine()))
            {
                // optionally modify line.
                output.WriteLine(line);
            }
        }
        //File.Delete(@"C:\Users\kanon\Desktop\input.txt");                                              //移除文本
        //File.Move(@"C:\Users\kanon\Desktop\output.txt", @"C:\Users\kanon\Desktop\input.txt");          //移動文本  相同位置就改名
    }

    protected void Button3_Click(object sender, EventArgs e)                                      //更改文本檔指定文字 (OK)
    {
        // https://stackoverflow.com/questions/13509532/how-to-find-and-replace-text-in-a-file
        // 正常版
        // string text = File.ReadAllText(@"C:\Users\kanon\Desktop\input.txt");                       
        // text = text.Replace("123", "AAA");
        // File.WriteAllText(@"C:\Users\kanon\Desktop\input.txt", text);

        // 一行版start
        File.WriteAllText(@"C:\Users\kanon\Desktop\input.txt", File.ReadAllText(@"C:\Users\kanon\Desktop\input.txt").Replace("123", "AAA"));
        // 一行版end
    }

    protected void Button4_Click(object sender, EventArgs e)                                      //讀文字內容
    {
        String path = @"C:\Users\kanon\Desktop\input.txt";

        using (StreamReader sr = File.OpenText(path))
        {
            String s = "";

            while ((s = sr.ReadLine()) != null)
            {
                Response.Write(s + "<br>");
            }
        }
    }
    protected void Button5_Click(object sender, EventArgs e)                                      //讀文字內容+搜尋目標文字數目
    {

        //https://www.guru99.com/c-sharp-stream.html

        String path = @"C:\Users\kanon\Desktop\input.txt";

        using (StreamReader sr = File.OpenText(path))
        {
            String s = "";
            String checkword = "123";
            int checkwordcount = 0;
            while ((s = sr.ReadLine()) != null)
            {

                if (s.Contains(checkword) == true)
                {
                    checkwordcount++;
                }
            }
            Response.Write(checkwordcount);
        }
    }

    protected void Button5b_Click(object sender, EventArgs e)                                      //寫入文字內容 (不會覆蓋)
    {

        //https://www.guru99.com/c-sharp-stream.html

        String path = @"C:\Users\kanon\Desktop\input.txt";

        using (StreamWriter sr = File.AppendText(path))
        {
            sr.WriteLine("Guru99 - ASP.Net");
            sr.Close();

            //Response.Write(File.ReadAllText(path));            // 顯示文本全部內容 *但不會換行

        }
    }

    protected void Button6_Click(object sender, EventArgs e)                                      //寫入文字內容 (不會覆蓋)
    {

        //https://www.c-sharpcorner.com/UploadFile/ff0d0f/streamreader-and-streamwriter-in-C-Sharp-net/

        WriteToFile();
        ReadFromFile();

    }

    public static void WriteToFile()
    {
        using (StreamWriter sw = File.CreateText(@"C:\Users\kanon\Desktop\testtable.tbl"))
        {
            sw.WriteLine("Please find the below generated table of 1 to 10");
            sw.WriteLine("");
            for (int i = 1; i <= 10; i++)
            {
                for (int j = 1; j <= 10; j++)
                {
                    sw.WriteLine("{0}x{1}= {2}", i, j, (i * j));
                }
                sw.WriteLine("==============");
            }
            HttpContext.Current.Response.Write("Table successfully written on file.");    // method裡面不能用response.write
        }
    }

    public static void ReadFromFile()
    {
        using (StreamReader sr = File.OpenText(@"C:\Users\kanon\Desktop\testtable.tbl"))
        {
            string tables = null;

            while ((tables = sr.ReadLine()) != null)        // sr = System.IO.StreamReader , sr.ReadLine() = tables =內容物  
            {
                HttpContext.Current.Response.Write(tables + "<br>");
            }
            HttpContext.Current.Response.Write("Table Printed.");
        }
    }
}