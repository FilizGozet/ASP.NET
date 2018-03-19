<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Card.aspx.cs" Inherits="Card" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="StyleSheet2.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="register-form">
                <div class="top">
<%--                    <asp:Label ID="lbl" runat="server" Text="Lütfen isim seçiniz" />--%>
                    <asp:DropDownList ID="DropDownList1" Class="txt" runat="server" />
                </div>

                   <div class="inner-container" >
                           <div class="info">
                        <div>
                            <asp:Label ID="lblname" runat="server" Class="lbl" Text="Name" />
                            <asp:TextBox ID="txtname" runat="server" Class="txt" autocomplete="off"/>
                        </div>

                        <div>
                            <asp:Label ID="lblsurname" runat="server" Class="lbl" Text=" Surname" />
                            <asp:TextBox ID="txtsurname" runat="server" Class="txt" autocomplete="off"/>
                        </div>

                        <div>
                            <asp:Label ID="lblnumber" runat="server" Class="lbl" Text="  Student ID" />
                            <asp:TextBox ID="txtnumber" runat="server" Class="txt" autocomplete="off"/>
                        </div>

                        <div>
                            <asp:Label ID="lbldep" runat="server" Class="lbl" Text="  Department" />
                            <asp:TextBox ID="txtdep" runat="server" Class="txt" autocomplete="off"/>
                        </div>
                            </div>

                        <div class="img">
                            <asp:Image ID="image" runat="server" style="width:105px;height:105px;color:white;text-align:center;font-size:10px;" alt="student-foto" />
                        </div>
                    </div>


                <div class="bottom">
                    <asp:Button ID="btnback" runat="server" class="but" Text="Turn Back" OnClick="btnback_Click" />
                    <asp:Button ID="btnmake" runat="server" class="but" Text="Make Card"  OnClick="Button1_Click" />
                </div>
        </div>
     </div>
    </form>
</body>
</html>
