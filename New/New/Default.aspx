<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="StyleSheet.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="register-form">
            <h2>Register</h2>
            <div>   
                <asp:DropDownList ID="DropDownList1" Class="txt" runat="server" />
                <asp:RequiredFieldValidator ID="rfvDepartment" Class="control" runat="server" ControlToValidate="DropDownList1" ValidationGroup="One" ErrorMessage="*" Display="Dynamic" />
            </div>

            <div>
                <asp:TextBox ID="txtname" Class="txt" runat="server" placeholder="Name"  autocomplete="off"/>
                <asp:RegularExpressionValidator ID="regexName" Class="control" runat="server" ErrorMessage="Please enter a valid name!" ControlToValidate="txtName" ValidationExpression="^[a-zA-Z'.]{3,25}$" Display="Dynamic" />
                <asp:RequiredFieldValidator ID="rfvName" Class="control" runat="server" ControlToValidate="txtName" ValidationGroup="One" ErrorMessage="*" Display="Dynamic" />
            </div>

            <div>
                <asp:TextBox ID="txtsurname" Class="txt" runat="server" placeholder="Surname" autocomplete="off"/>
                <asp:RegularExpressionValidator ID="regexSurname" Class="control" runat="server" ErrorMessage="Please enter a valid surname!" ControlToValidate="txtSurname" ValidationExpression="^[a-zA-Z'.]{3,25}$" Display="Dynamic" />
                <asp:RequiredFieldValidator ID="rfvSurname" Class="control" runat="server" ControlToValidate="txtSurname" ValidationGroup="One" ErrorMessage="*" Display="Dynamic"/>
            </div>

            <div>
                <asp:TextBox ID="txtid" Class="txt" runat="server" placeholder="Number" autocomplete="off"/>
                <asp:RegularExpressionValidator ID="regexID" Class="control" runat="server" ErrorMessage="Please enter a valid number!" ControlToValidate="txtId" ValidationExpression="^(0|[1-9]\d*)$" Display="Dynamic" />
                <asp:RequiredFieldValidator ID="rfvId" Class="control" runat="server" ControlToValidate="txtId" ValidationGroup="One" ErrorMessage="*" Display="Dynamic" />
                </div>

            <div>
                <asp:Label ID="lblImage" Class="label" runat="server"/>
                <asp:FileUpload ID="FileImageSave" Class="control" runat="server" />
            </div>

            <div>
                <asp:Button ID="btnsubmit" Class="but" runat="server" Text="Submit" ValidationGroup="One" OnClick="btnsubmit_Click" />
                <asp:Button ID="btncard" Class="but" runat="server" Text="Create Card" OnClick="btncard_Click" />
            </div>   

           </div>
            <div class="error">
                <asp:Literal ID="lblerror"  runat="server" />
            </div>
        </div>
    </form>
</body>
</html>
