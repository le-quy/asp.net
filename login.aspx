<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="quan_ly_cafe.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title> Đăng nhập </title>
    <style type="text/css">
        .auto-style2 {
            width: 455px;
        }
    </style>
</head>
<body style="background-color:lightblue">
    <form id="form1" runat="server" defaultbutton="btndn" defaultfocus="txtuser">
        <center>
        <div  style=" margin-left:350px;margin-right:250px;margin-top:100px; background-color:whitesmoke" >
        <table>
            <tr>
                <td rowspan="2" >
                    <asp:Image ID="Image1" runat="server" Height="400px" ImageUrl="~/img/sunflowers_coffee_mug_brownies_wooden_table-wallpaper-800x600.jpg" Width="300px" />
                </td>
                <td rowspan="2" class="auto-style2">
                    <asp:Label ID="Label1" runat="server" Text="ĐĂNG NHẬP" Font-Bold="True" Font-Size="XX-Large" ForeColor="#CC3300"></asp:Label>
                    <br />
                    <asp:Label ID="Label2" runat="server" Text="Username:" Font-Bold="True" Font-Italic="True" Font-Names="Yu Gothic UI" ForeColor="#CC3300" Font-Size="Large"></asp:Label>
                    <asp:TextBox ID="txtuser" style="margin-top:10px; margin-left:10px" Width="200" Height="40" runat="server" BorderColor="#CC3300" Font-Size="Large" ForeColor="Blue"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label3" runat="server" Text="Password:" Font-Bold="True" Font-Italic="True" Font-Names="Yu Gothic UI" ForeColor="#CC3300" Font-Size="Large"></asp:Label>
                    <asp:TextBox ID="txtpass" style="margin-top:10px; margin-left:15px" runat="server" Width="200px" Height="40" TextMode="Password" BorderColor="#CC3300" Font-Size="Large" ForeColor="Blue"></asp:TextBox>
                    <br />
                    <asp:Button ID="btndn" style="margin-top:10px; margin-left:100px" Width="150" Height="50" runat="server" Text="Đăng nhập" BackColor="#CC3300"  Font-Bold="True" Font-Italic="True" ForeColor="White" OnClick="btndn_Click1" Font-Size="Large"></asp:Button>
                     <br />
                    <asp:Label ID="lbtb" runat="server" Text="" ForeColor="Red" Font-Bold="True" Font-Italic="True"></asp:Label>
                    <br />
                    <asp:RequiredFieldValidator ID="loiuser" runat="server" ControlToValidate="txtuser" Display="Dynamic" ErrorMessage="*Bạn chưa nhập Tài khoản" ForeColor="Red">*Bạn chưa nhập Tài khoản</asp:RequiredFieldValidator>
                    <br />
                    <asp:RequiredFieldValidator ID="loipassword" runat="server" ControlToValidate="txtpass" Display="Dynamic" ErrorMessage="*Bạn chưa nhập Mật khẩu" ForeColor="Red">*Bạn chưa nhập Mật khẩu</asp:RequiredFieldValidator>
                    <asp:DropDownList ID="DropDownList1" runat="server">
                    </asp:DropDownList>
                </td>               
            </tr>
        </table>
      </div>
    </center>
    </form>
</body>
</html>