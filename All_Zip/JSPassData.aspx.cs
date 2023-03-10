using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class JSPassData : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var array = new List<string> { "foo", "bar", "baz" };     // 寫法1 兩種表達方式寫法

        //ArrayList array = new ArrayList()                       // 寫法2 
        //{
        //    1,
        //    "Bill",
        //    300,
        //    4.5f
        //};

        var serializer = new JavaScriptSerializer();
        var script = string.Format("foo({0});", serializer.Serialize(array));
        ClientScript.RegisterStartupScript(GetType(), "call", script, true);
    }
}