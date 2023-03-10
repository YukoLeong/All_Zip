<%@ Page Language="C#" AutoEventWireup="true" CodeFile="testpostback.aspx.cs" Inherits="testpostback" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="http://code.jquery.com/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#UpdateButton").click(function () {
                document.getElementById("demo").innerHTML = "js work";
                $.ajax({
                    type: "POST",
                    url: "testpostback.asmx/HelloWorld",
                    data: {},
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                        $("#demo2").text(response.d);
                    },
                    failure: function (response) {
                        alert(response.d);
                    }

                });
            });


            //function buttonfunc() {
            //    document.getElementById("demo").innerHTML = "js work";
            //    //return confirm("Really delete this reocrd?")
            //    //var enterdata = document.getElementById("TextBox1").value;
            //    $.ajax({
            //        type: "POST",
            //        url: "testpostback.asmx/HelloWorld",
            //        contentType: "application/json charset=utf-8",
            //        dataType: "text",
            //        data: {},
            //        success: function (response) {
            //            //alert("2");
            //            //alert(response.d);
            //            $("#demo2").text(response.d);
            //        },
            //        failure: function (response) {
            //            //alert("3");
            //            alert(response.d);
            //        }
            //    });
            //}
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <p id="demo"></p>
            <p id="demo2"></p>
            <input id="UpdateButton" type="button" value="Click" />
            <%--<button id="UpdateButton" type="button" onclick="buttonfunc()">Click</button>--%>
        </div>
    </form>
</body>
</html>
