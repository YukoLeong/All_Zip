<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SharpZipLib_DownloadGridView.aspx.cs" Inherits="SharpZipLib_DownloadGridView" %>

<!DOCTYPE html>



<%--各種資料放DownloadFloder裡面 之後可以單獨以及打包zip下載--%>
<%--Download multiple files as ZIP at once--%>
<%--https://www.youtube.com/watch?v=osxk5QjAKd4--%>

<%--1. 需要Project->Add Reference->ICSharpCode.SharpZipLib 檔案放了在外面有需要重新建立時可以再add 詳細看影片--%>
<%--2. 記得建立MyFile.cs 才能正常運行     (新版建立.cs class時會自動移動到App_Code)     --%>  

<%--不知道怎樣才可以放在bar_design16那邊單獨運行 只能夠以project檔方式運行--%>



<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
</head>
<body>
    <form id="form1" runat="server">
    <h3>Multiple file download at a time using asp.net.</h3>
    <div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField HeaderText="File Name" DataField="FileName" />
                <asp:BoundField HeaderText="File Size (KB)" DataField="FileSize" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <a href='<%#Eval("FilePath") %>' target="_blank">Download</a>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <br />
        <asp:Button ID="BtnDownloadAll" runat="server" Text="Download All Files as ZIP" OnClick="BtnDownloadAll_Click" />
    </div>

    </form>
</body>
</html>
