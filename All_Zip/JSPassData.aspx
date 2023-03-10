<%@ Page Language="C#" AutoEventWireup="true" CodeFile="JSPassData.aspx.cs" Inherits="JSPassData" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

         <%--已經複製到bardesign的JS那邊和notion 有空可以刪--%> 

</head>
<body>
    <script>
        function foo(array) {
            for (var i = 0; i < array.length; i++) {
                //alert(array[i]);
                console.log('result: ', array[i])
            }
            document.getElementById("demo").innerHTML = array;
        }

    </script>
    <form id="form1" runat="server">
        <div>
            <p id="demo"></p>
        </div>
    </form>
</body>
</html>
