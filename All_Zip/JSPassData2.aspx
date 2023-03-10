<%@ Page Language="C#" AutoEventWireup="true" CodeFile="JSPassData2.aspx.cs" Inherits="JSPassData2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

        <%--已經複製到bardesign的JS那邊和notion 有空可以刪--%> 

</head>
<body>
    <script>
        function foo(array1, array2) {
            document.getElementById("demo1").innerHTML = array1;
            document.getElementById("demo2").innerHTML = array2;
            console.log('array1', array1)
            console.log('array2', array2)
        }

    </script>
    <form id="form1" runat="server">
        <div>
            <p id="demo1"></p>
            <p id="demo2"></p>
        </div>
    </form>
</body>
</html>
