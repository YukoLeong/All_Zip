<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StreamWriterExample.aspx.cs" Inherits="StreamWriterExample" %>

<!DOCTYPE html>

<%--https://www.c-sharpcorner.com/article/csharp-streamwriter-example/--%>                     <%--example--%>
<%--https://learn.microsoft.com/en-us/dotnet/api/system.io.streamwriter?view=net-7.0--%>       <%--官方method說明--%>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <%--<asp:Label ID="Label1" runat="server" Text="寫入文本內容(如果沒有就建立)"></asp:Label>--%><br />
            <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" /><hr />
            <%--<asp:Label ID="Label2" runat="server" Text="讀取文本,建立或寫入新文本,移除文本,更名或移動文本"></asp:Label>--%><br />
            <asp:Button ID="Button2" runat="server" Text="Button" OnClick="Button2_Click" /><hr />
            <%--<asp:Label ID="Label3" runat="server" Text="更改指定文字"></asp:Label>--%><br />
            <asp:Button ID="Button3" runat="server" Text="Button" OnClick="Button3_Click" />

            <asp:Button ID="Button4" runat="server" Text="Button"  OnClick="Button4_Click" /><br />
            <asp:Button ID="Button5" runat="server" Text="Button5a"  OnClick="Button5_Click" />
            <asp:Button ID="Button5b" runat="server" Text="Button5b"  OnClick="Button5b_Click" />
            <asp:Button ID="Button6" runat="server" Text="Button6"  OnClick="Button6_Click" />

        </div>
    </form>
</body>
</html>