using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class testdrop : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // 检查Session中是否保存了文件名
        //if (!IsPostBack && Session["filename"] != null)
        //{
        //    showfilename1.Text = Session["filename"].ToString();
        //}
    }
}