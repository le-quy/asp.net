<%@ Page Title="" Language="C#" MasterPageFile="~/GDadmin.Master" AutoEventWireup="true" CodeBehind="ktradoanhthutheoten.aspx.cs" Inherits="quan_ly_cafe.ktradoanhthutheoten" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id ="form" runat ="server">
    <center> 
    <div style=" margin-left:100px;margin-right:100px;margin-top:100px">
    <table >
        <tr>
            <td style="height: 26px"></td>
            <td style="height: 26px">
                <asp:Label ID="Label1" runat="server" Text="KIỂM  TRA DOANH THU THEO NHÂN VIÊN :" Font-Bold="True" ForeColor="Black"></asp:Label>
                &nbsp;
                <asp:DropDownList ID="ddlnhanvien" runat="server"  AutoPostBack="True">
                    <asp:ListItem></asp:ListItem>
                </asp:DropDownList>
            </td>
            <td style="height: 26px"></td>
        </tr>
        <tr>
            <td style="height: 29px"></td>
            <td style="height: 29px">
                <asp:Button ID="btnhomnay" runat="server" Width="90" Height="45" Text="Hôm nay" OnClick="btnhomnay_Click" BackColor="DarkOrange" Font-Bold="True" ForeColor="Black"></asp:Button>
                <asp:Button ID="btntuchon" runat="server" Width="90" Height="45" style="margin-left:50px" Text="Tự chọn" OnClick="btntuchon_Click" BackColor="DarkOrange" Font-Bold="True" ForeColor="Black"></asp:Button>
                    <asp:Panel ID="pnngay" runat="server">
                    <asp:Label ID="Label3" runat="server" Text="Ngày" ForeColor="Black"></asp:Label>
                    <asp:DropDownList ID="ddlngay" runat="server" AutoPostBack="True">
                    </asp:DropDownList>
                    <asp:Label ID="Label2" runat="server" Text="Tháng" ForeColor="Black"></asp:Label>
                    <asp:DropDownList ID="ddlthang" runat="server" AutoPostBack="True">
                    </asp:DropDownList>
                    <asp:Label ID="Label4" runat="server" Text="Năm" ForeColor="Black"></asp:Label>
                    <asp:DropDownList ID="ddlnam" runat="server" AutoPostBack="True">
                    </asp:DropDownList>
                    <asp:Button ID="btnchon" runat="server" OnClick="Chon_Click" Text="Chọn" BackColor="DarkOrange" Font-Bold="True" ForeColor="Black" />
                </asp:Panel>
            
            </td>
            <td style="height: 29px"></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Panel ID="pnds" runat="server">
                    <asp:GridView ID="gvds" runat="server" AutoGenerateColumns="False" ForeColor="Black">
                    <Columns>
                        <asp:BoundField DataField="TENMON" HeaderText="TÊN MÓN" />
                        <asp:BoundField DataField="SOLUONG" HeaderText="SỐ LƯỢNG" />
                        <asp:BoundField DataField="THANHTIEN" HeaderText="THÀNH TIỀN" />
                    </Columns>
                    <HeaderStyle BackColor="#FF9900" ForeColor="Black" />
                </asp:GridView>
                <br />
                <asp:Label ID="Label5" runat="server" Font-Bold="True" ForeColor="Black" Text="Tổng tiền : "></asp:Label>
                <asp:Label ID="lbtt" runat="server" Font-Bold="True" ForeColor="Black"></asp:Label>
                </asp:Panel>
                
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
    </div>
    </center>
   </form>
</asp:Content>
