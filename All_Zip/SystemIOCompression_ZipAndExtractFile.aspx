<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SystemIOCompression_ZipAndExtractFile.aspx.cs" Inherits="SystemIOCompression_ZipAndExtractFile" %>

<!DOCTYPE html>


    <%--ZipFile教學--%>
    <%--https://learn.microsoft.com/en-us/dotnet/standard/io/how-to-compress-and-extract-files--%>

    <%--要先在NuGet packages 下載System.IO.Compression 和 System.IO.Compression.ZipFile--%>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script type="text/javascript">

        //var html = "";

        // 改變demo的文字和觸發AddComponent動作
        function ChangeHtml() {
            var values = document.getElementById("TextBox1").value;     // 記得一定要有TextBox1才能正常執行
            if (values != null) {
                var html = "";
                for (var i = 0; i < values; i++) {
                    html += "<div>" + AddComponent(i) + "</div>";
                }
                document.getElementById("demo").innerHTML = html;
            }
        }

        // 根據Textbox的數字生成部件    value = "" ,   id = i
        function AddComponent(i) {
            return '<input name = "DynamicTextBox" type="text" value = "" id = "' + i + '" onchange="TextboxChange(this.id,this.value)" />&nbsp;' +
                '<input type="button" value="Remove" onclick = "RemoveTextBox(this)" />'
        }


        // 移除部件
        function RemoveTextBox(div) {
            document.getElementById("demo").removeChild(div.parentNode);
        }

        function TextboxChange(id, val) {
            alert("id = " + id + ", val = " + val);
        }

    </script>


</head>
<body>
    <form id="form1" runat="server">
        <div>
            <%--<h3>Create Zip File & Extract Zip File</h3>--%>                       
            <asp:Button ID="Button1" runat="server" Text="Zip file" OnClick="Button1_Click" />              <%--建立zip檔--%>  
            <asp:Button ID="Button2" runat="server" Text="Extract file" OnClick="Button2_Click" /><hr />    <%--解壓zip檔--%>  
            <h3>
                <%--<asp:Label ID="Label1" runat="server" Text="Enter path where to extract the zip file(.txt file only):"></asp:Label>--%>
                <%--<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>--%>
            </h3>
            <asp:Button ID="Button3" runat="server" Text="Extract file" OnClick="Button3_Click" /><hr />
            <%--<h3>Add a file to an existing zip file</h3>--%>                            <%--新增一個txt檔案在已存在的zip裡面--%>
            <asp:Button ID="Button4" runat="server" Text="Button4" OnClick="Button4_Click" /><hr />
            <asp:Button ID="Button5" runat="server" Text="Button5" OnClick="Button5_Click" /><hr />
            <asp:Button ID="Button6" runat="server" Text="Button6" OnClick="Button6_Click" /><hr />
            <asp:Button ID="Button7" runat="server" Text="Button7" OnClick="Button7_Click" /><hr />

            <%--<asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine"></asp:TextBox>--%>
            <asp:FileUpload ID="FileUpload1" runat="server" />
            <asp:Button ID="Button8" runat="server" Text="Button8" OnClick="Button8_Click" /><hr />
            <asp:Button ID="Button9" runat="server" Text="Button9" OnClick="Button9_Click" /><hr />
            <asp:Button ID="Button10" runat="server" Text="Button10" OnClick="Button10_Click" /><hr />
            <asp:Button ID="Button11" runat="server" Text="Button11" OnClick="Button11_Click" />
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox><hr />
            <div id="demo"></div>
            <hr />
            <%--<input type="text" id="TextBox10" name="name" value="0" onchange="ChangeHtml()">--%>
            <hr />
        </div>
    </form>
</body>
</html>
