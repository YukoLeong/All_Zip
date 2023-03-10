using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class JSPassWebForm : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click1(object sender, EventArgs e)
    {

        for (int i = 0; i < HiddenField.Value.Length; i++)
        {
            Response.Write(HiddenField.Value[i]);
        }
    }
}