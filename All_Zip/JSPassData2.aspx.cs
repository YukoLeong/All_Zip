using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class JSPassData2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var array1 = new List<string> { "foo", "bar", "baz" };
        var array2 = new List<string> { "foo2", "bar2", "baz2" };

        var serializer = new JavaScriptSerializer();
        var script = string.Format("foo({0}, {1});", serializer.Serialize(array1), serializer.Serialize(array2));
        ClientScript.RegisterStartupScript(GetType(), "call", script, true);
    }
}