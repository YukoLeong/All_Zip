<%@ Page Language="C#" AutoEventWireup="true" CodeFile="JSPassWebForm.aspx.cs" Inherits="JSPassWebForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script>
        function AssignValue() {
            var array1 = ["Saab", "Volvo", "BMW"];
            document.getElementById("HiddenField").value = array1;
        }
    </script>


</head>
<body>
    <form id="form1" runat="server">
        <div>
            <input id="HiddenField" type="hidden" runat="server" />
            <asp:Button ID="Button1" runat="server" OnClientClick="AssignValue()" Text="Button"
                OnClick="Button1_Click1" />
        </div>
    </form>
</body>
</html>
