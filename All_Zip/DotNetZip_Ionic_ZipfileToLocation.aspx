<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DotNetZip_Ionic_ZipfileToLocation.aspx.cs" Inherits="DotNetZip_Ionic_ZipfileToLocation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <%--(Project->Manage NuGet packages → DotNetZip)--%>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <%--壓縮指定檔案到指定地方--%>
            <asp:Button ID="Button1" runat="server" Text="Button1" OnClick="Button1_Click"/><br />
            <hr />
            <%--uploader上傳檔案和zip全部資料   只能上傳一個--%>
            <asp:FileUpload ID="FileUpload1" runat="server" />
            <asp:Button ID="Button2" runat="server" Text="Button2" OnClick="Button2_Click" />
            <asp:Label ID="Label1" runat="server" ForeColor="#CC0000"></asp:Label>
        </div>
    </form>
</body>
</html>
