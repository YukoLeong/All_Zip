using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
/// Summary description for testpostback
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
[System.ComponentModel.ToolboxItem(false)]     // 這句好像不需要也能運行
[System.Web.Script.Services.ScriptService]      // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
public class testpostback : System.Web.Services.WebService
{
    [WebMethod]
    public string HelloWorld()
    {
        return "cs work";
    }

}
