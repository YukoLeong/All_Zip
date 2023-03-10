<%@ Page Language="C#" AutoEventWireup="true" CodeFile="230202.aspx.cs" Inherits="_230202" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

        <script src="http://code.jquery.com/jquery-1.10.2.min.js" type="text/javascript"></script>

    <script type="text/javascript">
        //onload = function () {
        $(document).ready(function () {


            $("#button01").click(function () {
                $.ajax({
                    type: "POST",
                    url: "230202.asmx/test01",
                    data: {},
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                        //$("#divResponse").show("slow");
                        //$("#divResponse").css("background-color", "green");
                        //$("#divResponse").css("color", "white");
                        //$("#divResponse").css("text-align", "center");
                        //$("#divResponse").css("margin", "20px");
                        //alert(response.d);
                        $("#div01").text(response.d);
                    },
                    failure: function (response) {
                        alert(response.d);
                    }
                });
            });

            $("#button02").click(function () {

                //var name = document.getElementById("TextBox1").value;
                //var name = '123';
                //var name = $('#TextBox1').val(); //dont know why this can not work

                $.ajax({
                    type: "POST",
                    url: "230202.asmx/test02",
                    data: "{ 'name': '" + $('#TextBox1').val() + "'}",
                    //data: { 'name': name },
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    
                    success: function (response) {
                        $("#divResponse").show("slow");
                        $("#divResponse").css("background-color", "green");
                        $("#divResponse").css("color", "white");
                        $("#divResponse").css("text-align", "center");
                        $("#divResponse").css("margin", "20px");
                        //alert(response.d);
                        $("#div02").html(response.d);
                    },
                    failure: function (response) {
                        alert(response.d);
                    }
                });
            });


        });
        //}

    </script>
    
</head>
<body>
    <form id="form1" runat="server">
        <div>
            ajax01 :
            <input id="button01" type="button" value="Show Message" />
        </div>
        <div id="div01"></div>
        <br />
        <br />
        <br />
        <div>
            ajax02 :
            <asp:TextBox ID="TextBox1" runat="server" value=""></asp:TextBox>
            <input id="button02" type="button" value="Show Message" />
        </div>
        <div id="div02"></div>
        <div id="divResponse">123</div>
    </form>
</body>
</html>
