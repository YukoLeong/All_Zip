<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SystemIOCompression_ZipAndExtractFile2.aspx.cs" Inherits="SystemIOCompression_ZipAndExtractFile2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <%--SystemIOCompression_ZipAndExtractFile2是為了隔離1的 專注做zip目標--%>


    <script type="text/javascript">

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
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="LoadButton" runat="server" Text="Load" OnClick="LoadButton_Click" />
            <asp:TextBox ID="TextBox1" type="hidden" runat="server"></asp:TextBox>
            
            <div id="demo"></div>
            <input id="demo1" type="hidden" runat="server" />
            <input id="demo2" type="hidden" runat="server" />
            <input id="HiddenField" type="hidden" runat="server" />
            <%--step3--%>
            <%--<button type="button" onclick="buttonfunc()">Update</button>--%></button>
            <asp:Button ID="UpdateButton" runat="server" OnClientClick="buttonfunc()" Text="Update"
             OnClick="UpdateButton_Click" />
            

            <hr />
        </div>
    </form>
</body>
</html>
