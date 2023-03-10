<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SystemIOCompression_ZipAndExtractFile4_Ajaxtest.aspx.cs" Inherits="SystemIOCompression_ZipAndExtractFile4_Ajaxtest" %>


<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <%--SystemIOCompression_ZipAndExtractFile3是為了測試ajax  成功加入update按鍵更新zip資料    --%>

    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>

    <script type="text/javascript">


        function LoadData() {
            $.ajax({
                type: "POST",
                url: "YourPage.aspx/LoadButton_Click",
                data: "{}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    // 執行成功時的操作
                    // 調用 ChangeHtml 函數，將數據添加到頁面上
                    var array1 = response.d.array1;
                    var array2 = response.d.array2;
                    ChangeHtml(array1, array2);
                },
                error: function (xhr, ajaxOptions, thrownError) {
                    // 執行失敗時的操作
                    alert(thrownError);
                }
            });
            return false;
        }


        //var html = "";

        // 改變demo的文字和觸發AddComponent動作


        function ChangeHtml(array1, array2) {
            var values = document.getElementById("TextBox1").value;     // 記得一定要有TextBox1才能正常執行
            //document.getElementById("demo1").innerHTML = array1;
            //document.getElementById("demo2").innerHTML = array2;
            //console.log('array1', array1)
            //console.log('array2', array2)
            if (values != null) {
                var html = "";
                for (var i = 0; i < values; i++) {
                    html += "<div>" + AddComponent(i, array1, array2) + "</div>";
                }

                document.getElementById("demo").innerHTML = html;
            }
            /*html += "<div><button type="'button'">Click Me!</button></div>"      這種寫法不行..*/

        }

        // 根據Textbox的數字生成部件    value = "" ,   id = i
        function AddComponent(i, array1, array2) {
            document.getElementById("demo1").innerHTML = array1;
            document.getElementById("demo2").innerHTML = array2;
            console.log('array1', array1)
            console.log('array2', array2)

            //預設測試用 會觸發TextboxChange
            //return '<input name = "DynamicTextBox" type="text" value = "" id = "' + i + '" onchange="TextboxChange(this.id,this.value)" />&nbsp;' +
            //    '<input type="button" value="Remove" onclick = "RemoveTextBox(this)" />'

            //step2
            //return '<input name = "DynamicTextBox" type="text" value = "" id = "' + i + '"" />&nbsp;' +
            //    '<input type="button" value="Remove" onclick = "RemoveTextBox(this)" />'


            document.getElementById("demo1").value = array1;
            document.getElementById("demo2").value = array2;

            return '<label>' + array1[i] + ': </label><input name = "DynamicTextBox" type="text"  value = "' + array2[i] + '" id = "Textbox' + (i + 1) + '" />&nbsp;'   // 這行不能加runat="server" 會錯
        }

        //step3
        function buttonfunc() {
            var linenum = document.getElementById("TextBox1");
            var linenumi = parseInt(linenum.value);
            var arrtemp = [];
            for (var i = 1; i <= linenumi; i++) {
                arrtemp.push(document.getElementById("Textbox" + i).value);
            }
            alert(arrtemp.join(","));
            document.getElementById("HiddenField").value = arrtemp;
            //return false;
        }


    </script>




</head>
<body>
    <%--<form id="form1" runat="server">--%>
    <form id="form2" runat="server" onsubmit="return false;">
        <div>

            <%--方法1 UseSubmitBehavior

            <asp:Button ID="LoadButton" runat="server" Text="Load" OnClick="LoadButton_Click" UseSubmitBehavior="false" />


            <asp:TextBox ID="TextBox1" type="hidden" runat="server"></asp:TextBox>

            <div id="demo"></div>
            <input id="demo1" type="hidden" runat="server" />
            <input id="demo2" type="hidden" runat="server" />
            <input id="HiddenField" type="hidden" runat="server" />--%>

            <%--step3--%>

            <%--<asp:Button ID="UpdateButton" runat="server" OnClientClick="buttonfunc()" Text="Update"
                OnClick="UpdateButton_Click" />
            <br />--%>


<%--            不行, LoadButton按鍵後沒有反應, 不能正常執行var script = string.Format("ChangeHtml({0}, {1});", serializer.Serialize(array1), serializer.Serialize(array2)); 
            裡面的ChangeHtml()--%>



            <%--方法2--%>

            <%--   ScriptManager 控件是 ASP.NET AJAX 中的一个重要控件，它的作用是管理 AJAX 脚本和 AJAX 服务。在 ASP.NET Web 窗体中，
            需要使用 AJAX 控件和服务的页面中需要添加 ScriptManager 控件，它提供了很多功能，例如在页面上使用 UpdatePanel 控件实现部分异步刷新，
            或者使用 ScriptManager 控件提供的 Web 服务等。--%>


            <%--            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div>
                        <asp:Button ID="LoadButton" runat="server" Text="Load" OnClick="LoadButton_Click" />
                        <asp:TextBox ID="TextBox1" type="hidden" runat="server"></asp:TextBox>

                        <div id="demo"></div>
                        <input id="demo1" type="hidden" runat="server" />
                        <input id="demo2" type="hidden" runat="server" />
                        <input id="HiddenField" type="hidden" runat="server" />

                        <hr />

                        <asp:Button ID="UpdateButton" runat="server" OnClientClick="buttonfunc()" Text="Update"
                            OnClick="UpdateButton_Click" />
                        <br />
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>--%>


            <asp:Button ID="LoadButton" runat="server" Text="Load" OnClick="LoadButton_Click" OnClientClick="return LoadData();" />


            <asp:TextBox ID="TextBox1" type="hidden" runat="server"></asp:TextBox>

            <div id="demo"></div>
            <input id="demo1" type="hidden" runat="server" />
            <input id="demo2" type="hidden" runat="server" />
            <input id="HiddenField" type="hidden" runat="server" />



            <%--正在考慮怎樣插入ajax function在.cs裡面--%>


            <hr />
        </div>
    </form>
</body>
</html>
