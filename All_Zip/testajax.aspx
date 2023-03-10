<%@ Page Language="C#" AutoEventWireup="true" CodeFile="testajax.aspx.cs" Inherits="testajax" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script src="http://code.jquery.com/jquery-1.10.2.min.js" type="text/javascript"></script>

    <script type="text/javascript">
        function myjavatest() {
            //alert("1");
            $.ajax({
                type: "POST",
                url: "testajax.aspx/GetHello",
                contentType: "application/json; charset=utf-8",
                data: {},
                dataType: "json",
                success: function (data) {
                    $('#myLabel').text(data.d);
                    //test = "it's working";         // 除錯1
                    //alert(test);
                    //alert(data.d);                 // 除錯2
                },
                error: function (err) {
                    console.log(err);
                    //alert("Error detected");
                    //alert('Exception:', exception);
                    
                }
            });
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="myButton" runat="server" Text="Click me"
                OnClientClick="myjavatest();return false" />
            <br />
            <%--   如果不用ASMX的話 就需要轉static
            To reference controls on a page with jQuery, then make the label, or text box, or whatever with clientid="Static".
            (since the asp.net processor will mess with id names, this setting prevents that).  --%>
             <asp:Label ID="myLabel" runat="server" Text="" ClientIDMode="Static"/>    

        </div>
    </form>
</body>
</html>