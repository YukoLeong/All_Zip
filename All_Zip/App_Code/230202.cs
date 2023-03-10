using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;



[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]

// 這兩句要自己加才能夠成功執行
[System.ComponentModel.ToolboxItem(false)]
[System.Web.Script.Services.ScriptService]      // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
public class _230202 : System.Web.Services.WebService
{

    [WebMethod]
    public string test01()
    {
        return "Hello World";
    }


    [WebMethod]

    public string test02(string name)
    {
        return "Hello World " + name + Environment.NewLine + "The Current Time is: " + DateTime.Now.ToString();
        //return name;
    }

}
